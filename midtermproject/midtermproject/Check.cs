using System.Text.RegularExpressions;

namespace midtermproject
{
   
    public class Check: Payment, IPayment
    {
        public string CheckNumber { get; set; }
        //For check, get the check number.
        Regex MatchNumber = new Regex(@"^[1-9][0-9]+");
       public void Checknum(string checkNumber)
        {
            Match match = MatchNumber.Match(checkNumber);
            

            if (match.Success )
            {
                this.CheckNumber = checkNumber;
                    
            }
            else
            {
                CheckNumber = "-1";
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

        public Check(decimal salesTaxRate, PaymentType type): base(salesTaxRate, type)
        { 
            this.SalesTaxRate = salesTaxRate;
            this.Type = type;
        }
    }
}
