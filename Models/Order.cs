using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Models {
	public class Order {
		public string OrderID { get; set; }
		public Customer Customer { get; set; }
		public List<OrderItem> Items { get; set; }
		public double Total {
			get {
				double total = 0;

				if (this.Items != null) {
					foreach (var item in this.Items)
						total += item.Product.Price * item.Quantity;
				}

				return total;
			}
		}

		public Order() { }

		public static Order CreateOrder(Customer customer, Product product, int quantity = 1) {
			var order = new Order();
			order.OrderID = Guid.NewGuid().ToString();
			order.Items = new List<OrderItem>();
			order.Customer = customer;

			var item = new OrderItem(product, quantity);
			order.Items.Add(item);

			return order;
		}

		public override string ToString() {
			return $"Order ID: {this.OrderID} \n" +
				   $"Customer: {this.Customer.FirstName} {this.Customer.LastName} \n" +
				   $"Total: {this.Total:C}";
		}

		public void SaveOrder(string directory) {
			directory = directory.Replace('/', '\\');

			if (!directory.EndsWith("\\")) {
				directory += "\\";
			}

			// Create serializer
			var serializer = new XmlSerializer(typeof(Order));

			using (var stream = new FileStream($"{directory}{this.OrderID}.xml", FileMode.Create)) {
				// Serialize the object
				serializer.Serialize(stream, this);
			}
		}

		public static Order LoadOrder(string filename) {
			filename = filename.Replace('/', '\\');
			Order order = null;

			// Create serializer
			var serializer = new XmlSerializer(typeof(Order));

			using (var stream = new FileStream(filename, FileMode.Open)) {
				// Deserialize the object
				order = (Order)serializer.Deserialize(stream);
			}

			return order;
		}
	}
}
