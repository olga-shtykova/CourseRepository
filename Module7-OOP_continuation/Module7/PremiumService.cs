using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class PremiumService<T> where T : Order<HomeDelivery>
    {
        private string _expressMethod;
       
        public string PostalService
        {
            get { return _expressMethod; }
            set
            {
                if (value == "DHL")
                {
                    _expressMethod = value;
                }
                else
                {
                    throw new ArgumentException("Invalid value supplied");
                }
            }
        }
        public T Order { get; set; }       
    }
}
