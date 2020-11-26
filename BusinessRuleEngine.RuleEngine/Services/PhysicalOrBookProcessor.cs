using BusinessRuleEngine.RuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Services
{
        public class PhysicalOrBookProcessor : OrderProcess<ProductDetails>
    {
        protected override PaymentResult ProcessOrder(ProductDetails model)
        {
            model.Commission = (model.Quantity * model.Price) / 0.10;

            if (!string.IsNullOrEmpty(model.AgentName ))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Commision paid to agent -" + model.Commission,
                };
            }
            else
            {
                throw new InvalidOperationException("Agent Name is missing");
            }
        }
    }
}
