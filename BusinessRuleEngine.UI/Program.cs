using BusinessRuleEngine.RuleEngine.Factory;
using BusinessRuleEngine.RuleEngine.Interfaces;
using BusinessRuleEngine.RuleEngine.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int resultValue;
            Console.WriteLine("Order Process System \n");
            Console.WriteLine("******************************** \n");
            Console.WriteLine("1: Process Book Order\n" +
                              "2: Process Video\n" +
                              "3: Process Physical Product\n" +
                              "4: Process Physical or Book \n" +
                              "5: New Activation for Member\n"+
                              "6: Upgrade Member\n");

            Console.WriteLine("********************************");
            var getUserInput = Console.ReadLine();

            if (Int32.TryParse(getUserInput, out resultValue))
            {
                ProcessPaymentOrder(resultValue);
            }
            else
            {
                Console.WriteLine("Please enter a valid option Number!");
            }
            Console.Read();
        }

        private static void ProcessPaymentOrder(int options)
        {
            int subscription = 0; 
            var paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), options.ToString());
            if(options == 5 || options ==6)
            {
                paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), "5".ToString());
                subscription = options==5 ? 1 : 2; // assign Subscription type
            }
            IOrderProcess processor = PaymentFactory.GetOrderProcessor(paymentType);
            var data = SampleData.GetSampleDataForOrder(paymentType, subscription);
            if (processor != null)
            {
                var result = processor.ProcessOrder(data);

                Console.WriteLine($"Hanlded Order of {paymentType.ToString()} and Result is {result.Message}\n");
            }
            else
            {
                Console.WriteLine("Invalid operation");
            }
           

        }
    }
}