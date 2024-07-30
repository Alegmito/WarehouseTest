namespace Domain.Entities
{
  public interface IColumnValue<T>
  { 
    T Value { get; set; }
  }

  public abstract class PriceListColumn : BaseEntity<Guid>
  {
    public PriceList PriceList { get; set; }
    public Product Product { get; set; }
    public string Name { get; set; }
  }

  public class PriceListColumnString : PriceListColumn, IColumnValue<string>
  {
    public string Value { get; set; }
  }

  public class PriceListColumnInt : PriceListColumn, IColumnValue<int>
  {
    public int Value { get; set; }
  }
  public class PriceListColumnText: PriceListColumn, IColumnValue<string>
  {
    public string Value { get; set; }
  }
  
}