using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld.Models {
	public class Customer {
		// FIELDS

		// PROPERTIES
		public string CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public List<Order> Orders { get; set; }

		// METHODS
		public Customer() {	}

		private Customer(string firstName, string lastName, string email) {
			this.CustomerID = Guid.NewGuid().ToString();
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
		}

		public override string ToString() {
			return $"Customer ID: {this.CustomerID} \n" +
				   $"Name: {this.FirstName} {this.LastName} \n" +
				   $"Email: {this.Email} \n" +
				   $"Phone: {this.PhoneNumber} ";
		}

		public static Customer CreateCustomer(string firstName, string lastName, string email) {
			Customer customer = new Customer(firstName, lastName, email);

			// Do some fancy validation here...

			return customer;
		}
	}
}
