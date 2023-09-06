using System.Text.RegularExpressions;

namespace midtermproject
{
    public class Check
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
       public Check(string checkNumber)
        {
            this.Checknum(checkNumber);
        }
    }
}
