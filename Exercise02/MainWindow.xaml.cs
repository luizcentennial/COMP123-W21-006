using Exercise02.Models;
using Exercise02.Services;
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
			var accountService = new AccountService();
			var accounts = accountService.Load();

			return accounts;
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
			var accountService = new AccountService();
			accountService.Save(account);

			dataAccounts.ItemsSource = LoadAccounts();

			// Clear textboxes
			txtCustomerName.Text = null;
			dateDateOfBirth.SelectedDate = null;

			MessageBox.Show("Account successfully created!");
		}

		private void OnSelectAccount(object sender, EventArgs e) {
			var selectedAccount = (Account)dataAccounts.SelectedItem;

			lblSelectedAccount.Content = $"Transactions for account {selectedAccount.AccountNumber}.";

			List<Transaction> transactions = new List<Transaction>();

			foreach (var transaction in selectedAccount.DebitTransactions) {
				transactions.Add(transaction);
			}

			foreach (var transaction in selectedAccount.CreditTransactions) {
				transactions.Add(transaction);
			}

			// Same as above
			//selectedAccount.CreditTransactions.ForEach(transaction => transactions.Add(transaction));

			transactions = transactions.OrderByDescending(t => t.TransactionDate).ToList();

			dataTransactions.ItemsSource = transactions;
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

				selectedAccount.CreditTransactions.Add(transaction);
			}
			else {
				var transaction = new DebitTransaction() {
					TransactionDate = DateTime.Now,
					Value = double.Parse(txtTransactionValue.Text)
				};

				selectedAccount.DebitTransactions.Add(transaction);
			}

			var accountService = new AccountService();
			accountService.Update(selectedAccount);

			List<Transaction> transactions = new List<Transaction>();

			foreach (var transaction in selectedAccount.DebitTransactions) {
				transactions.Add(transaction);
			}

			foreach (var transaction in selectedAccount.CreditTransactions) {
				transactions.Add(transaction);
			}

			dataTransactions.ItemsSource = null;
			dataTransactions.ItemsSource = transactions;

			txtTransactionValue.Text = null;
			checkIsCredit.IsChecked = false;

			MessageBox.Show($"Transaction added to account {selectedAccount.AccountNumber}");
		}
	}
}
