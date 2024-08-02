using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.DTO
{
    public class PriceListColValueDTO
    {
        public string Name { get; set; }
        public PriceListColValType PriceListColValType { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<PriceListColValue, PriceListColValueDTO>();
            }
        }
    }
}