using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Portfolio>()
                .HasKey(p => new { p.AppUserId, p.StockId });

            modelBuilder.Entity<Portfolio>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            modelBuilder.Entity<Portfolio>()
                .HasOne(p => p.Stock)
                .WithMany(s => s.Portfolios)
                .HasForeignKey(p => p.StockId);

            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = 1,
                    Symbol = "AAPL",
                    CompanyName = "Apple Inc.",
                    Purchase = 150.00m,
                    LastDividend = 0.24m,
                    Industry = "Technology",
                    MarketCap = 2500000000000
                },
                new Stock
                {
                    Id = 2,
                    Symbol = "MSFT",
                    CompanyName = "Microsoft Corporation",
                    Purchase = 280.00m,
                    LastDividend = 0.62m,
                    Industry = "Technology",
                    MarketCap = 2100000000000
                },
                new Stock
                {
                    Id = 3,
                    Symbol = "AMZN",
                    CompanyName = "Amazon.com Inc.",
                    Purchase = 125.00m,
                    LastDividend = 0.00m,
                    Industry = "Consumer Discretionary",
                    MarketCap = 1300000000000
                },
                new Stock
                {
                    Id = 4,
                    Symbol = "TSLA",
                    CompanyName = "Tesla Inc.",
                    Purchase = 750.00m,
                    LastDividend = 0.00m,
                    Industry = "Automotive",
                    MarketCap = 900000000000
                },
                new Stock
                {
                    Id = 5,
                    Symbol = "NVDA",
                    CompanyName = "NVIDIA Corporation",
                    Purchase = 220.00m,
                    LastDividend = 0.16m,
                    Industry = "Semiconductors",
                    MarketCap = 550000000000
                }
            );

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
