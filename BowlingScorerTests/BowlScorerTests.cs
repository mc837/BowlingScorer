using NUnit.Framework;

namespace BowlingScorerTests
{
    public class BowlScorerTests
    {
        [TestCase('9', 9)]
        [TestCase('X', 10)]
        [TestCase('-', 0)]
        [TestCase('/', 5, '5')]
        [TestCase('/', 4, '6')]
        [TestCase('/', 10, '-')]
        public void should_EvaluateScoreAsExpected_When_Invoked(char bowlScore, int expectedScore, char? previousBowlScore = null)
        {
            var bowlScorer = new BowlScorer();
            var result = bowlScorer.Score(bowlScore, previousBowlScore);
            Assert.That(result, Is.EqualTo(expectedScore));
        }
    
        //check for null previousScore
    }

    public class BowlScorer
    {
        public int Score(char bowlScore, char? previousBowlScore = null)
        {
            {
                int score;
                if (int.TryParse(bowlScore.ToString(), out score))
                {
                    return score;
                };

                switch (bowlScore)
                {
                    case 'X':
                        return 10;
                    case '/':
                        return GetSpareValue(previousBowlScore);
                }
                return 0;
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
