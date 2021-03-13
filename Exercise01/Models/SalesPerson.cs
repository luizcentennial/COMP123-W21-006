using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise01.Models {
	public class SalesPerson : Employee {
		public double CommissionRate { get; set; }

		public override void Work() {
			Console.WriteLine("Sales person is selling products.");
		}

		public override void ReceivePay() {
			Console.WriteLine("Receiving salary + commission.");

			this.Quit();
		}
	}
}
