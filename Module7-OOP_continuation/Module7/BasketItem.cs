using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class BasketItem
    {
        public Product Product { get; set; }
		public decimal Price
		{
			get
			{
				return Product.Price;
			}
		}

		public int Quantity { get; private set; }
		
		public decimal ItemTax
		{
			get
			{
				return (Price * (Product.CategoryType.TaxPercentage / 100));
			}
		}

		public decimal TaxTotal
		{
			get
			{
				return ItemTax * Quantity;
			}
		}

		public decimal BasketTotal
		{
			get
			{
				return ((Quantity * Price) + TaxTotal);
			}
		}

		public BasketItem(int quantity, Product product)
		{
			Product = product;
			Quantity = quantity;
		}
	}
}
