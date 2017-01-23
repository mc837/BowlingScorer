using System.Collections.Generic;
using BowlingScorer.Models;

namespace BowlingScorer.Services.Interfaces
{
    public interface ICreateBowlingFrames
    {
        List<Frame> Create(string bowlingScoreString);
    }
}
