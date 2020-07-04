using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RentalApplication.Models;

namespace RentalApplication
{
    public partial class MainWindow : Window
    {
        // Property with specifying initial values in-line
        public Order Order { get; set; } = new Order();



        public MainWindow()
        {
            InitializeComponent();

            // Generating contents of third combobox (cbHelmet)
            List<Helmet> helmets = new List<Helmet>();
            helmets.Add(new Helmet ("Triple 8", "Brainsaver", 2));
            helmets.Add(new Helmet ("Pro-Tec", "Classic", 2));
            helmets.Add(new Helmet ("Giro", "Fixture", 2));
            helmets.Add(new Helmet ("Oakley", "DRT5", 3));
            cbHelmet.ItemsSource = helmets;

            cbType.ItemsSource = new List<string>() { "Bicycle", "Scooter", "Skateboard" };

            // Renting Perion combobox where i is days to rent
            int i = 1;
            while (i <= 15)
            {
                cbRentingPeriod.Items.Add(i);
                i++;
            }
        }

        // Click on Next Button sends user to the Customer window and closes current window
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            new Customer(Order).Show();
            this.Close();
        }


        // Updates price in textblock Total
        public void UpdatePrice()
        {
            if (Order != null)
            {
                string content = 
                tblTotal.Text = Order.TotalPriceStr;
            }
        }

        // Generates content of combobox Brand (cbBrand) based on selection of combobox Type cbType (index 0 - Bicycle, index 1 - Scooter, index 2 - Skateboard)
        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            switch (cbType.SelectedIndex)
            {
                case 0:
                    {
                        vehicles.Add(new Bicycle { Make = "Pedego", Model = "Interceptor", Price = 17, Size = BikeSizes.S });
                        vehicles.Add(new Bicycle { Make = "Pedego", Model = "Interceptor", Price = 17, Size = BikeSizes.M });
                        vehicles.Add(new Bicycle { Make = "Pedego", Model = "Interceptor", Price = 17, Size = BikeSizes.L });
                        vehicles.Add(new Bicycle { Make = "Pedego", Model = "Interceptor", Price = 17, Size = BikeSizes.XL });
                        vehicles.Add(new Bicycle { Make = "Juiced", Model = "CrossCurrent", Price = 18, Size = BikeSizes.S });
                        vehicles.Add(new Bicycle { Make = "Juiced", Model = "CrossCurrent", Price = 18, Size = BikeSizes.M });
                        vehicles.Add(new Bicycle { Make = "Juiced", Model = "CrossCurrent", Price = 18, Size = BikeSizes.L });
                        vehicles.Add(new Bicycle { Make = "Juiced", Model = "CrossCurrent", Price = 18, Size = BikeSizes.XL });
                        vehicles.Add(new Bicycle { Make = "Canyon", Model = "Spectral", Price = 22, Size = BikeSizes.S });
                        vehicles.Add(new Bicycle { Make = "Canyon", Model = "Spectral", Price = 22, Size = BikeSizes.M });
                        vehicles.Add(new Bicycle { Make = "Canyon", Model = "Spectral", Price = 22, Size = BikeSizes.L });
                        vehicles.Add(new Bicycle { Make = "Canyon", Model = "Spectral", Price = 22, Size = BikeSizes.XL });
                        break;
                    }
                case 1:
                    {
                        vehicles.Add(new Scooter { Make = "Segway", Model = "Ninebot", Price = 13, });
                        vehicles.Add(new Scooter { Make = "Dualtron", Model = "Thunder", Price = 18, });
                        vehicles.Add(new Scooter { Make = "Titan", Model = "Commuter", Price = 17, });
                        break;
                    }
                case 2:
                    {
                        vehicles.Add(new Skateboard { Make = "Onewheel", Model = "Pint", Price = 14, });
                        vehicles.Add(new Skateboard { Make = "Evolve", Model = "Carbon GTR", Price = 16, });
                        vehicles.Add(new Skateboard { Make = "Maxfind", Model = "Max4 Pro", Price = 15, });
                        break;
                    }
            }

            Order.Vehicle = null;
            cbBrand.ItemsSource = vehicles;
        }
        
        // In this event we get an object type Vehicle from selected element in combobox and save it in Order object and refresh price 
        private void cbBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order.Vehicle = (Vehicle)(sender as ComboBox).SelectedValue;
            UpdatePrice();
        }

        private void cbHelmet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order.Helmet = (Helmet)(sender as ComboBox).SelectedValue;
            UpdatePrice();
        }

        private void cbRentingPeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order.Days = (int)(sender as ComboBox).SelectedValue;
            UpdatePrice();
        }
    }
}
