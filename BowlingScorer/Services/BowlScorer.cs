using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BowlScorer:  IScoreBowls
    {
        public int Score(char bowlScore, char? previousBowlScore = null)
        {
            {
                int score;
                if (int.TryParse(bowlScore.ToString(), out score))
                {
                    return score;
                }

                switch (bowlScore)
                {
                    case 'X':
                        return 10;
                    case '/':
                        return GetSpareValue(previousBowlScore);
                    default:
                        return 0;
                }
            }
        }

        private int GetSpareValue(char? previousBowlScore)
        {
            int score;
            if (int.TryParse(previousBowlScore.ToString(), out score))
            {
                return 10 - score;
            }

            return previousBowlScore == '-' ? 10 : 0;
        }
    }
}