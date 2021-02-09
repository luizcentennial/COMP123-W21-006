using HelloWorld.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld {
	class Program {
		static void Main(string[] args) {
			var customer = Customer.CreateCustomer("John", "Smith", "john@smith.com");
			var product = Product.CreateProduct(99.99, "Sword");
			var order = Order.CreateOrder(customer, product);

			var anotherProduct = Product.CreateProduct(199.99, "Shield");
			var anotherOrder = Order.CreateOrder(customer, anotherProduct);

			Console.WriteLine("Saving...");

			order.SaveOrder(@"C:\_test\");
			anotherOrder.SaveOrder(@"C:\_test\");

			Console.WriteLine("Done!");
		}
	}
}