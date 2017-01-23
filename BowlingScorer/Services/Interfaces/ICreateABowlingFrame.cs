using BowlingScorer.Models;

namespace BowlingScorer.Services.Interfaces
{
    public interface ICreateABowlingFrame
    {
        Frame Create(string scoreString);
    }
}