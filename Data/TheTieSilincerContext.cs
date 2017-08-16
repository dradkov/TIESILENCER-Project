using Models;

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TheTieSilincerContext : DbContext
    {
        public DbSet<PlayerDbEntity> Players { get; set; }
        public DbSet<Score> Scores { get; set; }


        public TheTieSilincerContext()
            : base("name=TheTieSilincerContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
