using Exercise01.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise01.Models {
	public class Programmer : Employee, IFrontEndProgrammer, IBackEndProgrammer {
		public void DesignGUI() {
			Console.WriteLine("Designing a fancy UI...");
		}

		public void ImplementBackEnd() {
			Console.WriteLine("Writing fancy C# code...");
		}

		public override void Work() {
			Console.WriteLine("Drinking coffee...");
		}
	}
}
