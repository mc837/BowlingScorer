using BowlingScorer.Services;
using NUnit.Framework;

namespace BowlingScorerTests.Services
{
    public class BowlingFrameCreatorTests
    {
        [TestCase("X-", 10, 0, 10, "Strike")]
        [TestCase("4/", 4, 6, 10, "Spare")]
        [TestCase("25", 2, 5, 7, "7")]
        public void should_CreateABowlingFrame_When_Invoked(string scoreString, int bowlOneScore, int bowlTwoScore, int bowlTotal, string scoreText)
        {
            var bowlingCreator = new BowlingFrameCreator(new BowlScorer());
            var result = bowlingCreator.Create(scoreString);
            Assert.That(result.BowlOneScore, Is.EqualTo(bowlOneScore));
            Assert.That(result.BowlTwoScore, Is.EqualTo(bowlTwoScore));
            Assert.That(result.BowlTotal, Is.EqualTo(bowlTotal));
            Assert.That(result.FrameScoreText, Is.EqualTo(scoreText));
        }
    }
}
