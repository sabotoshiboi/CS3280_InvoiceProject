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

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Page
    {
        public wndItems()
        {
            InitializeComponent();
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            //itemsDataGrid.ItemsSource = clsItemsSQL.SelectItemData();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            //this button will clear user specifications from dropdowns 
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //this button will add a new item to the database
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            //this button will allow the user to edit an item
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //this button will allow a user to delete an item as long as its not being used in an active invoice 
        }

        private void invoiceNumDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this dropdown will list invoices
        }

        private void itemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
