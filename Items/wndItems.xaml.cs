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
        /// <summary>
        /// creating an SQL object to call statements 
        /// </summary>
        clsItemsSQL clsItemsSQL = new clsItemsSQL();

        /// <summary>
        /// creating bools to enable add and edit controls
        /// </summary>
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
                addingItem = true;
                AddingItem();
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
                if (itemsDataGrid.SelectedIndex > -1)
                {
                    clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.SelectedItem;                    
                    editDescBox.Text = Item.ItemDesc;
                    editCostBox.Text = Item.ItemCost.ToString();
                    editingItem = true;
                    EditingItem();
                }
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
                clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.SelectedItem;
                string invoiceNum = clsItemsSQL.SelectInvoiceData(Item.ItemCode.ToString());
                if (itemsDataGrid.SelectedIndex > -1 && invoiceNum == "")
                {
                    clsItemsSQL.DeleteItem(Item.ItemCode);
                    itemsDataGrid.ItemsSource = clsItemsSQL.SelectItemData();
                }
                else if (itemsDataGrid.SelectedIndex > -1 && invoiceNum != "")
                {
                    MessageBox.Show("This item is used on Invoice Number " + invoiceNum + ", please remove item from invoice before deleting");
                }
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
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
                bool codeTaken = false;
                for (int i = 0; i < itemsDataGrid.Items.Count; i++)
                {
                    clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.Items[i];

                    if (Item.ItemCode == newItemCodeBox.Text)
                    {
                        codeTaken = true;
                    }
                }
                if (!codeTaken)
                {
                    clsItemsSQL.AddNewItem(newItemCodeBox.Text, newItemDescBox.Text, Convert.ToInt32(newItemCostBox.Text));
                    addingItem = false;
                    AddingItem();
                    itemsDataGrid.ItemsSource = clsItemsSQL.SelectItemData();
                }
                else
                    addErrorLabel.Content = "Please select a new \nunused Item Code";
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
                clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.SelectedItem;
                clsItemsSQL.UpdateItemData(editDescBox.Text, Item.ItemCode, Convert.ToInt32(editCostBox.Text));
                editingItem = false;
                EditingItem();
                itemsDataGrid.ItemsSource = clsItemsSQL.SelectItemData();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// close the program with a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                clsItemsSQL.HandleError(MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// this method controls the programs action when the user clicks a specific datagrid item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemsDataGrid.SelectedIndex > -1)
            {
                clsItemsLogic Item = (clsItemsLogic)itemsDataGrid.SelectedItem;
                itemCodeLbl.Content = Item.ItemCode;
                itemDescLbl.Content = Item.ItemDesc;
                itemCostLbl.Content = Item.ItemCost;
                deleteButton.IsEnabled = true;
                editButton.IsEnabled = true;
            }
            else
            {
                deleteButton.IsEnabled = false;
                editButton.IsEnabled = false;
                itemCodeLbl.Content = "";
                itemDescLbl.Content = "";
                itemCostLbl.Content = "";
            }
        }
        /// <summary>
        /// setting up editing mode for user
        /// </summary>
        public void EditingItem()
        {
            if (editingItem)
            {
                closeButton.IsEnabled = false;
                deleteButton.IsEnabled = false;
                addButton.IsEnabled = false;
                itemsDataGrid.IsHitTestVisible = false;
                selectedItemCanvas.Visibility = Visibility.Collapsed;
                editCtrls.Visibility = Visibility.Visible;
            }
            else
            {
                closeButton.IsEnabled = true;
                deleteButton.IsEnabled = true;
                addButton.IsEnabled = true;
                itemsDataGrid.IsHitTestVisible = true;
                selectedItemCanvas.Visibility = Visibility.Visible;
                editCtrls.Visibility = Visibility.Collapsed;
            }
        }
        /// <summary>
        /// setting up new item mode for user
        /// </summary>
        public void AddingItem()
        {
            if (addingItem)
            {
                deleteButton.IsEnabled = false;
                itemsDataGrid.IsEnabled = false;
                addButton.IsEnabled = false;
                selectedItemCanvas.Visibility = Visibility.Collapsed;
                addCtrls.Visibility = Visibility.Visible;
                closeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                closeButton.IsEnabled = true;
                deleteButton.IsEnabled = true;
                itemsDataGrid.IsEnabled = true;
                addButton.IsEnabled = true;
                selectedItemCanvas.Visibility = Visibility.Visible;
                closeButton.Visibility = Visibility.Visible;
                addCtrls.Visibility = Visibility.Collapsed;
            }
        }
    }
}
