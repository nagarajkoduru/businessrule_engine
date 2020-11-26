using BusinessRuleEngine.RuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Interfaces
{
    public interface IOrderProcess
    {
        PaymentResult ProcessOrder<T>(T model);
    }
}
