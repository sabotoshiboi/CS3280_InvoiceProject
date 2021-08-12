using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wndSearch SearchWindowForm;
        wndItems ItemWindowForm;
        clsMainSQL sqlClass;
        clsMainLogic busLog = new clsMainLogic();
        public MainWindow()
        {
            InitializeComponent();
            sqlClass = new clsMainSQL();

            busLog.UpdateItemList();

            for(int i = 0; i < busLog.iret; i++)
            {
                busLog.itemList.Add(busLog.ds.Tables[0].Rows[i]);
            }

            for(int i = 0; i < busLog.itemList.Count; i++)
            {
                ItemsListComboBox.Items.Add(busLog.itemList[i][1]);
            }

            EditInvoiceButton.IsEnabled = false;
            DeleteInvoiceButton.IsEnabled = false;
            InvoiceNumberTextBox.Focus();
        }

        /// <summary>
        /// Clicks exit in the file menu tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSearch_Click(object sender, RoutedEventArgs e)
        {
            /*
            * SearchWindowForm = new SearchWindow(InvoiceID);
            * 
            * 
            * SearchWindowForm.ShowDialogue;
            * SearchWindowForm.InvoiceID = sqlClass.iInvoiceID
            * this.Show();
            * 
            * When an invoice is selected on the search window, the selected invoice ID will update in the invoice textbox in the main window
            * The SQL statement will be called to update all the respective data for that invoice including the items list
            */
            SearchWindowForm = new wndSearch();

            SearchWindowForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        ///Clicks the item selection option and opens the items tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItems_Click(object sender, RoutedEventArgs e)
        {
            /*
            * ItemWindowForm = new ItemsWindow();
            * 
            * 
            * ItemsWindowForm.ShowDialogue;
            * 
            * When the Item window closes, an SQL statement will be called to re-fill the Combobox with all present items so that any removed or added items will
            * be applied into the combo box.
            * 
            * this.Show();
            * 
            * 
            */
            ItemWindowForm = new wndItems();
            ItemWindowForm.ShowDialog();

        }

        private void InvoiceNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        { 
            if (!busLog.creating)
            {
                if (InvoiceNumberTextBox.Text != "")
                {
                    RefreshDataGrid();
                }

                AddButton.IsEnabled = false;
                RemoveButton.IsEnabled = false;
                

               if (busLog.ValidInvoice(InvoiceNumberTextBox.Text))
                {
                    DeleteInvoiceButton.IsEnabled = true;
                    EditInvoiceButton.IsEnabled = true;
                }

                else
                {
                    CreateInvoiceButton.IsEnabled = true;
                    DeleteInvoiceButton.IsEnabled = false;
                    EditInvoiceButton.IsEnabled = false;
                }
            }

        }

        private void InvoiceNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void InvoiceItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InvoiceItemsDataGrid.SelectedIndex >= 0 && busLog.editing)
            {
                RemoveButton.IsEnabled = true;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            busLog.RemoveItemFromGrid(Int32.Parse(InvoiceNumberTextBox.Text), Int32.Parse(busLog.ds.Tables[0].Rows[InvoiceItemsDataGrid.SelectedIndex][3].ToString()));
            busLog.UpdateCost(Int32.Parse(InvoiceNumberTextBox.Text));
            RefreshDataGrid();
            if (InvoiceItemsDataGrid.Items.Count > 0)
            {
                InvoiceItemsDataGrid.SelectedIndex = InvoiceItemsDataGrid.Items.Count - 1;
            }
            else
            {
                RemoveButton.IsEnabled = false;
            }
        }

        private void RefreshDataGrid()
        {
            if (!busLog.creating)
            {
                busLog.GetInvoiceByID(Int32.Parse(InvoiceNumberTextBox.Text));
                InvoiceDatePicker.SelectedDate = busLog.invoicedate;
                InvoiceCostTextBox.Text = "$ " + busLog.invoicecost.ToString();

                InvoiceItemsDataGrid.ItemsSource = busLog.ds.Tables[0].DefaultView;

            }
            else
            {
                InvoiceItemsDataGrid.ItemsSource = busLog.itemInsertList;

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (busLog.editing)
            {
                busLog.itemInsertList.Add(busLog.itemList[ItemsListComboBox.SelectedIndex]);
                lbItemQueue.Items.Add(busLog.itemList[ItemsListComboBox.SelectedIndex][1]);
            }
            if (busLog.creating)
            {

                busLog.itemInsertList.Add(busLog.itemList[ItemsListComboBox.SelectedIndex]);

                lbItemQueue.Items.Add(busLog.itemList[ItemsListComboBox.SelectedIndex][1]);

            }

            RefreshDataGrid();

        }

        private void ItemsListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ItemsListComboBox.SelectedIndex >= 0 )
            {
                ItemCostTextBox.Text = "$" + busLog.itemList[ItemsListComboBox.SelectedIndex][2].ToString();
                if (busLog.editing || busLog.creating)
                {
                    AddButton.IsEnabled = true;
                }
            }
        }

        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            var choice = MessageBox.Show("Delete this Invoice?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (choice == MessageBoxResult.Yes)
            {
                busLog.RemoveInvoice(Int32.Parse(InvoiceNumberTextBox.Text));
                RefreshDataGrid();
                CreateInvoiceButton.IsEnabled = true;
                DeleteInvoiceButton.IsEnabled = false;
                EditInvoiceButton.IsEnabled = false;
            }
        }

        private void EditInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            busLog.editing = true;
            CreateInvoiceButton.IsEnabled = false;
            DeleteInvoiceButton.IsEnabled = false;
            EditInvoiceButton.IsEnabled = false;
            SaveButton.IsEnabled = true;
            InvoiceNumberTextBox.IsEnabled = false;
            InvoiceDatePicker.IsEnabled = true;

            if(ItemsListComboBox.SelectedIndex > 0)
            {
                AddButton.IsEnabled = true;
            }

            if(InvoiceItemsDataGrid.SelectedIndex > 0)
            {
                RemoveButton.IsEnabled = true;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (busLog.editing)
            {
                busLog.editing = false;
                DeleteInvoiceButton.IsEnabled = true;
                EditInvoiceButton.IsEnabled = true;
                SaveButton.IsEnabled = false;
                InvoiceNumberTextBox.IsEnabled = true;
                InvoiceDatePicker.IsEnabled = false;

                AddButton.IsEnabled = false;
                RemoveButton.IsEnabled = false;
            }

            if (busLog.creating)
            {
                busLog.creating = false;
                CreateNewInvoice();
                InvoiceNumberTextBox.IsReadOnly = false;
                InvoiceNumberTextBox.Text = busLog.GetnewInvoiceID();


            }


            for (int i = 0; i < busLog.itemInsertList.Count; i++)
            {
                busLog.InsertItemIntoInvoice(Int32.Parse(InvoiceNumberTextBox.Text), InvoiceItemsDataGrid.Items.Count + 1, busLog.itemInsertList[i][0].ToString());
                RefreshDataGrid();
            }
            busLog.itemInsertList.Clear();
            busLog.UpdateCost(Int32.Parse(InvoiceNumberTextBox.Text));
            InvoiceCostTextBox.Text = "$" + busLog.invoicecost.ToString();
            lbItemQueue.Items.Clear();
            CreateInvoiceButton.IsEnabled = true;
            InvoiceDatePicker.IsEnabled = false;
        }

        private void InvoiceDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (busLog.editing)
            {
                busLog.UpdateInvoiceTime(Int32.Parse(InvoiceNumberTextBox.Text), InvoiceDatePicker.SelectedDate.Value);
            }
        }

        private void CreateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            busLog.creating = true;

            InvoiceNumberTextBox.IsReadOnly = true;
            InvoiceNumberTextBox.Text = "TBD";
            InvoiceCostTextBox.Text = "";

            InvoiceDatePicker.IsEnabled = true;
            EditInvoiceButton.IsEnabled = false;
            RemoveButton.IsEnabled = false;
            CreateInvoiceButton.IsEnabled = false;

            SaveButton.IsEnabled = true;

            InvoiceItemsDataGrid.ItemsSource = null;
            InvoiceItemsDataGrid.Items.Clear();
        }

        private void CreateNewInvoice()
        {
            busLog.CreateNewInvoice(InvoiceDatePicker.SelectedDate.Value);
        }
    }
}
