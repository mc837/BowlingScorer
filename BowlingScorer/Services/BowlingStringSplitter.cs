using BowlingScorer.Services.Interfaces;

namespace BowlingScorer.Services
{
    public class BowlingStringSplitter : ISplitBowlingStrings
    {
        public string [] Split(string bowlingString)
        {
            return bowlingString?.Split('|') ?? new string[0];
        }
    }
}