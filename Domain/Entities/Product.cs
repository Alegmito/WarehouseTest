using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class Product: BaseEntity<Guid>
  {
    public List<PriceList> PriceLists { get; set; }
    public List<PriceListColValue> priceListColumnValues { get; set; }

    public string Name {  get; set; }
    public string Code { get; set; }
  }
}
