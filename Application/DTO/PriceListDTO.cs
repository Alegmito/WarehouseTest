using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PriceListDTO : BaseDTO<Guid>
    {
        public string Name { get; set; }
        
        public DateTime TimeCreated { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<PriceListColumnDTO> Columns { get; set; } = new();
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<PriceList, PriceListDTO>();
            }
        }
    }
}
