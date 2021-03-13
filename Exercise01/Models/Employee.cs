using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise01.Models {
	public abstract class Employee {
		public string EmployeeID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime HiredDate { get; set; }
		public double Salary { get; set; }
		public string Position { get; set; }

		public void ClockIn() {
			Console.WriteLine($"{this.EmployeeID} clocked in.");
		}

		public void ClockOut() {
			Console.WriteLine($"{this.EmployeeID} clocked out.");
		}

		public abstract void Work();

		public virtual void ReceivePay() {
			Console.WriteLine("Just got paid!");
		}

		protected void Quit() { 
			// Quitting job.
		}
	}
}
