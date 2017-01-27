using System.Collections.Generic;
using System.Runtime.InteropServices;
using BowlingScorer.Models;
using BowlingScorer.Services;
using NUnit.Framework;

namespace BowlingScorerTests.Services
{
    public class BonusScorerTests
    {
        // X for bonus = score for next 2 bowls
        // / for bonus = score next bowl
        [Test]
        public void should_ScoreAFramesBonusPoints_When_NoStrikesOrSpares()
        {
            var frames = GetNoSparesOrStrikes();
            var bonusScorer = new BonusScorer();
            var result = bonusScorer.Score(frames);
            Assert.That(result[0].FrameBowlsTotal(), Is.EqualTo(1));
            Assert.That(result[0].BonusPoints, Is.EqualTo(0));
            Assert.That(result[0].FrameScore, Is.EqualTo(1));
            Assert.That(result[7].FrameBowlsTotal(), Is.EqualTo(8));
            Assert.That(result[7].BonusPoints, Is.EqualTo(0));
            Assert.That(result[7].FrameScore, Is.EqualTo(8));
            Assert.That(result[8].FrameBowlsTotal(), Is.EqualTo(9));
            Assert.That(result[8].BonusPoints, Is.EqualTo(0));
            Assert.That(result[8].FrameScore, Is.EqualTo(9));
            Assert.That(result[9].FrameBowlsTotal(), Is.EqualTo(9));
            Assert.That(result[9].BonusPoints, Is.EqualTo(0));
            Assert.That(result[9].FrameScore, Is.EqualTo(9));
        }

        [Test]
        public void should_ScoreAFramesBonusPoints_When_EveryOtherIsStrike()
        {
            var frames = GetEveryOtherStrikes();
            var bonusScorer = new BonusScorer();
            var result = bonusScorer.Score(frames);
            Assert.That(result[0].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[0].BonusPoints, Is.EqualTo(5));
            Assert.That(result[0].FrameScore, Is.EqualTo(15));
            Assert.That(result[1].FrameBowlsTotal(), Is.EqualTo(5));
            Assert.That(result[1].BonusPoints, Is.EqualTo(0));
            Assert.That(result[1].FrameScore, Is.EqualTo(5));
            Assert.That(result[7].FrameBowlsTotal(), Is.EqualTo(5));
            Assert.That(result[7].BonusPoints, Is.EqualTo(0));
            Assert.That(result[7].FrameScore, Is.EqualTo(5));
            Assert.That(result[8].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[8].BonusPoints, Is.EqualTo(5));
            Assert.That(result[8].FrameScore, Is.EqualTo(15));
            Assert.That(result[9].FrameBowlsTotal(), Is.EqualTo(5));
            Assert.That(result[9].BonusPoints, Is.EqualTo(0));
            Assert.That(result[9].FrameScore, Is.EqualTo(5));
        }

        private List<Frame> GetEveryOtherStrikes()
        {
            return new List<Frame>
            {
                StrikeFrame(), // 1
                NumberFrame(), // 2
                StrikeFrame(), // 3
                NumberFrame(), // 4
                StrikeFrame(), // 5
                NumberFrame(), // 6
                StrikeFrame(), // 7
                NumberFrame(), // 8
                StrikeFrame(), // 9
                NumberFrame()  // 10
            };
        }

        private Frame NumberFrame()
        {
            return new Frame {BowlOneScore = 5, BowlTwoScore = 0};
        }

        private List<Frame> GetNoSparesOrStrikes()
        {
            var i = 1;
            var scores = new List<Frame>();
            while (i <11)
            {
               scores.Add(new Frame
               {
                   BowlOneScore = i == 10 ? 9 : i,
                   BowlTwoScore = 0
               });
                i++;
            }
            return scores;
        }

        [Test]
        public void should_ScoreAFramesBonusPoints_When_AllStrikes()
        {
            var frames = GetAllStrikeFrames();
            var bonusScorer = new BonusScorer();
            var result = bonusScorer.Score(frames);
            Assert.That(result[0].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[0].BonusPoints, Is.EqualTo(20));
            Assert.That(result[0].FrameScore, Is.EqualTo(30));
            Assert.That(result[7].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[7].BonusPoints, Is.EqualTo(20));
            Assert.That(result[7].FrameScore, Is.EqualTo(30));
            Assert.That(result[8].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[8].BonusPoints, Is.EqualTo(20));
            Assert.That(result[8].FrameScore, Is.EqualTo(30));
            Assert.That(result[9].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[9].BonusPoints, Is.EqualTo(20));
            Assert.That(result[9].FrameScore, Is.EqualTo(30));
        }

        [Test]
        public void should_ScoreAFramesBonusPoints_When_AllStrikeButOnlyOneBonusFrame()
        {
            var frames = GetAllStrikeFrames1Bonus();
            var bonusScorer = new BonusScorer();
            var result = bonusScorer.Score(frames);
            Assert.That(result[0].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[0].BonusPoints, Is.EqualTo(20));
            Assert.That(result[0].FrameScore, Is.EqualTo(30));
            Assert.That(result[7].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[7].BonusPoints, Is.EqualTo(20));
            Assert.That(result[7].FrameScore, Is.EqualTo(30));
            Assert.That(result[8].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[8].BonusPoints, Is.EqualTo(13));
            Assert.That(result[8].FrameScore, Is.EqualTo(23));
            Assert.That(result[9].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[9].BonusPoints, Is.EqualTo(8));
            Assert.That(result[9].FrameScore, Is.EqualTo(18));
        }

        [Test]
        public void should_ScoreAFramesBonusPoints_When_ASpare()
        {
            var frames = GetAllSpareFrames();
            var bonusScorer = new BonusScorer();
            var result = bonusScorer.Score(frames); 
            Assert.That(result[0].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[0].BonusPoints, Is.EqualTo(5));
            Assert.That(result[7].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[7].BonusPoints, Is.EqualTo(5));
            Assert.That(result[8].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[8].BonusPoints, Is.EqualTo(5));
            Assert.That(result[9].FrameBowlsTotal(), Is.EqualTo(10));
            Assert.That(result[9].BonusPoints, Is.EqualTo(5));

        }

        private List<Frame> GetAllStrikeFrames()
        {
            return new List<Frame>
            {
                StrikeFrame(), // 1
                StrikeFrame(), // 2
                StrikeFrame(), // 3
                StrikeFrame(), // 4
                StrikeFrame(), // 5
                StrikeFrame(), // 6
                StrikeFrame(), // 7
                StrikeFrame(), // 8
                StrikeFrame(), // 9
                StrikeFrameWith2Bonuses()  // 10
            };
        }

        private List<Frame> GetAllStrikeFrames1Bonus()
        {
            return new List<Frame>
            {
                StrikeFrame(), // 1
                StrikeFrame(), // 2
                StrikeFrame(), // 3
                StrikeFrame(), // 4
                StrikeFrame(), // 5
                StrikeFrame(), // 6
                StrikeFrame(), // 7
                StrikeFrame(), // 8
                StrikeFrame(), // 9
                StrikeFrameWith1Bonus()  // 10
            };
        }

        private Frame StrikeFrame()
        {
            return new Frame
            {
                BowlOneScore = 10,
            };
        }

        private Frame StrikeFrameWith2Bonuses()
        {
            return new Frame
            {
                BowlOneScore = 10,
                BonusFrameOne = new Frame
                {
                    BowlOneScore = 10
                },
                BonusFrameTwo = new Frame
                {
                    BowlOneScore = 10
                }
            };
        }

        private Frame StrikeFrameWith1Bonus()
        {
            return new Frame
            {
                BowlOneScore = 10,
                BonusFrameOne = new Frame
                {
                    BowlOneScore = 3,
                    BowlTwoScore = 5
                }
            };
        }


        private List<Frame> GetAllSpareFrames()
        {
            return new List<Frame>
            {
                SpareFrame(), // 1
                SpareFrame(), // 2
                SpareFrame(), // 3
                SpareFrame(), // 4
                SpareFrame(), // 5
                SpareFrame(), // 6
                SpareFrame(), // 7
                SpareFrame(), // 8
                SpareFrame(), // 9
                SpareWith1Bonus() // 10
            };
        }

        private Frame SpareFrame()
        {
            return new Frame
            {
                BowlOneScore = 5,
                BowlTwoScore = 5
            };
        }

        private Frame SpareWith1Bonus()
        {
            return new Frame
            {
                BowlOneScore = 5,
                BowlTwoScore = 5,
                BonusFrameOne = new Frame
                {
                    BowlOneScore = 5
                }
            };
        }
    }
}
