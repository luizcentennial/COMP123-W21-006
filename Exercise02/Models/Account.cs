using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise02.Models {
	public class Account {
		public string AccountGuid { get; set; }
		public string AccountNumber { get; set; }
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public List<DebitTransaction> DebitTransactions { get; set; }
		public List<CreditTransaction> CreditTransactions { get; set; }
		public double Balance {
			get {
				double total = 0;

				foreach (var transaction in this.DebitTransactions) {
					total -= transaction.Value;
				}

				foreach (var transaction in this.CreditTransactions) {
					total += transaction.Value;
				}

				return total;
			}
		}

		public Account() {
			this.AccountGuid = Guid.NewGuid().ToString();
			this.AccountNumber = new Random().Next(10000, 99999).ToString();
			this.DebitTransactions = new List<DebitTransaction>();
			this.CreditTransactions = new List<CreditTransaction>();
		}
	}
}
