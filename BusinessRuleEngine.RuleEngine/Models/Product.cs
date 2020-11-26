using BusinessRuleEngine.RuleEngine.Models.Constants;

namespace BusinessRuleEngine.RuleEngine.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string ShippingAddress { get; set; }
        public ProductTypes  ProductType{ get; set; }

    }
}
