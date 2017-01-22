using System.Collections.Generic;
using BowlingScorer.Models;

namespace BowlingScorer.Services
{
    public class BonusScorer
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
                frames[frameNumber].BonusPoints = frames[frameNumber + 1].FrameBowlsTotal() +
                                        CheckForBonus(frames[frameNumber + 1].BonusFrameOne);
            }

            if (frameNumber == 9)
            {
                frames[frameNumber].BonusPoints = frames[frameNumber].BonusFrameOne.FrameBowlsTotal() + CheckForBonus(frames[frameNumber].BonusFrameTwo); ;
            }

            if (frameNumber < 8)
            {
                frames[frameNumber].BonusPoints = frames[frameNumber + 1].FrameBowlsTotal() + frames[frameNumber + 2].FrameBowlsTotal();
            }
        }

        private void ScoreSpareBonus(int frameNumber, IReadOnlyList<Frame> frames)
        {
            frames[frameNumber].BonusPoints = frameNumber == 9 ? CheckForBonus(frames[frameNumber].BonusFrameOne) : frames[frameNumber + 1].FrameBowlsTotal();
        }

        private int CheckForBonus(Frame bonusFrame)
        {
            return bonusFrame?.FrameBowlsTotal() ?? 0;
        }
    }

}
