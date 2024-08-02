using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.DTO
{
    public class PriceListColumnDTO : BaseDTO<Guid>
    {
        public string Name { get; set; }
        public PriceListColValType PriceListColValType { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<PriceListColumn, PriceListColumnDTO>();
            }
        }

    }
}