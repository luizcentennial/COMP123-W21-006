using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02.Models {
	public class Account {
		public string AccountGuid { get; private set; }
		public string AccountNumber { get; private set; }
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public List<Transaction> Transactions { get; set; }
		public double Balance { 
			get {
				double total = 0;

				foreach (var transaction in this.Transactions) {
					if (transaction.IsCredit)
						total += transaction.Value;
					else
						total -= transaction.Value;
				}

				return total;
			}
		}

		public Account() {
			this.AccountGuid = Guid.NewGuid().ToString();
			this.AccountNumber = new Random().Next(10000, 99999).ToString();
			this.Transactions = new List<Transaction>();
		}
	}
}
