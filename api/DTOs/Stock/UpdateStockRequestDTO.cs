using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Stock
{
    public class UpdateStockRequestDTO
    {
        [Required]
        [MaxLength(5)]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal LastDividend { get; set; }

        [Required]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(0, long.MaxValue)]
        public long MarketCap { get; set; }
    }
}