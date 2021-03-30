using Models;
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

namespace WPF {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

			// Customizations go after this line!

			// Installing event listeners
			btnSave.Click += SaveButtonClick;
		}

		public void SaveButtonClick(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text)) {
				MessageBox.Show($"Please input a first and last name before creating the customer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

				return;
			}

			var customer = new Customer();
			customer.FirstName = txtFirstName.Text;
			customer.LastName = txtLastName.Text;

			// Saving new customer to database...

			MessageBox.Show($"Customer {customer.FirstName} {customer.LastName} created successfuly!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
