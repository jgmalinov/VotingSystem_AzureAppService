using Microsoft.EntityFrameworkCore;
using VotingSystemWebApp.Models;

namespace VotingSystemWebApp.Data
{
    public class VotingSystemDbContext: DbContext
    {
        public DbSet<BallotBox> BallotBoxes { get; set; }
        public VotingSystemDbContext(DbContextOptions<VotingSystemDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=VotingSystem.db");
        }
    }

    
}
