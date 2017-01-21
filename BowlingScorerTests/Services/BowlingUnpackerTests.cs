using BowlingScorer.Services;
using NUnit.Framework;

namespace BowlingScorerTests.Services
{
    public class BowlingUnpackerTests
    {
        [Test]
        public void should_ParseBowlingScores_When_Invoked()
        {
            string[] bowlingGame = { "X-", "34", "4-", "1/" };
            var unpacker = new BowlingStringUnpacker(new BowlingFrameCreator(new BowlScorer()));
            var result = unpacker.Unpack(bowlingGame);
            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0].BowlTotal, Is.EqualTo(10));
            Assert.That(result[1].BowlTotal, Is.EqualTo(7));
            Assert.That(result[2].BowlTotal, Is.EqualTo(4));
            Assert.That(result[3].BowlTotal, Is.EqualTo(10));
        }
    }
}
