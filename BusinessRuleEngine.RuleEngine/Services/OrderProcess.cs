using BusinessRuleEngine.RuleEngine.Models;
using BusinessRuleEngine.RuleEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Services
{
    public abstract class OrderProcess<TModel> : IOrderProcess 
    {
        public PaymentResult ProcessOrder<T>(T model)
        {
            return ProcessOrder((TModel)(object)model);
        }

        protected abstract PaymentResult ProcessOrder(TModel model);


    }
}
