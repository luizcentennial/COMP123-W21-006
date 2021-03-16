using Exercise01.Interfaces;
using Exercise01.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise01.Service {
	public class NewEmployeeService : IEmployeeService {
		public Programmer GetProgrammer(string employeeID) {
			// Connecting to HR system...
			// ...
			// HR system request came back with the object below
			Console.WriteLine("Retrieving object from HR System...");

			var employee = new Programmer() {
				EmployeeID = employeeID,
				FirstName = "Bruce",
				LastName = "Wayne",
				HiredDate = new DateTime(2015, 07, 01),
				Position = "Programmer",
				Salary = 120000
			};

			return employee;
		}
	}
}
