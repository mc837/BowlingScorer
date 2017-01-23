using System.Collections.Generic;
using BowlingScorer.Models;
using BowlingScorer.Services;
using BowlingScorer.Services.Interfaces;
using NUnit.Framework;

namespace BowlingScorerTests.Services
{
    public class GameCreatorTests
    {
        [Test]
        public void should_CreateAGame_When_Invoked()
        {
            var scoreString = "X-|X-|X-|X-|X-|X-|X-|X-|X-|X-";
            var gameCreator= new GameCreator(new BowlingFramesCreator(new BowlingStringSplitter(), new BowlingFrameCreator(new BowlScorer())));
            var game = gameCreator.Create(scoreString);
            Assert.That(game.Frames.Count, Is.EqualTo(10));
            //Assert.That(game.Score, Is.EqualTo(3));
        }
    }

    public class GameCreator
    {
        private readonly ICreateBowlingFrames _framesCreator;

        public GameCreator(ICreateBowlingFrames framesCreator)
        {
            _framesCreator = framesCreator;
        }

        public Game Create(string scoreString)
        {
            return new Game
            {
                Frames = _framesCreator.Create(scoreString)
            };
        }
    }

    public class Game
    {
        public List<Frame> Frames { get; set; }
        public int Score { get; set; }
    }
}
