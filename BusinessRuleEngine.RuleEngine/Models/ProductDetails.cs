using BusinessRuleEngine.RuleEngine.Models.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Models
{
    /// <summary>
    /// Represents book model 
    /// </summary>
    public class ProductDetails : Product
    {
        public double Commission { get; set; }
        public double RoyaltyPrice { get; set; }
        public string AgentName { get; set; }
        public DateTime PackingDate { get; set; }
        public PaymentType paymentOptions { get; set; }
    }
}
