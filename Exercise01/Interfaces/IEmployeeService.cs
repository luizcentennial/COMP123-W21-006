using Exercise01.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise01.Interfaces {
	public interface IEmployeeService {
		public Programmer GetProgrammer(string employeeID);
	}
}
