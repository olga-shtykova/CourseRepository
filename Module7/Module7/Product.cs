using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

		public Category CategoryType { get; set; }

		public Product(int id, string productName, decimal price, Category category)
		{
			Id = id;
			Price = price;
			CategoryType = category;
			ProductName = productName;
		}
	}
}
