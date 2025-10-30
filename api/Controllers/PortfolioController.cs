using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPortfolioRepository _portfolioRepo;
        private readonly IStockRepository _stockRepository;

        public PortfolioController(
            UserManager<AppUser> userManager,
            IPortfolioRepository portfolioRepo,
            IStockRepository stockRepository
        )
        {
            _userManager = userManager;
            _portfolioRepo = portfolioRepo;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var userEmail = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(userEmail);
            var userPortfolio = await _portfolioRepo.GetUserPortfolioAsync(appUser);
            return Ok(userPortfolio);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var userEmail = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(userEmail);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);
            if (stock == null)
            {
                return NotFound("Stock not found");
            }

            var userPortfolio = await _portfolioRepo.GetUserPortfolioAsync(appUser);
            if (userPortfolio.Any(s => s.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Stock already in portfolio");
            }

            var portfolio = new Portfolio
            {
                AppUserId = appUser.Id,
                StockId = stock.Id
            };

            await _portfolioRepo.CreateAsync(portfolio);
            if (portfolio == null)
            {
                return BadRequest("Failed to add stock to portfolio");
            }
            else
            {
                return Created();
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteStock(string symbol)
        {
            var userEmail = User.GetUserEmail();
            var appUser = await _userManager.FindByEmailAsync(userEmail);
            var userPortfolio = await _portfolioRepo.GetUserPortfolioAsync(appUser);

            var filteredStock = userPortfolio.FirstOrDefault(s => s.Symbol.ToLower() == symbol.ToLower());
            if (filteredStock == null)
            {
                return BadRequest("Stock not found in portfolio");
            }
            await _portfolioRepo.DeletePortfolioEntryAsync(appUser, filteredStock.Symbol);
            return Ok();
        }
    }
}