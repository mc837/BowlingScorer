using System.Collections.Generic;
using BowlingScorer.Models;

namespace BowlingScorer.Services.Interfaces
{
    public interface IUnpackBowlingStrings
    {
        List<Frame> Unpack(string[] bowlingScores);
    }
}