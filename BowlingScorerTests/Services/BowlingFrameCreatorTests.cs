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
            Assert.That(result.FrameBowlsTotal, Is.EqualTo(bowlTotal));
            Assert.That(result.FrameScoreText, Is.EqualTo(scoreText));
        }

        [TestCase("7/X", 7, 3, 10, "Spare", 10, 0, null)]
        [TestCase("7/5", 7, 3, 10, "Spare", 5, 0, null)]
        [TestCase("X5/", 10, 0, 10, "Strike", 5, 5, null)]
        [TestCase("X52", 10, 0, 10, "Strike", 5, 2, null)]
        public void should_CreateOnlyOneBonusBowlingFrame_When_SecondBowlMakesSpare(string scoreString, int bowlOneScore, int bowlTwoScore, int bowlTotal,
            string scoreText, int bonusOneBowlOne, int bonusOneBowlTwo, int? bonusTwo)
        {
            var bowlingCreator = new BowlingFrameCreator(new BowlScorer());
            var result = bowlingCreator.Create(scoreString);
            Assert.That(result.BowlOneScore, Is.EqualTo(bowlOneScore));
            Assert.That(result.BowlTwoScore, Is.EqualTo(bowlTwoScore));
            Assert.That(result.FrameBowlsTotal, Is.EqualTo(bowlTotal));
            Assert.That(result.FrameScoreText, Is.EqualTo(scoreText));
            Assert.That(result.BonusFrameOne.BowlOneScore, Is.EqualTo(bonusOneBowlOne));
            Assert.That(result.BonusFrameOne.BowlTwoScore, Is.EqualTo(bonusOneBowlTwo));
            Assert.That(result.BonusFrameTwo, Is.EqualTo(bonusTwo));
        }

        [TestCase("XXX", 10, 0, 10, "Strike", 10, 10)]
        public void should_CreateASecondBonusBowlingFrame_When_FirstOrSecondAreStrikesorSpare(string scoreString, int bowlOneScore, int bowlTwoScore, int bowlTotal, string scoreText, int bonusOne, int? bonusTwo)
        {
            var bowlingCreator = new BowlingFrameCreator(new BowlScorer());
            var result = bowlingCreator.Create(scoreString);
            Assert.That(result.BowlOneScore, Is.EqualTo(bowlOneScore));
            Assert.That(result.BowlTwoScore, Is.EqualTo(bowlTwoScore));
            Assert.That(result.FrameBowlsTotal, Is.EqualTo(bowlTotal));
            Assert.That(result.FrameScoreText, Is.EqualTo(scoreText));
            Assert.That(result.BonusFrameOne.BowlOneScore, Is.EqualTo(bonusOne));
            Assert.That(result.BonusFrameTwo.BowlOneScore, Is.EqualTo(bonusTwo));
        }

        [TestCase("72", 7, 2, 9, "9", null, null)]
        [TestCase("7-", 7, 0, 7, "7", null, null)]
        public void should_NotCreateAnyBonusBowlingFrame_When_SecondBowlMakesSpare(string scoreString, int bowlOneScore, int bowlTwoScore, int bowlTotal,
    string scoreText, int? bonusOne, int? bonusTwo)
        {
            var bowlingCreator = new BowlingFrameCreator(new BowlScorer());
            var result = bowlingCreator.Create(scoreString);
            Assert.That(result.BowlOneScore, Is.EqualTo(bowlOneScore));
            Assert.That(result.BowlTwoScore, Is.EqualTo(bowlTwoScore));
            Assert.That(result.FrameBowlsTotal, Is.EqualTo(bowlTotal));
            Assert.That(result.FrameScoreText, Is.EqualTo(scoreText));
            Assert.That(result.BonusFrameOne, Is.EqualTo(bonusOne));
            Assert.That(result.BonusFrameTwo, Is.EqualTo(bonusTwo));
        }
    }
}
