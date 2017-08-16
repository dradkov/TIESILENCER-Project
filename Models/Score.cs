using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Score
    {
        public Score()
        {
            
        }
        public Score(int points)
        {
            this.Points = points;
        }
        public int ScoreId { get; set; }

        public int Points { get; set; }

        public int PlayerId { get; set; }

        public PlayerDbEntity Player { get; set; }
    }
}
