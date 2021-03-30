using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services {
	public class CustomerService : IService<Customer> {
		public void Create(Customer obj) {
			// Creating customer record in database...
			// Done!
		}

		public void Delete(Customer obj) {
			// Deleting customer record from database...
			// Done!
		}

		public Customer GetByID(string ID) {
			// Retrieving customer record from database...
			// Done!

			return new Customer() { 
				CustomerID = ID,
				FirstName = "Bruce",
				LastName = "Wayne",
				Email = "bruce@wayne.com"
			};
		}

		public void Update(Customer obj) {
			// Updating customer record in database...
			// Done!
		}
	}
}
