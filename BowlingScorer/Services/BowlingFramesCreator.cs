using System.Collections.Generic;
using BowlingScorer.Models;
using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BowlingFramesCreator: ICreateBowlingFrames
    {
        private readonly ISplitBowlingStrings _bowlingScoreSplitter;
        private readonly ICreateABowlingFrame _frameCreator;
        private readonly IScoreBowlingBonusPoints _bonusScorer;

        public BowlingFramesCreator(ISplitBowlingStrings bowlingScoreSplitter, ICreateABowlingFrame frameCreator, IScoreBowlingBonusPoints bonusScorer)
        {
            _bowlingScoreSplitter = bowlingScoreSplitter;
            _frameCreator = frameCreator;
            _bonusScorer = bonusScorer;
        }

        public List<Frame> Create(string scoreString)
        {
            var bowlingScores = _bowlingScoreSplitter.Split(scoreString);

            var scoreList = new List<Frame>();

            foreach (var score in bowlingScores)
            {
                scoreList.Add(_frameCreator.Create(score));
            }

            _bonusScorer.Score(scoreList);

            return scoreList;
        }
    }
}