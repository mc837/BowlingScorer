using System.Collections.Generic;
using System.Linq;

namespace BowlingScorer.Models
{
    public class Game
    {
        public List<Frame> Frames { get; set; }

        public int Score()
        {
            return Frames.Sum(f => f.FrameScore());
        }
    }
}