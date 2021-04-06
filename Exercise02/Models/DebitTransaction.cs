using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02.Models {
	public class DebitTransaction : Transaction {
		public Account Receiver { get; set; }
		public override bool IsCredit { get => false; }
	}
}
