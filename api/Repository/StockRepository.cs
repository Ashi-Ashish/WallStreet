using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Helper;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject? query)
        {
            var stocks = _context.Stocks.Include(s => s.Comments).AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Symbol))
                {
                    stocks = stocks.Where(s => s.Symbol == query.Symbol);
                }

                if (!string.IsNullOrEmpty(query.CompanyName))
                {
                    stocks = stocks.Where(s => s.CompanyName == query.CompanyName);
                }

                if (!string.IsNullOrEmpty(query.SortBy))
                {
                    switch (query.SortBy.ToLower())
                    {
                        case "symbol":
                            stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                            break;
                        case "companyname":
                            stocks = query.IsDescending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName);
                            break;
                        case "marketcap":
                            stocks = query.IsDescending ? stocks.OrderByDescending(s => s.MarketCap) : stocks.OrderBy(s => s.MarketCap);
                            break;
                        default:
                            break;
                    }
                }

                var skipNumber = (query.PageNumber - 1) * query.PageSize;

                if (query.PageNumber > 0 && query.PageSize > 0)
                {
                    stocks = stocks
                        .Skip(skipNumber)
                        .Take(query.PageSize);
                }
            }

            return await stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDTO stockDto)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return null;
            }

            stock.Symbol = stockDto.Symbol;
            stock.CompanyName = stockDto.CompanyName;
            stock.Purchase = stockDto.Purchase;
            stock.LastDividend = stockDto.LastDividend;
            stock.Industry = stockDto.Industry;
            stock.MarketCap = stockDto.MarketCap;

            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return null;
            }

            stock.Comments.Clear();
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> IsStockExistsAsync(int id)
        {
            return await _context.Stocks.AnyAsync(s => s.Id == id);
        }
    }
}