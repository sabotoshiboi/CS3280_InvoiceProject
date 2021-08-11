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
        public bool editingItem;
        public bool addingItem;
        public wndItems()
        {
            InitializeComponent();
            itemsDataGrid.ItemsSource = clsItemsSQL.SelectItemData();
        }
        /// <summary>
        /// this will allow the user to add a new Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddingItem();
                //clsItemsSQL.AddNewItem();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            } 
        }
        /// <summary>
        /// this will allow the user to edit the item desc and cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.SelectedItem;
                editingItem = true;
                EditingItem();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// this will allow the user to delete an item if its not in an active invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (FIND OUT IF ITEM IS ON ACTIVE INVOICE HERE!!!!!!!!!!!)
                {
                    //clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.SelectedItem;
                    //clsItemsSQL.DeleteItem(Item.ItemCode);
                }
                
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// this will handle the users current item selection 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// setting up editing mode for user
        /// </summary>
        public void EditingItem()
        {
            if (editingItem)
            {
                deleteButton.IsEnabled = false;
                itemsDataGrid.IsEnabled = false;
                addButton.IsEnabled = false;
                editCtrls.Visibility = Visibility.Visible;
            }
            else
            {
                deleteButton.IsEnabled = false;
                itemsDataGrid.IsEnabled = false;
                addButton.IsEnabled = false;
                editCtrls.Visibility = Visibility.Collapsed;
            }
        }
        /// <summary>
        /// setting up new item mode for user
        /// </summary>
        public void AddingItem()
        {
            if (editingItem)
            {
                deleteButton.IsEnabled = false;
                itemsDataGrid.IsEnabled = false;
                addButton.IsEnabled = false;
                addCtrls.Visibility = Visibility.Visible;
            }
            else
            {
                deleteButton.IsEnabled = true;
                itemsDataGrid.IsEnabled = true;
                addButton.IsEnabled = true;
                editCtrls.Visibility = Visibility.Collapsed;
            }
        }
        /// <summary>
        /// saving new item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addingItem = false;
                AddingItem();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// save edited item info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                editingItem = false;
                EditingItem();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
