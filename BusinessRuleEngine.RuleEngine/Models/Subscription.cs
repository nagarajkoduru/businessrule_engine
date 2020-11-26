using BusinessRuleEngine.RuleEngine.Models.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Models
{
    /// <summary>
    /// Represents Membership
    /// </summary>
    public class Subscription
    {
        public string MemberName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}
