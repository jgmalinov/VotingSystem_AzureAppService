using Microsoft.EntityFrameworkCore;
using VotingSystemWebApp.Data;

namespace VotingSystemWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VotingSystemDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VotingSystemDbContext>>()))
            {
                if (context == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.BallotBoxes.Any())
                {
                    return;   // DB has been seeded
                }

                context.BallotBoxes.AddRange(
                    new BallotBox
                    {
                        Id = 1,
                        Votes = 0,
                        Party = "GERB"
                    },

                    new BallotBox
                    {
                        Id = 2,
                        Votes = 0,
                        Party = "BSP"
                    },

                    new BallotBox
                    {
                        Id = 3,
                        Votes = 0,
                        Party = "Ataka"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

