using NUnit.Framework;

namespace BowlingScorerTests
{
    public class BowlingFrameCreatorTests
    {
        [Test]
        public void should_CreateABowlingFrame_When_Invoked()
        {
            var bowlingCreator = new BowlingFrameCreator();
            var result = bowlingCreator.Create("X-");
            Assert.That(result.BowlOneScore, Is.EqualTo(10));
        }
    }

    public class BowlingFrameCreator
    {
        public Frame Create(string score)
        {
            return new Frame
            {
            };
        }
        
    }


    public class Frame
    {
        public int BowlOneScore { get; set; }
        public int BowlTwoScore { get; set; }
        public string FrameScore { get; set; }
    }
}
