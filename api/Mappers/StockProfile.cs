using api.DTOs.Stock;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public sealed class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, StockDTO>();
        }
    }
}