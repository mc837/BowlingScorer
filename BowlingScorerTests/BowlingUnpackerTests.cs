using System.Collections.Generic;
using NUnit.Framework;

namespace BowlingScorerTests
{
    public class BowlingUnpackerTests
    {
        [Test]
        public void should_UnpackBowlingString_When_Invoked()
        {
            string[] bowlingGame = { "X-", "34", "4-" };
            var unpacker = new BowlingStringUnpacker();
            var result = unpacker.Unpack(bowlingGame);
            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]
        public void should_ParseBowlingScores_When_Invoked()
        {
            string[] bowlingGame = { "X-", "34", "4-" };
            var unpacker = new BowlingStringUnpacker();
            var result = unpacker.Unpack(bowlingGame);
            Assert.That(result[0], Is.TypeOf<Frame>());
            Assert.That(result[0].FrameScore, Is.EqualTo(10));
        }

    }


    public class BowlingStringUnpacker
    {
        public List<Frame> Unpack(string[] bowlingString)
        {
            var scoreList = new List<Frame>();

            foreach (var score in bowlingString)
            {
               
            }

            return scoreList;
        }
    }
}
