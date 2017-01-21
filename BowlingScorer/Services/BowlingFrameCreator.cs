using BowlingScorer.Models;
using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BowlingFrameCreator: ICreateBowlingFrames 
    {
        private readonly IScoreBowls _bowlScorer;

        public BowlingFrameCreator(IScoreBowls bowlScorer)
        {
            _bowlScorer = bowlScorer;
        }

        public Frame Create(string scoreString)
        {
            return new Frame
            {
                BowlOneScore = _bowlScorer.Score(scoreString[0]),
                BowlTwoScore = _bowlScorer.Score(scoreString[1], scoreString[0])
            };
        }
    }
}