
namespace midtermproject
{
    public class Payment
    {
        public decimal Total { get; set; }

        
        public decimal SalesTax { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal SalesTaxRate { get; set; }

        public PaymentType Type { get; set; }

        public Payment(decimal salesTaxRate, PaymentType type)
        {
            this.SalesTaxRate = salesTaxRate;
            this.Type = type;
        }

       

        public void SetItemDetails(decimal price, int quantity)
        {
            SubTotal += price * quantity;
        }

        public void CalculateSalesTax()
        {
            SalesTax = SubTotal * SalesTaxRate;
        }

        public void CalculateGrandTotal()
        {
            GrandTotal = SubTotal + SalesTax;
        }
    }
}
