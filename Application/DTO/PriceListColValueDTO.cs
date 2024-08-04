using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.DTO
{
    public class PriceListColValueDTO
    {
        public PriceListColValType PriceListColValueType { get; set; }
        public object ObjectValue { get; set; }
        public Guid PriceListColumnValueId { get; set; }
        
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<PriceListColValue, PriceListColValueDTO>()
                    .ForMember(p => p.PriceListColumnValueId, m => m.MapFrom(src => EF.Property<Guid>(src, "PriceListColumnValueId")));
            }
        }
    }
}