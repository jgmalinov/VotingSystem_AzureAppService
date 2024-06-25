using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VotingSystemWebApp.Data;
using VotingSystemWebApp.Models;

namespace VotingSystemWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private VotingSystemDbContext _context;
        public BallotBox Gerb {  get; set; }
        public BallotBox BSP { get; set; }
        public BallotBox Ataka { get; set; }
        [BindProperty]
        public string PartyVotedFor { get; set; }

        public IndexModel(ILogger<IndexModel> logger, VotingSystemDbContext context)
        {
            _logger = logger;
            _context = context;
            Gerb = (BallotBox)_context.BallotBoxes.FirstOrDefault(BallotBox => BallotBox.Id == 1);
            BSP = (BallotBox)_context.BallotBoxes.FirstOrDefault(BallotBox => BallotBox.Id == 2);
            Ataka = (BallotBox)_context.BallotBoxes.FirstOrDefault(BallotBox => BallotBox.Id == 3);
        }

        public void OnGet()
        {
            return;
        }

        public void OnPost() 
        {
            switch(PartyVotedFor)
            {
                case "GERB":
                    Gerb.Votes += 1;
                    break;
                case "BSP":
                    BSP.Votes += 1;
                    break;
                case "Ataka":
                    Ataka.Votes += 1;
                    break;
            }
            _context.SaveChanges();
        }
    }
}
