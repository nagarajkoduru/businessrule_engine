using BusinessRuleEngine.RuleEngine.Factory;
using BusinessRuleEngine.RuleEngine.Interfaces;
using BusinessRuleEngine.RuleEngine.Models;
using BusinessRuleEngine.RuleEngine.Models.Constants;
using BusinessRuleEngine.RuleEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Handlers
{
    public class OrderHandler : IHandler<ProductDetails>
    {
        IOrderProcess _handler = null;

        public PaymentResult HandleOrder(ProductDetails data)
        {
            _handler = GetHandlerByPaymentType(data.paymentOptions);
            var result = _handler.ProcessOrder(data);
            return result;
        }
        private IOrderProcess GetHandlerByPaymentType(PaymentType options)
        {
            IOrderProcess handler;
            handler = PaymentFactory.GetOrderProcessor(options);
            return handler;
        }
    }
}
