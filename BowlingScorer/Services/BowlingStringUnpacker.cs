using System.Collections.Generic;
using BowlingScorer.Models;
using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BowlingStringUnpacker
    {
        private readonly ICreateBowlingFrames _bowlingFrameCreator;

        public BowlingStringUnpacker(ICreateBowlingFrames bowlingFrameCreator)
        {
            _bowlingFrameCreator = bowlingFrameCreator;
        }

        public List<Frame> Unpack(string[] bowlingScores)
        {
            var scoreList = new List<Frame>();

            foreach (var score in bowlingScores)
            {
                scoreList.Add(_bowlingFrameCreator.Create(score));
            }

            return scoreList;
        }
    }
}