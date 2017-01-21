using BowlingScorer.Services;
using NUnit.Framework;

namespace BowlingScorerTests.Services
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
}
