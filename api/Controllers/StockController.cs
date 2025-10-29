using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Helper;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        ApplicationDBContext _context;
        IMapper _mapper;
        IStockRepository _stockRepo;

        public StockController(
            ApplicationDBContext context,
            IMapper mapper,
            IStockRepository stockRepo
        )
        {
            _context = context;
            _mapper = mapper;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepo.GetAllAsync(query);
            var stockDtos = stocks.Select(s => _mapper.Map<StockDTO>(s));
            return Ok(stockDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StockDTO>(stock));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDTO stockDto)
        {
            var stock = await _stockRepo.UpdateAsync(id, stockDto);
            if (stock == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StockDTO>(stock));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepo.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDTO stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            await _stockRepo.CreateAsync(stock);
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, _mapper.Map<StockDTO>(stock));
        }
    }
}