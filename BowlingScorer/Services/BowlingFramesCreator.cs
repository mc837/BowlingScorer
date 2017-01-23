using System.Collections.Generic;
using BowlingScorer.Models;
using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BowlingFramesCreator: ICreateBowlingFrames
    {
        private readonly ISplitBowlingStrings _bowlingScoreSplitter;
        private readonly ICreateABowlingFrame _frameCreator;

        public BowlingFramesCreator(ISplitBowlingStrings bowlingScoreSplitter, ICreateABowlingFrame frameCreator)
        {
            _bowlingScoreSplitter = bowlingScoreSplitter;
            _frameCreator = frameCreator;
        }

        public List<Frame> Create(string scoreString)
        {
            var bowlingScores = _bowlingScoreSplitter.Split(scoreString);

            var scoreList = new List<Frame>();

            foreach (var score in bowlingScores)
            {
                scoreList.Add(_frameCreator.Create(score));
            }
            return scoreList;
        }
    }
}