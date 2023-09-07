using System.Text.RegularExpressions;

namespace midtermproject
{
    public class Credit: Payment, IPayment
    {
        public string CardNumber { get; set; }
        public string CardExpo { get; set; }
        public string CVV { get; set; }

        //For credit, get the credit card number, expiration, and CVV.
        Regex card = new Regex(@"^[1-9]{1}[0-9]{15}");
        Regex expiration = new Regex(@"^[1-9]{1}[0-9]{3}/([0]{1}[1-9]{1}|[1]{1}[0-2]{1})");
        Regex cvvNum = new Regex(@"^[0-9]{3,4}$");
        public void CardNumberMatch(string cardNumber)
        {
            Match match = card.Match(cardNumber);

            
            if (match.Success)
            {
                this.CardNumber = cardNumber;
            }
            else
            {
                CardNumber = "-1";
            }
        }
        public void ExpirationMatch(string expirationDate)
        {
            Match match = expiration.Match(expirationDate);
            if (match.Success)
            {
                CardExpo = expirationDate;
            }
            else
            {
                CardExpo = "-1";
            }
        }
        public void CVVMatch(string cvv)
        {
            Match match = cvvNum.Match(cvv);

            if (match.Success)
            {
                CVV = cvv;
            }
            else
            {
                CVV = "-1";
            }
        }

        public void CompletePayment()
        {
            throw new NotImplementedException();
        }

        public void GatherPaymentDetails()
        {
            throw new NotImplementedException();
        }

        public Credit(decimal salesTaxRate, PaymentType type): base(salesTaxRate, type)
        { 
            this.SalesTaxRate = salesTaxRate;
            this.Type = type;
        }
    }
}
