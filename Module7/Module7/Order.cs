using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class Order<TDelivery> where TDelivery : Delivery
    {               
        public string OrderNumber { get; }

        public string Description { get; }

        public decimal Price { get; }

        public List<Product> Products { get; set; }

        public TDelivery Delivery { get; set; }

        public Order(string orderNumber, string description, decimal amount, List<Product> products)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException(nameof(orderNumber));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException(nameof(description));

            if (products == null)
                throw new ArgumentNullException(nameof(products));

            OrderNumber = orderNumber;
            Description = description;
            Price = amount;
            Products = products;
        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
    }
}
