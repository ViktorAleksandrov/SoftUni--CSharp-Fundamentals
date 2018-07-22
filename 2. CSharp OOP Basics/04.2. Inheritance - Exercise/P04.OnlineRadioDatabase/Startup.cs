namespace P04.OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var numberOfSongs = int.Parse(Console.ReadLine());

            var playlist = new List<Song>();

            for (int counter = 0; counter < numberOfSongs; counter++)
            {
                try
                {
                    Song song = CreateSong(playlist);

                    playlist.Add(song);

                    Console.WriteLine("Song added.");
                }
                catch (FormatException)
                {
                    Console.WriteLine(new InvalidSongLengthException().Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            PrintOutput(playlist);
        }

        private static Song CreateSong(List<Song> playlist)
        {
            var songInfo = Console.ReadLine().Split(';');

            if (songInfo.Length != 3)
            {
                throw new InvalidSongException();
            }

            var artistName = songInfo[0];
            var songName = songInfo[1];

            var songLength = songInfo[2].Split(':');

            var minutes = int.Parse(songLength[0]);
            var seconds = int.Parse(songLength[1]);

            return new Song(artistName, songName, minutes, seconds);
        }

        private static void PrintOutput(List<Song> playlist)
        {
            var playlistTotalSeconds = playlist.Sum(s => s.Minutes * 60 + s.Seconds);

            var length = TimeSpan.FromSeconds(playlistTotalSeconds);

            Console.WriteLine($"Songs added: {playlist.Count}");
            Console.WriteLine($"Playlist length: {length.Hours}h {length.Minutes}m {length.Seconds}s");
        }
    }
}