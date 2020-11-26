using BusinessRuleEngine.RuleEngine.Interfaces;
using BusinessRuleEngine.RuleEngine.Models.Constants;
using BusinessRuleEngine.RuleEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Factory
{
    public class PaymentFactory
    {
        public static IOrderProcess GetOrderProcessor(PaymentType type)
        {
            IOrderProcess _processOrder=null;
            switch (type)
            {
                case PaymentType.PHYSICAL_PRODUCT:
                    _processOrder = new PhysicalProductProcessor();
                    break;
                case PaymentType.BOOK:
                    _processOrder = new BookProcessor();
                    break;
                case PaymentType.MEMBERSHIP:
                    _processOrder = new SubscriptionProcessor();
                    break;
                case PaymentType.BOOKORPHYSICAL:
                    _processOrder = new PhysicalOrBookProcessor();
                    break;
                case PaymentType.VIDEO:
                    _processOrder = new VideoProcesssor();
                    break;
                default:
                    break;
            }
            return _processOrder;
        }
    }

    
}
