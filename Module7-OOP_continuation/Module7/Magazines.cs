using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class Magazines : Category
    {
        private const decimal _TaxPercentage = 20M;

        private const string _ItemType = "Magazines";
        public Magazines() : base(_TaxPercentage, _ItemType)
        {
        }       
    }
}
