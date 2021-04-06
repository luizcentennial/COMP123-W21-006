using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02.Models {
	public class CreditTransaction : Transaction {
		public Account Sender { get; set; }
		public override bool IsCredit { get => true; }
	}
}
