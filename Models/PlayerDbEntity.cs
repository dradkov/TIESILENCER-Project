using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Exceptions;
using TheTieSilincer.Exceptions;

namespace Models
{
    public class PlayerDbEntity
    {
        private string name;
        private string password;

        public PlayerDbEntity()
        {
            this.Scores = new List<Score>();
        }
        public PlayerDbEntity(string name , string password)
        {
             Name = name;
           
            Password = password;

            this.Scores = new List<Score>();
        }

        [Key]
        public int PlayerId { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 6  )
                    throw new InvalidNameLengthException();

                this.name = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (value.Length < 6)
                    throw new InvalidPasswordLengthException();

                if (!value.Any(x => char.IsDigit(x)))
                    throw new InvalidPasswordDigitException(); 

                this.password = value;
            }
        }

        public List<Score> Scores { get; set; }




    }
}
