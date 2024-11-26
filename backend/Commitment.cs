using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestorCommitments.Models
{
    public class Commitment
    {
        public int Id { get; set; }
        public int InvestorId { get; set; }
        public string AssetClass { get; set; }
        public decimal Amount { get; set; }
        public Investor Investor { get; set; }
    }
}
