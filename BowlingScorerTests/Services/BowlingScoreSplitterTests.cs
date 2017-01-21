using BowlingScorer.Services;
using NUnit.Framework;

namespace BowlingScorerTests.Services
{
    public class BowlingScoreSplitterTests
    {
        [Test]
        public void should_SplitBowlingString_When_Invoked()
        {
            const string bowlingString = "X-|91|4-";
            var splitter = new BowlingStringSplitter();
            var result = splitter.Split(bowlingString);
            Assert.That(result[0], Is.EqualTo("X-"));
        }

        [Test]
        public void should_SplitBowlingString_When_Invoked2()
        {
            const string bowlingString = null;
            var splitter = new BowlingStringSplitter();
            var result = splitter.Split(bowlingString);
            Assert.That(result.Length, Is.EqualTo(0));
        }
    }
}
