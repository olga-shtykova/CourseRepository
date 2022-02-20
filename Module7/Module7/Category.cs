using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class Category
    {
		public decimal TaxPercentage { get; set; }
		public string CategoryType { get; set; }
		public Category(decimal taxPercentage, string catgeoryType)
		{
			TaxPercentage = taxPercentage;
			CategoryType = catgeoryType;
		}		
	}
}
