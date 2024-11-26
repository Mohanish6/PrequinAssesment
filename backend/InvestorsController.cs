using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestorCommitments.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InvestorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvestorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetInvestors()
        {
            var investors = await _context.Investors
                .Include(i => i.Commitments)
                .Select(i => new
                {
                    i.Id,
                    i.Name,
                    TotalCommitments = i.Commitments.Sum(c => c.Amount)
                })
                .ToListAsync();

            return Ok(investors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvestorDetails(int id)
        {
            var investor = await _context.Investors
                .Include(i => i.Commitments)
                .Where(i => i.Id == id)
                .Select(i => new
                {
                    i.Id,
                    i.Name,
                    Commitments = i.Commitments.Select(c => new
                    {
                        c.AssetClass,
                        c.Amount
                    })
                })
                .FirstOrDefaultAsync();

            if (investor == null) return NotFound();

            return Ok(investor);
        }

        [HttpGet("{id}/filter")]
        public async Task<ActionResult> FilterCommitments(int id, [FromQuery] string assetClass)
        {
            var commitments = await _context.Commitments
                .Where(c => c.InvestorId == id && c.AssetClass == assetClass)
                .ToListAsync();

            return Ok(commitments);
        }
    }
}
