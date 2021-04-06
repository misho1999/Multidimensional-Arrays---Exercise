// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private const string CanNotBeNullMessage = "Can not be null!";
        private Performer performer;
        private Song song;
        private Stage stage;
        [Test]
        public void WhenPerformerIsNull_ShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                performer = null;
                stage = new Stage();
                stage.AddPerformer(performer);

            });
        }
        [Test]
        public void WhenPerformerAgeIsLessThan18_ShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                performer = new Performer("Misho", "Nalbantov", 17);
                
                stage = new Stage();
                stage.AddPerformer(performer);

            });
            Assert.AreEqual(ex.Message, "You can only add performers that are at least 18.");
        }
        [Test]
        public void ShouldAddNewPerformerInStage()
        {
            performer = new Performer("Misho", "Nalbantov", 22);
            stage = new Stage();
            stage.AddPerformer(performer);
            Assert.AreEqual(1, stage.Performers.Count);
        }
        [Test]
        public void WhenDurationIsLessThan1Minute_ShouldThrowException()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                stage = new Stage();
                song = new Song("Jiva rana", new TimeSpan(0, 0, 59));
                stage.AddSong(song);

            });
            Assert.AreEqual(ex.Message, "You can only add songs that are longer than 1 minute.");
        }
        [Test]
        public void ShouldAddNewSongInStage()
        {
            song = new Song("Jiva rana", new TimeSpan(0, 3, 45));
            stage = new Stage();
            stage.AddSong(song);

        }
        [Test]
        public void ShouldAddSongToPerformer()
        {
            performer = new Performer("Misho","Nalbantov", 22);
            song = new Song("Jiva rana", new TimeSpan(0, 3, 45));
            performer.SongList.Add(song);
            Assert.AreEqual(1, performer.SongList.Count);
        }
        [Test]
        public void ShouldReturnCorrectPerformerOutput()
        {
            performer = new Performer("Misho", "Nalbantov", 22);
            song = new Song("Jiva rana", new TimeSpan(0, 3, 45));
            Stage stage = new Stage();

            performer.SongList.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var result = $"{song.ToString()} will be performed by {performer.FullName}";
            var result2 = stage.AddSongToPerformer(song.Name,performer.FullName);
            Assert.AreEqual(result, result2);
        }
        [Test]
        public void ShouldReturnCorrectSongOutput()
        {
            List<Performer> performers = new List<Performer>();
            performer = new Performer("Misho", "Nalbantov", 22);
            song = new Song("Jiva rana", new TimeSpan(0, 3, 45));
            Stage stage = new Stage();

            performer.SongList.Add(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);
            performers.Add(performer);

            var output = performers.Sum(p => p.SongList.Count());
            var result = $"{performers.Count} performers played {output} songs";
            var result2 = stage.Play();
            Assert.AreEqual(result, result2);
        }


    }
}