using AutoMapper;
using Domain.Entities;

namespace Application.DTO
{
    public class ProductDTO : BaseDTO<Guid>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<PriceListColValueDTO> PriceListColumnValues { get; set; } = new();

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Product, ProductDTO>();
            }
        }
    }
}