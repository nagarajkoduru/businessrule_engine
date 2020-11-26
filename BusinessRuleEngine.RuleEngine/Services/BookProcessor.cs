using BusinessRuleEngine.RuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Services
{
    public class BookProcessor : OrderProcess<ProductDetails>
    {
        protected override PaymentResult ProcessOrder(ProductDetails model)
        {
            model.RoyaltyPrice = model.Quantity * model.Price * model.Commission;

            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentResult
                {
                    IsSuccess= true,
                    Message = "Royalty slip created with Amount - " + model.RoyaltyPrice,
                };
            }
            else
            {
                throw new InvalidOperationException("Book Name is missing");
            }
        }
    }
}
