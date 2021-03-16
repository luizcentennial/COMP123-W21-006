using Exercise01.Interfaces;
using Exercise01.Models;
using Exercise01.Service;
using System;
using System.Collections.Generic;

namespace Exercise01 {
	class Program {
		static void Main(string[] args) {
			Employee salesPerson = new SalesPerson() { 
				EmployeeID = "SALES01",
				FirstName = "John",
				LastName = "Smith"
			};

			Employee genitor = new Genitor() { 
				EmployeeID = "GEN01",
				FirstName = "Steve",
				LastName = "Johnson",
				Shift = Shift.Night
			};

			salesPerson.ClockIn();
			genitor.ClockIn();

			Console.WriteLine("\n===========================================\n");

			salesPerson.Work();
			genitor.Work();

			Console.WriteLine("\n===========================================\n");

			salesPerson.ReceivePay();
			genitor.ReceivePay();

			// ===================================================================
			Console.WriteLine("\n===========================================\n");

			// IEmployeeService employeeService = new EmployeeService(); Old line
			IEmployeeService employeeService = new NewEmployeeService(); // New line

			var programmer = employeeService.GetProgrammer("emp001");
			programmer.Work();
		}
	}
}
