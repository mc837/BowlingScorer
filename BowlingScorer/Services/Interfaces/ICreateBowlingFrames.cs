using BowlingScorer.Models;

namespace BowlingScorer.Services.Interfaces
{
    public interface ICreateBowlingFrames
    {
        Frame Create(string scoreString);
    }
}