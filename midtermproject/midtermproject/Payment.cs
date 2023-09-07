
namespace midtermproject
{
    public abstract class Payment
    {
        public decimal Total { get; set; }

        public abstract void CompletePayment();

        public abstract void GatherPaymentDetails();
        public decimal SalesTax { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal GrandTotal { get; private set; }
        public PaymentType Type { get; set; }

        public Payment(decimal salesTaxRate, PaymentType type)
        {
            SalesTax = salesTaxRate;
            Type = type;
        }

        public void SetItemDetails(decimal price, int quantity)
        {
            SubTotal += price * quantity;
        }

        public void CalculateSalesTax
    }
}
