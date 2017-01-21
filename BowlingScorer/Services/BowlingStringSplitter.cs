namespace BowlingScorer.Services
{
    public class BowlingStringSplitter
    {
        public string [] Split(string bowlingString)
        {
            return bowlingString?.Split('|') ?? new string[0];
        }
    }
}