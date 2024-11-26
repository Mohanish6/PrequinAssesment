using InvestorCommitments.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Investor> Investors { get; set; }
    public DbSet<Commitment> Commitments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Investor>().HasData(
            new Investor { Id = 1, Name = "Investor A" },
            new Investor { Id = 2, Name = "Investor B" }
        );

        modelBuilder.Entity<Commitment>().HasData(
            new Commitment { Id = 1, InvestorId = 1, AssetClass = "Equity", Amount = 500000 },
            new Commitment { Id = 2, InvestorId = 1, AssetClass = "Debt", Amount = 500000 },
            new Commitment { Id = 3, InvestorId = 2, AssetClass = "Equity", Amount = 300000 },
            new Commitment { Id = 4, InvestorId = 2, AssetClass = "Debt", Amount = 200000 }
        );
    }
}