using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingSystemWebApp.Models
{
    [PrimaryKey(nameof(Id))]
    public class BallotBox
    {
        public int Id { get; set; }
        public int Votes { get; set; }
        [Display(Name = "Party")]
        public string Party { get; set; }
    }
}
