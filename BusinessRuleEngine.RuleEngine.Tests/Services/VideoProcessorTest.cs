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

    public class VideoProcessorTest : OrderProcessTestFixture
    {
        IOrderProcess OrderProcessHandler;

        [Test]
        public void When_I_Pass_Valid_VideoOrder_it_should_processandAddFreeOrder()
        {
            //arrange
            var video = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.VIDEO).FirstOrDefault();
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.VIDEO);
            video.Description = "learning to ski";
            video.PackingDate = DateTime.Today;

            //act
            var result = OrderProcessHandler.ProcessOrder(video);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Added First Aid video to the packing slip.", result.Message);


        }

        [Test]
        public void When_I_Pass_Valid_VideoOrder_it_should_process()
        {
            //arrange
            var video = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.VIDEO).FirstOrDefault();
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.VIDEO);
            video.Description = "TestVideos";
            video.PackingDate = DateTime.Today;

            //act
            var result = OrderProcessHandler.ProcessOrder(video);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Generated Packing slip", result.Message);


        }

        [Test]
        public void ProcessOrder_BookName_Empty_Test()
        {

            //arrange
            var video = GetProducts().Where(x => x.ProductType == Models.Constants.ProductTypes.VIDEO).FirstOrDefault();
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.VIDEO);
            video.Description = string.Empty;
            OrderProcessHandler = PaymentFactory.GetOrderProcessor(Models.Constants.PaymentType.VIDEO);

            var ex = Assert.Throws<InvalidOperationException>(() => OrderProcessHandler.ProcessOrder(video));
            Assert.That(ex.Message, Is.EqualTo("Video Descrption is missing"));

        }
    }
}
