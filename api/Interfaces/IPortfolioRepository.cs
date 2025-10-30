using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> CreateAsync(Portfolio portfolioEntry);
        Task<List<Stock>> GetUserPortfolioAsync(AppUser user);
        Task<Portfolio> DeletePortfolioEntryAsync(AppUser user, string symbol);
    }
}