using System;
using System.Collections.Generic;
using System.Text;

namespace Models {
	public class Product {
		// FIELDS
		private int stock;

		// PROPERTIES
		public string ProductID { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public bool IsInStock {
			get {
				return this.Stock > 0;
			}
		}
		public int Stock {
			get {
				return this.stock;
			}
			set {
				if (value >= 0)
					this.stock = value;
			}
		}
		public ShippingMethod ShippingMethod { get; set; }

		// METHODS
		public Product() {

		}

		private Product(double price, string description) {
			this.ProductID = Guid.NewGuid().ToString();
			this.Price = price;
			this.Description = description;
		}

		public override string ToString() {
			return $"Product ID: {this.ProductID} \n" +
				   $"Description: {this.Description} \n" +
				   $"Price: {this.Price:C} \n" +
				   $"Stock: {this.Stock} \n" +
				   $"Shipping Method: {this.ShippingMethod}";
		}

		public static Product CreateProduct(double price, string description) {
			return new Product(price, description);
		}
	}
}
