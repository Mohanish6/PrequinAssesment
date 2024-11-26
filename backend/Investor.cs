using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestorCommitments.Models
{
    public class Investor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Commitment> Commitments { get; set; }
    }
}
