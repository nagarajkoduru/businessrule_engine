using BusinessRuleEngine.RuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Handlers
{
    interface IHandler<T>
    {
        PaymentResult HandleOrder(T data);
    }
}
