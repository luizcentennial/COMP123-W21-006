using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services {
	public class OrderService : IService<Order> {
		public void Create(Order obj) {
			// Creating customer record in database...
			// Done!
		}

		public void Delete(Order obj) {
			// Deleting customer record from database...
			// Done!
		}

		public Order GetByID(string ID) {
			// Retrieving customer record from database...
			// Done!

			return new Order() {
				OrderID = ID,
				Customer = new Customer() {
					FirstName = "Bruce",
					LastName = "Wayne",
					Email = "bruce@wayne.com"
				}
			};
		}

		public void Update(Order obj) {
			// Updating customer record in database...
			// Done!
		}
	}
}
