using System.Collections.Generic;
using BowlingScorer.Models;

namespace BowlingScorer.Services.Interfaces
{
    public interface IScoreBowlingBonusPoints
    {
        List<Frame> Score(List<Frame> frames);
    }
}
