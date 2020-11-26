using BusinessRuleEngine.RuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Services
{
    public class SubscriptionProcessor : OrderProcess<Subscription>
    {
        protected override PaymentResult ProcessOrder(Subscription model)
        {
            PaymentResult result = null;
            // If Payment is done then activate the membership and sent a mail to user.
            if (!string.IsNullOrEmpty(model.MemberName))
            {
                switch (model.SubscriptionType)
                {
                    case Models.Constants.SubscriptionType.ACTIVATION:
                        result = HandleNewActivation(model);
                        break;
                    case Models.Constants.SubscriptionType.UPGRADE:
                        result = Upgrade(model);
                        break;
                    default:
                        break;
                }

            }
            else
            {
                throw new InvalidOperationException();
            }
            return result; 
        }

        private PaymentResult HandleNewActivation(Subscription data)
        {
            // to do Acutal logic to send an email on activation 
            return new PaymentResult
            {
                IsSuccess = true,
                Message = "Activation Completed and Sent an email to Customer"
            };
        }

        private PaymentResult Upgrade(Subscription data)
        {
            // to do Acutal logic to send an email on activation 
            return new PaymentResult
            {
                IsSuccess = true,
                Message = "upgrade Completed and Sent an email to Customer"
            };
        }
    }
}
