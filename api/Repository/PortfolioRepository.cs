using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        public ApplicationDBContext _context { get; set; }
        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetUserPortfolioAsync(AppUser user)
        {
            return await _context.Portfolios
                .Where(p => p.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.Stock.Id,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    MarketCap = stock.Stock.MarketCap,
                    Purchase = stock.Stock.Purchase,
                    LastDividend = stock.Stock.LastDividend,
                    Industry = stock.Stock.Industry,
                })
                .ToListAsync();
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeletePortfolioEntryAsync(AppUser user, string symbol)
        {
            var portfolioEntry = await _context.Portfolios
                .FirstOrDefaultAsync(p => p.AppUserId == user.Id && p.Stock.Symbol == symbol);
            if (portfolioEntry == null)
                return null;

            _context.Portfolios.Remove(portfolioEntry);
            await _context.SaveChangesAsync();
            return portfolioEntry;
        }
    }
}