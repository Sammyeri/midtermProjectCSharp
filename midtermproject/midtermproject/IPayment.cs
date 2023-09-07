using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermproject
{
    public interface IPayment
    {
        public abstract void CompletePayment();

        public abstract void GatherPaymentDetails();
    }
}
