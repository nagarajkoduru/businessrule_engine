using BusinessRuleEngine.RuleEngine.Factory;
using BusinessRuleEngine.RuleEngine.Interfaces;
using BusinessRuleEngine.RuleEngine.Services;
using BusinessRuleEngine.RuleEngine.Tests.Fixtures;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Tests.Services
{
    public class BookProcessorTest : OrderProcessTestFixture
    {
        IOrderProcess OrderProcessHandler;

        [Test]
        public void When_I_Pass_Valid_BookOrder_it_should_process()
        {
            //arrange
            var book = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.BOOK).FirstOrDefault();
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.BOOK);
            double royaltyAmount = book.Price * book.Quantity * book.Commission;
            string message = "Royalty slip created with Amount - " + royaltyAmount;
            
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
            var book = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.BOOK).FirstOrDefault();
            book.Name = string.Empty;
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.BOOK);
            double royaltyAmount = book.Price * book.Quantity * book.Commission;

            //assert
            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcessHandler.ProcessOrder(book));
            Assert.That(ex.Message, Is.EqualTo("Book Name is missing"));

        }
    }
}
