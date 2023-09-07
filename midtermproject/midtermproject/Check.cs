using System.Text.RegularExpressions;

namespace midtermproject
{
    public class Check: Payment, IPayment
    {
        //For check, get the check number.
        Regex CheckNumber = new Regex(@"^[1-9][0-9]{8}$&^[1-9][0-9]{11}&^[1-9][0-9]{3,4,5}$");
       public string Checknum(string checkNumber)
        {
            Match match = CheckNumber.Match(checkNumber);
            if (match.Success)
            {
                return checkNumber;
            }
            else return string.Empty;
        }

        public void CompletePayment()
        {
            throw new NotImplementedException();
        }

        public void GatherPaymentDetails()
        {
            throw new NotImplementedException();
        }

        public Check(decimal salesTaxRate, PaymentType type,string checkNumber): base(salesTaxRate, type)
        {
            this.Checknum(checkNumber);
            this.SalesTaxRate = salesTaxRate;
            this.Type = type;
        }
    }
}
