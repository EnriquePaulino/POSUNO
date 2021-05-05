using POSUNO.Components;
using POSUNO.Helpers;
using POSUNO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace POSUNO.Pages
{
    public sealed partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        public ObservableCollection<Product> Products { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoadProductsAsync();
        }

        private async void LoadProductsAsync()
        {
            Loader loader = new Loader("Por favor espere...");
            loader.Show();
            Response response = await ApiService.GetListAsync<Product>("products");
            loader.Close();

            if (!response.IsSuccess)
            {
                MessageDialog dialog = new MessageDialog(response.Message, "Error");
                await dialog.ShowAsync();
                return;
            }

            List<Product> products = (List<Product>)response.Result;
            Products = new ObservableCollection<Product>(products);
            RefreshList();
        }

        private void RefreshList()
        {
            ProductsListView.ItemsSource = null;
            ProductsListView.Items.Clear();
            ProductsListView.ItemsSource = Products;
        }

        //private async void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Customer customer = new Customer();
        //    CustomerDialog dialog = new CustomerDialog(customer);
        //    await dialog.ShowAsync();
        //}

        //private async void EditImage_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    Customer customer = Customers[CustomersListView.SelectedIndex];
        //    customer.IsEdit = true;
        //    CustomerDialog dialog = new CustomerDialog(customer);
        //    await dialog.ShowAsync();
        //}
    }
}