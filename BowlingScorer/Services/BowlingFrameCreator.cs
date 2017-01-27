using BowlingScorer.Models;
using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BowlingFrameCreator : ICreateABowlingFrame
    {
        private readonly IScoreBowls _bowlScorer;

        public BowlingFrameCreator(IScoreBowls bowlScorer)
        {
            _bowlScorer = bowlScorer;
        }

        public Frame Create(string scoreString)
        {
            return scoreString.Length == 3 ? CreateFrameWithBonusFrames(scoreString) : CreateFrameWithoutBonusFrames(scoreString);
        }

        private Frame CreateFrameWithBonusFrames(string scoreString)
        {
            var frame = new Frame {BowlOneScore = _bowlScorer.Score(scoreString[0])};

            if (frame.IsStrike())
            {
                frame.BonusFrameOne = new Frame
                {
                    BowlOneScore = _bowlScorer.Score(scoreString[1])
                };
                if (frame.BonusFrameOne.IsStrike())
                {
                    frame.BonusFrameTwo = new Frame
                    {
                        BowlOneScore = _bowlScorer.Score(scoreString[2])
                    };
                }
                else
                {
                    frame.BonusFrameOne.BowlTwoScore = _bowlScorer.Score(scoreString[2], scoreString[1]);
                }
            }
            else
            {
                frame.BowlTwoScore = _bowlScorer.Score(scoreString[1], scoreString[0]);
            }

            if (frame.IsSpare())
            {
                frame.BonusFrameOne = new Frame
                {
                    BowlOneScore = _bowlScorer.Score(scoreString[2])
                };
            }
            return frame;
        }

        private Frame CreateFrameWithoutBonusFrames(string scoreString)
        {
            return new Frame
            {
                BowlOneScore = _bowlScorer.Score(scoreString[0]),
                BowlTwoScore = _bowlScorer.Score(scoreString[1], scoreString[0])
            };
        }
    }
}