using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public partial class wndItems : Window
    {
        clsItemsSQL clsItemsSQL;
        public wndItems()
        {
            InitializeComponent();
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itemsDataGrid.ItemsSource = clsItemsSQL.SelectItemData();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
               // clsItemsSQL.AddNewItem();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            } 
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.SelectedItem;
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //this button will allow a user to delete an item as long as its not being used in an active invoice
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void itemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
