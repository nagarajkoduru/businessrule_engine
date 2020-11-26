using BusinessRuleEngine.RuleEngine.Models;
using BusinessRuleEngine.RuleEngine.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRuleEngine.UI
{
    public static class SampleData
    {


        private static List<ProductDetails> GetProducts()
        {
            List<ProductDetails> details = new List<ProductDetails>();
            details.Add(new ProductDetails
            {
                ProductType = RuleEngine.Models.Constants.ProductTypes.BOOK,
                Name = "Book Test 1",
                Price = 150,
                Quantity = 5,
                RoyaltyPrice=10,
                Commission=15,
                Description ="Test Description"

            });

            details.Add(new ProductDetails
            {
                ProductType = RuleEngine.Models.Constants.ProductTypes.VIDEO,
                Name = "Video Test 1",
                Description = "learning to ski",
                Price = 150,
                Quantity = 5,
                Commission = 15,

            });

            details.Add(new ProductDetails
            {
                ProductType = RuleEngine.Models.Constants.ProductTypes.PRODUCT_PHYSICAL,
                AgentName = "Agent 001",
                Commission = 10,
                Name = "Physical Product Test 1",
                Description = "learning to ski",
                Price = 150,
                Quantity = 5

            });
            details.Add(new ProductDetails
            {
                ProductType = RuleEngine.Models.Constants.ProductTypes.BOOKORPHYSICAL,
                AgentName = "Agent 001",
                Name = "Physical or booking Product Test 1",
                Price = 150,
                Quantity = 5
            });


            return details;
        }

        private static List<Subscription> GetMembers()
        {
            List<Subscription> details = new List<Subscription>();
            details.Add(new Subscription
            {
                MemberName = "User 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                SubscriptionType = RuleEngine.Models.Constants.SubscriptionType.ACTIVATION
            });

            details.Add(new Subscription
            {
                MemberName = "User 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                SubscriptionType = RuleEngine.Models.Constants.SubscriptionType.UPGRADE
            });

            return details;
        }


        public static object GetSampleDataForOrder(PaymentType options, int subscription=0)
        {
            object data=null;

            switch (options)
            {
                case PaymentType.PHYSICAL_PRODUCT:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.PRODUCT_PHYSICAL).FirstOrDefault();
                    break;
                case PaymentType.BOOK:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.BOOK).FirstOrDefault();
                    break;
                case PaymentType.MEMBERSHIP:
                    data = GetMembers().Where(x => x.SubscriptionType == (SubscriptionType)subscription).FirstOrDefault();
                    break;
                case PaymentType.BOOKORPHYSICAL:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.BOOKORPHYSICAL).FirstOrDefault();
                    break;
                case PaymentType.VIDEO:
                    data = GetProducts().Where(x => x.ProductType == ProductTypes.VIDEO).FirstOrDefault();
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }
    }

}
