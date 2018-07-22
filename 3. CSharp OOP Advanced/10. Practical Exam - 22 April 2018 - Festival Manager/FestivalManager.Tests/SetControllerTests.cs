// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using System;

    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Core.Controllers.Contracts;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;

    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;

        [SetUp]
        public void SetUpSetController()
        {
            this.stage = new Stage();
            this.setController = new SetController(this.stage);
        }

        [Test]
        public void TestMessageWhenSetIsSuccessful()
        {
            IInstrument instrument = new Guitar();
            IPerformer performer = new Performer("Ivan", 20);

            performer.AddInstrument(instrument);

            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));

            this.stage.AddSong(song);

            ISet set = new Short("Set1");

            set.AddPerformer(performer);
            set.AddSong(song);

            this.stage.AddSet(set);

            string actual = this.setController.PerformSets().Trim();

            string expected =
                "1. Set1:" + Environment.NewLine + "-- 1. Song1 (01:02)" + Environment.NewLine + "-- Set Successful";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestMessageWhenSetDidNotPerform()
        {
            IPerformer performer = new Performer("Ivan", 20);
            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));

            this.stage.AddSong(song);

            ISet set = new Short("Set1");

            set.AddPerformer(performer);
            set.AddSong(song);

            this.stage.AddSet(set);

            string actual = this.setController.PerformSets().Trim();
            string expected = "1. Set1:" + Environment.NewLine + "-- Did not perform";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestWearOfInstrument()
        {
            IInstrument instrument = new Guitar();

            IPerformer performer = new Performer("Ivan", 20);
            performer.AddInstrument(instrument);

            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            this.stage.AddSong(song);

            ISet set = new Short("Set1");

            set.AddPerformer(performer);
            set.AddSong(song);

            this.stage.AddSet(set);

            this.setController.PerformSets();

            Assert.That(instrument.Wear, Is.EqualTo(40));
        }
    }
}