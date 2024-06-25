using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VotingSystemWebApp.Data;
using VotingSystemWebApp.Models;

namespace VotingSystemWebApp.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly VotingSystemWebApp.Data.VotingSystemDbContext _context;

        public ResultsModel(VotingSystemWebApp.Data.VotingSystemDbContext context)
        {
            _context = context;
        }

        public IList<BallotBox> BallotBox { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BallotBoxes != null)
            {
                BallotBox = await _context.BallotBoxes.ToListAsync();
            }
        }
    }
}
