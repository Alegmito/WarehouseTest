using Domain.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities
{
  public interface IPriceListColValue<T>
  {
    T Value { get; set; } 
  }

  public abstract class PriceListColValue : BaseEntity<Guid>
  {
    public Product Product { get; set; }
    public PriceListColumn PriceListColumn { get; set; }

    public static PriceListColValue Create(PriceListColValType priceListColValType) =>
      priceListColValType switch
      {
        PriceListColValType.Text => new PriceListColValueText() { Value = ""},
        PriceListColValType.String => new PriceListColValueString() { Value = ""},
        PriceListColValType.Int => new PriceListColValueInt() { Value = 0 },
        _ => throw new NotImplementedException(),
      };
  }

  public class PriceListColValueInt : PriceListColValue, IPriceListColValue<int>
  {
    public int Value { get; set; }
  }
  
  public class PriceListColValueString: PriceListColValue, IPriceListColValue<string>
  {
    public string Value { get; set; }
  }

  public class PriceListColValueText : PriceListColValue, IPriceListColValue<string>
  {
    public string Value { get; set; }
  }
}