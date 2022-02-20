using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class Basket
    {
		public List<BasketItem> BasketItems { get; set; }

		public Basket()
		{
			BasketItems = new List<BasketItem>();
		}

		public decimal TotalAmountOfItems
		{
			get
			{
				return BasketItems.Sum(bi => bi.BasketTotal);
			}
		}

		public void AddItemToBasket(int productId, string productName, string itemType, int quantity, decimal price)
		{
			var basketItem = GetItem(productId, productName, itemType, quantity, price);
			if (basketItem != null)
			{
				BasketItems.Add(basketItem);
			}
		}

		public void RemoveItemFromBasket(int productId)
		{
			var index = BasketItems.FindIndex(item => item.Product.Id == productId);
			if (index == -1)
            {
				throw new InvalidOperationException("There is no such item in the basket.");
			}				

			BasketItems.RemoveAt(index);
		}

		private static BasketItem GetItem(int productId, string productName, string itemType, int quantity, decimal price)
		{
			var category = GetCategories(itemType);			
			var product = new Product(productId, productName, price, category);

			return new BasketItem(quantity, product);
		}
				
		private static Category GetCategories(string itemType)
        {
			Category category = null;

			if (itemType.ToLowerInvariant() == "Literature")
			{
				category = new Literature();
			}
			else if (itemType.ToLowerInvariant() == "Magazines")
			{
				category = new Magazines();
			}
			else
			{
				throw new ArgumentException("There is no such category.");
			}

			return category;
        }
    }
}
