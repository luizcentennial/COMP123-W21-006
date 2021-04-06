using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02.Models {
	public abstract class Transaction {
		protected double value;

		public string TransactionGuid { get; private set; }
		public DateTime TransactionDate { get; set; }
		public double Value { 
			get {
				return this.value;
			}
			set {
				if (value >= 0)
					this.value = value;
				else
					throw new Exception("Transaction value cannot be null!");

			}
		}
		public abstract bool IsCredit { get; }

		public Transaction() {
			this.TransactionGuid = Guid.NewGuid().ToString();
		}
	}
}
