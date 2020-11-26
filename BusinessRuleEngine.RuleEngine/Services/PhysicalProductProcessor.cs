using BusinessRuleEngine.RuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Services
{
    class PhysicalProductProcessor : OrderProcess<ProductDetails>
    {
        protected override PaymentResult ProcessOrder(ProductDetails model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Packing slip created for physical product",
                };
            }
            else
            {
                throw new InvalidOperationException("Product Name is missing");
            }
        }
    }
}
