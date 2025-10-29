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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Title = "Strong Q2 Results",
                    Content = "Apple posted another record quarter. Holding long-term.",
                    CreatedOn = new DateTime(2024, 7, 31),
                    StockId = 1
                },
                new Comment
                {
                    Id = 2,
                    Title = "Cloud Keeps Growing",
                    Content = "Azure growth surprised to the upside; adding to my MSFT position.",
                    CreatedOn = new DateTime(2024, 8, 15),
                    StockId = 2
                },
                new Comment
                {
                    Id = 3,
                    Title = "Competition Heating Up",
                    Content = "Amazon retail margins are tight, but AWS remains a cash cow.",
                    CreatedOn = new DateTime(2024, 8, 20),
                    StockId = 3
                },
                new Comment
                {
                    Id = 4,
                    Title = "Valuation Check",
                    Content = "Tesla still feels pricey—waiting for a pullback before buying more.",
                    CreatedOn = new DateTime(2024, 9, 5),
                    StockId = 4
                },
                new Comment
                {
                    Id = 5,
                    Title = "AI Tailwinds",
                    Content = "NVIDIA guidance keeps climbing; bullish on continued GPU demand.",
                    CreatedOn = new DateTime(2024, 9, 12),
                    StockId = 5
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
