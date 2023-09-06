
namespace midtermproject
{
    public abstract class Payment
    {
        public decimal Total { get; set; }

        public abstract void CompletePayment();

        public abstract void GatherPaymentDetails();
    }
}
