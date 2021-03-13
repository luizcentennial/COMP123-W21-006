using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise01.Models {
	public class Genitor : Employee {
		public Shift Shift { get; set; }

		public override void Work() {
			Console.WriteLine("Genitor mops the floor.");
		}
	}

	public enum Shift {
		Day,
		Night
	}
}
