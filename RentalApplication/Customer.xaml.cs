using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RentalApplication.Models;

namespace RentalApplication
{
    public partial class Customer : Window
    {
        private Order order;

        public Customer(Order order)
        {
            InitializeComponent();
            this.order = order;
            tblTotalPrice.Text = $"Total amount to pay in store is ${order.CalculatePrice()}";
        }

        private void bSumbit_Click(object sender, RoutedEventArgs e)
        {
            string fileContent = string.Empty;

            if(order != null && order.Vehicle != null)
            {
                fileContent += "[ Order ]\n";
                fileContent += "Vehicle: " + (order.Vehicle is Bicycle ? ((Bicycle)order.Vehicle).ToString() : order.Vehicle.ToString()) + "\n";
                fileContent += "Helmet:" + order?.Helmet.ToString() + "\n" ?? "Not included (-)\n";
                fileContent += "Renting days: " + order.Days.ToString() + "\n";
                fileContent += "\n" + order.TotalPriceStr + "\n\n";
                fileContent += "[ Customer ]\n";
                fileContent += "First name: " + tbFirstname.Text + "\n";
                fileContent += "Last name: " + tbLastname.Text + "\n";
                fileContent += "Email: " + tbEmail.Text + "\n";
                fileContent += "Phone number: " + tbPhoneNumber.Text + "\n";

                File.WriteAllText("order.txt", fileContent);

                MessageBox.Show("Your order is being prepared - we'll contact you once it's ready.", "Thank you!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("You haven't entered enough data! Please, try again!", "Insufficient data",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }


            new MainWindow().Show();
            this.Close();
        }
    }
}
