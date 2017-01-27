using BowlingScorer.Services;
using NUnit.Framework;

namespace BowlingScorerTests.Services
{
    public class GameCreatorTests
    {
        [TestCase("X-|X-|X-|X-|X-|X-|X-|X-|X-|XXX", 10, 300)]
        [TestCase("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/5", 10, 150)]
        [TestCase("9-|9-|9-|9-|9-|9-|9-|9-|9-|9--", 10, 90)]
        [TestCase("--|--|--|--|--|--|--|--|--|---", 10, 0)]
        public void should_CreateAGame_When_Invoked(string bowlingString, int frameCount, int gamesScore)
        {
            var gameCreator =
                new GameCreator(new BowlingFramesCreator(new BowlingStringSplitter(),
                    new BowlingFrameCreator(new BowlScorer()), new BonusScorer()));
            var game = gameCreator.Create(bowlingString);
            Assert.That(game.Frames.Count, Is.EqualTo(frameCount));
            Assert.That(game.Score(), Is.EqualTo(gamesScore));
        }
    }
}
