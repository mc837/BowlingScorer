namespace BowlingScorer.Models
{
    public class Frame
    {
        public int BowlOneScore { get; set; }
        public int BowlTwoScore { get; set; }
        public Frame BonusFrameOne { get; set; }
        public Frame BonusFrameTwo { get; set; }
        public int BonusPoints { get; set; }

        public int FrameBowlsTotal()
        {
            return BowlOneScore + BowlTwoScore;
        }

        public string FrameScoreText()
        {
            if (BowlOneScore == 10)
            {
                return "Strike";
            }
            return FrameBowlsTotal() == 10 ? "Spare" : FrameBowlsTotal().ToString();
        }

        public bool IsStrike()
        {
            return BowlOneScore == 10;
        }

        public bool IsSpare()
        {
            return BowlOneScore != 10 && FrameBowlsTotal() == 10;
        }

        public int FrameScore()
        {
            return FrameBowlsTotal() + BonusPoints;
        }
    }
}