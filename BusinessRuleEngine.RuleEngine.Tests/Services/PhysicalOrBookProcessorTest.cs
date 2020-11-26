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
    public class PhysicalOrBookProcessorTest : OrderProcessTestFixture
    {
        IOrderProcess OrderProcessHandler;

        [Test]
        public void When_I_Pass_Valid_BookOrder_it_should_process()
        {
            //arrange
            var book = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.BOOKORPHYSICAL).FirstOrDefault();
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.BOOKORPHYSICAL);
            double Commission = (book.Price * book.Quantity) / 0.10 ;
            string message = "Commision paid to agent -" + Commission;

            //act
            var result = OrderProcessHandler.ProcessOrder(book);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(message, result.Message);


        }

        [Test]
        public void ProcessOrder_BookName_Empty_Test()
        {

            //arrange
            var book = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.BOOKORPHYSICAL).FirstOrDefault();
            book.AgentName = string.Empty;
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.BOOKORPHYSICAL);

            //assert
            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcessHandler.ProcessOrder(book));
            Assert.That(ex.Message, Is.EqualTo("Agent Name is missing"));

        }
    }
}
