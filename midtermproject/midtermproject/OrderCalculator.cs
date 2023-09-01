using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermproject
{
    public class OrderCalculator
    {
        public decimal salesTaxRate;

        public OrderCalculator(decimal taxRate)
        {
            this.salesTaxRate = taxRate;
        }

        public void CalculateOrderTotal(Order order)
        {
            decimal subtotal = order.Product.Price * order.Quantity;
            decimal salesTax = subtotal * salesTaxRate;
            decimal grandTotal = subtotal + salesTax;

            Console.WriteLine($"Product: {order.Product.Name}");
            Console.WriteLine($"Quantity: {order.Quantity}");
            Console.WriteLine($"Subtotal: {subtotal:C2}");
            Console.WriteLine($"Sales Tax: {salesTax:C2}");
            Console.WriteLine($"Grand Total: {grandTotal:C2}");
        }
    }
}
