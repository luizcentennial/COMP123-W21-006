using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld {
	class Program {
		static void Main(string[] args) {
			#region Creating an order file
			var customer = Customer.CreateCustomer("John", "Smith", "john@smith.com");
			var product = Product.CreateProduct(99.99, "Sword");
			var order = Order.CreateOrder(customer, product);

			Console.WriteLine("Saving order...");

			try {
				// ANY code is possible here.
				order.SaveOrder(@"C:\_test\");
			}
			catch (Exception ex) {
				// Do something if an exception happens.
				Console.WriteLine("Error when trying to save order. Order could not be saved.");
				Console.WriteLine(ex.Message);

				return;
			}

			Console.WriteLine("Done!");
			#endregion

			//var order = Order.LoadOrder(@"C:\_test\eb2e9786-732d-41d2-a7cd-5e362c36ffa9.xml");

			Console.WriteLine(order);

			List<Customer> list = new List<Customer>();
		}
	}
}