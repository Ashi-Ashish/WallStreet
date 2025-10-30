using api.DTOs.Stock;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public sealed class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, StockDTO>()
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
            CreateMap<CreateStockRequestDTO, Stock>();
            CreateMap<UpdateStockRequestDTO, Stock>();
            CreateMap<FMPStock, Stock>().ForMember(
                dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.companyName)
            ).ForMember(
                dest => dest.LastDividend,
                opt => opt.MapFrom(src => (decimal)src.lastDividend)
            ).ForMember(
                dest => dest.MarketCap,
                opt => opt.MapFrom(src => src.marketCap)
            ).ForMember(
                dest => dest.Industry,
                opt => opt.MapFrom(src => src.industry)
            ).ForMember(
                dest => dest.Symbol,
                opt => opt.MapFrom(src => src.symbol)
            ).ForMember(
                dest => dest.Purchase,
                opt => opt.MapFrom(src => (decimal)src.price)
            );

        }
    }
}