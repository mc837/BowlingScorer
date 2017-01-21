namespace BowlingScorer.Models
{
    public class Frame
    {
        public int BowlOneScore { get; set; }
        public int BowlTwoScore { get; set; }
        public int BowlTotal()
        {
            return BowlOneScore + BowlTwoScore;
        }

        public string FrameScoreText()
        {
            if (BowlOneScore == 10)
            {
                return "Strike";
            }
            return BowlTotal() == 10 ? "Spare" : BowlTotal().ToString();
        }
    }
}