namespace BowlingScorer.Services.Interfaces
{
    public interface IScoreBowls
    {
        int Score(char bowlScore, char? previousBowlScore = null);
    }
}