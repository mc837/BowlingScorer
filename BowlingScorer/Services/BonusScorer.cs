using System.Collections.Generic;
using BowlingScorer.Models;
using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BonusScorer: IScoreBowlingBonusPoints
    {
        public List<Frame> Score(List<Frame> frames)
        {
            var i = 0;
            while (i < frames.Count)
            {
                if (frames[i].IsStrike())
                {
                    ScoreStrikeBonus(i, frames);
                }
                if (frames[i].IsSpare())
                {
                    ScoreSpareBonus(i, frames);
                }
                i++;
            }

            return frames;
        }

        private void ScoreStrikeBonus(int frameNumber, IReadOnlyList<Frame> frames)
        {
            if (frameNumber == 8)
            {
                if (frames[frameNumber + 1].IsStrike())
                {
                    frames[frameNumber].BonusPoints = frames[frameNumber + 1].BowlOneScore +
                                                      CheckForBonus(frames[frameNumber + 1].BonusFrameOne);
                }
                else
                {
                    frames[frameNumber].BonusPoints = frames[frameNumber + 1].BowlOneScore;
                }
            }

            if (frameNumber == 9)
            {
                frames[frameNumber].BonusPoints = frames[frameNumber].BonusFrameOne.FrameBowlsTotal() + CheckForBonus(frames[frameNumber].BonusFrameTwo); ;
            }

            if (frameNumber < 8)
            {
                if (frames[frameNumber + 1].IsStrike())
                {
                    frames[frameNumber].BonusPoints = frames[frameNumber + 1].BowlOneScore + frames[frameNumber + 2].BowlOneScore;
                }
                else
                {
                    frames[frameNumber].BonusPoints = frames[frameNumber + 1].BowlOneScore;
                }
            }
        }

        private void ScoreSpareBonus(int frameNumber, IReadOnlyList<Frame> frames)
        {
            frames[frameNumber].BonusPoints = frameNumber == 9 ? CheckForBonus(frames[frameNumber].BonusFrameOne) : frames[frameNumber + 1].BowlOneScore;
        }

        private int CheckForBonus(Frame bonusFrame)
        {
            return bonusFrame?.BowlOneScore ?? 0;
        }
    }

}
