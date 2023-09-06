using System.Text.RegularExpressions;

namespace midtermproject
{
    public class Credit
    {
        //For credit, get the credit card number, expiration, and CVV.
        Regex card = new Regex(@"^[1-9][0-9]{3}(-[0-9]{4}){3}$");
        Regex expiration = new Regex(@"^(0[1-9]|1[0-2])\/?(([0-9]{4}|[0-9]{2})$)");
        Regex cvvNum = new Regex(@"^[0-9]{3,4}$");
        public string CardNumber(string cardNumber)
        {
            Match match = card.Match(cardNumber);
            if (match.Success)
            {
                return cardNumber;
            }
            else
            {
                return string.Empty;
            }
        }
        public string Expiration(string expirationDate)
        {
            Match match = expiration.Match(expirationDate);
            if (match.Success)
            {
                return expirationDate;
            }
            else
            {
                return string.Empty;
            }
        }
        public string CVV(string cvv)
        {
            Match match = cvvNum.Match(cvv);
            if (match.Success)
            {
                return cvv;
            }
            else
            {
                return string.Empty;
            }
        }
        public Credit(string cardNumber, string expirationDate, string cvv) 
        {
            this.CardNumber(cardNumber);
            this.Expiration(expirationDate);
            this.CVV(cvv);
        }
    }
}
