using Exercise02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise02 {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

			btnCreateAccount.Click += this.OnCreateAccount;
			btnCreateTransaction.Click += this.OnCreateTransaction;
			dataAccounts.SelectionChanged += this.OnSelectAccount;

			dataAccounts.ItemsSource = this.LoadAccounts();
		}

		public List<Account> LoadAccounts() {
			return new List<Account>() {
				new Account() {
					FullName = "Bruce Wayne",
					DateOfBirth = new DateTime(1985, 7, 15),
					Transactions = new List<Transaction>() {
						new CreditTransaction() {
							TransactionDate = new DateTime(2021, 02, 15),
							Value = 500
						}
					}
				},
				new Account() {
					FullName = "Clark Kent",
					DateOfBirth = new DateTime(1985, 7, 15),
					Transactions = new List<Transaction>() {
						new CreditTransaction() {
							TransactionDate = new DateTime(2021, 03, 21),
							Value = 100
						}
				}
				}
			};
		}

		private void OnCreateAccount(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || dateDateOfBirth.SelectedDate == null) {
				MessageBox.Show("Please provide the required information in order to create an account.");

				return;
			}

			var account = new Account() {
				FullName = txtCustomerName.Text,
				DateOfBirth = dateDateOfBirth.SelectedDate
			};

			// Save account...
			var accounts = this.LoadAccounts();
			accounts.Add(account);

			dataAccounts.ItemsSource = accounts;

			// Clear textboxes
			txtCustomerName.Text = null;
			dateDateOfBirth.SelectedDate = null;

			MessageBox.Show("Account successfully created!");
		}

		private void OnSelectAccount(object sender, EventArgs e) {
			var selectedAccount = (Account)dataAccounts.SelectedItem;

			lblSelectedAccount.Content = $"Transactions for account {selectedAccount.AccountNumber}.";

			dataTransactions.ItemsSource = selectedAccount.Transactions;
		}

		private void OnCreateTransaction(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(txtTransactionValue.Text) || !double.TryParse(txtTransactionValue.Text, out _)) {
				MessageBox.Show("Transaction value has to be a number!");

				return;
			}

			var selectedAccount = (Account)dataAccounts.SelectedItem;

			if (selectedAccount == null) {
				MessageBox.Show("Please selecte an account to continue.");

				return;
			}

			if (checkIsCredit.IsChecked == true) {
				var transaction = new CreditTransaction() {
					TransactionDate = DateTime.Now,
					Value = double.Parse(txtTransactionValue.Text)
				};

				selectedAccount.Transactions.Add(transaction);
				dataTransactions.ItemsSource = null;
				dataTransactions.ItemsSource = selectedAccount.Transactions;
			}
			else {
				var transaction = new DebitTransaction() {
					TransactionDate = DateTime.Now,
					Value = double.Parse(txtTransactionValue.Text)
				};

				selectedAccount.Transactions.Add(transaction);
				dataTransactions.ItemsSource = null;
				dataTransactions.ItemsSource = selectedAccount.Transactions;
			}

			txtTransactionValue.Text = null;
			checkIsCredit.IsChecked = false;

			MessageBox.Show($"Transaction added to account {selectedAccount.AccountNumber}");
		}
	}
}
