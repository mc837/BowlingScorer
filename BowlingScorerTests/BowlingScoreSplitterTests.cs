using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace BowlingScorerTests
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

    public class BowlingStringSplitter
    {
        public string [] Split(string bowlingString)
        {
            return bowlingString?.Split('|') ?? new string[0];
        }
    }
}
