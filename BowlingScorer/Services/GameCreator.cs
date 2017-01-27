using BowlingScorer.Models;
using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
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
}