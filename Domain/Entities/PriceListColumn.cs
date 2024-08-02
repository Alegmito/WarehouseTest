using Domain.Enums;

namespace Domain.Entities
{

  public class PriceListColumn : BaseEntity<Guid>
  {
    public string Name { get; set; }
    public PriceListColValType PriceListColValType { get; set; }

        public List<PriceListColValue> PriceListColValues { get; set; } = new();
    public PriceList PriceList { get; set; }
  }
  
}