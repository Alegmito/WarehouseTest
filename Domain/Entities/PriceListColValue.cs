using Domain.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities
{
    public class PriceListColValue : BaseEntity<Guid>
    {
        public Product Product { get; set; }
        public PriceListColValType PriceListColValueType { get; set; }
        public PriceListColumn PriceListColumn { get; set; }
        public Guid PriceListColumnId { get; set; }
        public Guid ProductId { get; set; }
        
        public string Value { get; set; }
        public object ObjectValue
        {
            get
            {
                return PriceListColValueType switch
                {
                    PriceListColValType.Int => int.Parse(Value),
                    PriceListColValType.Text or PriceListColValType.String => Value,
                    _ => throw new NotImplementedException()
                };
            }
            set
            {
                value.ToString();
            }
        }

        public static PriceListColValue Create(PriceListColValType priceListColValType) =>
            new PriceListColValue()
            {
                Value = priceListColValType switch
                {
                    PriceListColValType.Int => "0",
                    PriceListColValType.String or PriceListColValType.Text => "",
                    _ => throw new NotImplementedException()
                },
                PriceListColValueType = priceListColValType
            };
    }

}
