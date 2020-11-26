using BusinessRuleEngine.RuleEngine.Factory;
using BusinessRuleEngine.RuleEngine.Interfaces;
using BusinessRuleEngine.RuleEngine.Tests.Fixtures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Tests.Services
{
   
    public class PhysicalProductTest : OrderProcessTestFixture
    {
        IOrderProcess OrderProcessHandler;

        [Test]
        public void When_I_Pass_Valid_PhysicalProduct_Order_it_should_process()
        {
            //arrange
            var physcialProduct = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.PRODUCT_PHYSICAL).FirstOrDefault();
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.PHYSICAL_PRODUCT);
            
            //act
            var result = OrderProcessHandler.ProcessOrder(physcialProduct);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Packing slip created for physical product", result.Message);


        }

        [Test]
        public void ProcessOrder_PhysicalProduct_Name_Empty_Test()
        {

            //arrange
            var product = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.PRODUCT_PHYSICAL).FirstOrDefault();
            product.Name = string.Empty;
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.PHYSICAL_PRODUCT);

            //assert
            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcessHandler.ProcessOrder(product));
            Assert.That(ex.Message, Is.EqualTo("Product Name is missing"));

        }
    }
}
