using BowlingScorer;
using BowlingScorer.Services;
using NUnit.Framework;

namespace BowlingScorerTests.Services
{
    public class BowlingFramesCreatorTests
    {
        [Test]
        public void should_CreateAListOfBowlingFrames_When_Invoked()
        {
            const string scoreString = "X-|X-|X-|X-|X-|X-|X-|X-|X-|X-";
            var framesCreator = new BowlingFramesCreator(new BowlingStringSplitter(), new BowlingFrameCreator(new BowlScorer()));
            var list = framesCreator.Create(scoreString);
            Assert.That(list.Count, Is.EqualTo(10));
        }
    }
}
