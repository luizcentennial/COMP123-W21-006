using HelloWorld.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld {
	class Program {
		static void Main(string[] args) {
			Product product = new Product(19.99, "Lamp");
			product.ShippingMethod = ShippingMethod.LocalPickup;

			Console.WriteLine(product);
		}
	}
}