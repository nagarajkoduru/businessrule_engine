using BusinessRuleEngine.RuleEngine.Interfaces;
using BusinessRuleEngine.RuleEngine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Tests.Fixtures
{
    [TestFixture]
    public class OrderProcessTestFixture
    {
        List<ProductDetails> products;
        List<Subscription> Members; 
        public OrderProcessTestFixture()
        {
            products = GetProducts(); 

        }



        public List<ProductDetails> GetProducts()
        {
            List<ProductDetails> details = new List<ProductDetails>();
            details.Add(new ProductDetails
            {
                ProductType = Models.Constants.ProductTypes.BOOK,
                Name= "Book Test 1",
                Price = 150, 
                Quantity =5

            });

            details.Add(new ProductDetails
            {
                ProductType = Models.Constants.ProductTypes.VIDEO,
                Name = "Video Test 1",
                Description = "learning to ski",
                Price = 150,
                Quantity = 5

            });

            details.Add(new ProductDetails
            {
                ProductType = Models.Constants.ProductTypes.PRODUCT_PHYSICAL,
                AgentName ="Agent 001",
                Commission = 10, 
                Name = "Physical Product Test 1",
                Description = "learning to ski",
                Price = 150,
                Quantity = 5

            });
            details.Add(new ProductDetails
            {
                ProductType = Models.Constants.ProductTypes.BOOKORPHYSICAL,
                AgentName = "Agent 001",
                Name = "Physical or booking Product Test 1",
                Price = 150,
                Quantity = 5
            });


            return details;
        }

        public List<Subscription> GetMembers()
        {
            List<Subscription> details = new List<Subscription>();
            details.Add(new Subscription
            {
                MemberName = "User 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                SubscriptionType = Models.Constants.SubscriptionType.ACTIVATION
            });

            details.Add(new Subscription
            {
                MemberName = "User 01",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                SubscriptionType = Models.Constants.SubscriptionType.UPGRADE
            });

            return details;
        }

    }
}
