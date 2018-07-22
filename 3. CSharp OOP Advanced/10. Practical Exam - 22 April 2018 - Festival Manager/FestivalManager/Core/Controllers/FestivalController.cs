namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:D2}:{1:D2}";

        private readonly IStage stage;

        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;

            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
        }

        public string ProduceReport()
        {
            var result = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendLine($"Festival length: {FormatTimeSpan(totalFestivalLength)}");

            foreach (ISet set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({FormatTimeSpan(set.ActualDuration)}):");

                IPerformer[] performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age).ToArray();

                foreach (IPerformer performer in performersOrderedDescendingByAge)
                {
                    string instruments = string.Join(", ", performer.Instruments.OrderByDescending(i => i.Wear));

                    result.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                {
                    result.AppendLine("--No songs played");
                }
                else
                {
                    result.AppendLine("--Songs played:");

                    foreach (ISong song in set.Songs)
                    {
                        result.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return result.ToString().TrimEnd();
        }

        private static string FormatTimeSpan(TimeSpan timeSpan)
        {
            string formatted = string.Format(TimeFormatLong, (int)timeSpan.TotalMinutes, timeSpan.Seconds);

            return formatted;
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);

            string[] instrumentsTypes = args.Skip(2).ToArray();

            IInstrument[] instruments = instrumentsTypes
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            foreach (IInstrument instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            string durationStr = args[1];

            var duration = TimeSpan.ParseExact(durationStr, TimeFormat, CultureInfo.InvariantCulture);

            ISong song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

            return $"Registered song {song}";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            IInstrument[] instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (IInstrument instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string AddSongToSet(string[] args)
        {
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            string songName = args[0];

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {setName}";
        }
    }
}