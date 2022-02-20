using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class Literature : Category
    {
        private const decimal _TaxPercentage = 0M;

        private const string _ItemType = "Books";
        public Literature() : base(_TaxPercentage, _ItemType)
        {
        }
    }
}
