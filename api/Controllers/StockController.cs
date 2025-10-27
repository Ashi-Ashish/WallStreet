using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        ApplicationDBContext _context;
        IMapper _mapper;

        public StockController(
            ApplicationDBContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
                .Select(s => _mapper.Map<StockDTO>(s));

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StockDTO>(stock));
        }
    }
}