using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models {
	public class OrderItem {
		public string OrderItemID { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public double Subtotal { get; set; }
	}
}
