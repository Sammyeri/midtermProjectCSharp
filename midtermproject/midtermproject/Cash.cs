﻿

namespace midtermproject
{
    public class Cash : Payment, IPayment
    {
        public decimal Change { get; set; }
        public decimal AmountPaid { get; set; }

        public Cash(decimal salesTaxRate, PaymentType type, decimal total): base(salesTaxRate, type)
        {
            this.Total = total;
            this.SalesTaxRate = salesTaxRate;
            this.Type = type;
        }

        public void CompletePayment()
        {
            Console.WriteLine($"Your change is {this.Change}");
        }
       public void CalculateChange()
        {

        }
        public void GatherPaymentDetails()
        {
            while (true)
            {
                Console.WriteLine("Please enter payment amount: ");
                string paymentAmount = Console.ReadLine();

                bool succededPayment = decimal.TryParse(paymentAmount, out decimal amountGiven);

                if(paymentAmount.Trim().ToLower() == "q" || paymentAmount.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Returning to payment selection");
                    Change = -1;
                    break;
                }
                else if (succededPayment && amountGiven >= this.Total)
                {
                    this.AmountPaid = amountGiven;
                    this.Change = amountGiven - this.Total;
                    break;
                }
                else
                {
                    Console.WriteLine($"Sorry, {paymentAmount} is not enough to cover {Total}");
                }
            }
        }
    }
}
