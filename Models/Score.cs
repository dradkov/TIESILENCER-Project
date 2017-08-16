using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    using System.ComponentModel.DataAnnotations.Schema;

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

       
       [ForeignKey("PlayerDb")]
        public int PlayerDbId { get; set; }

        public PlayerDbEntity PlayerDb { get; set; }
    }
}
