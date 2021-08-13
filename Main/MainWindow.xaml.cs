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
using System.Reflection;


namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Instance of the search window
        /// </summary>
        wndSearch SearchWindowForm;
        /// <summary>
        /// Instance of the Items window
        /// </summary>
        wndItems ItemWindowForm;
        /// <summary>
        /// Instance of the SQL class
        /// </summary>
        clsMainSQL sqlClass;
        /// <summary>
        /// Instance of the Main Logic class
        /// </summary>
        clsMainLogic busLog = new clsMainLogic();
        /// <summary>
        /// Constructor for the main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            sqlClass = new clsMainSQL();

            
            LoadComboBox();
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
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Opens the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchWindowForm = new wndSearch();
                SearchWindowForm.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        ///Clicks the item selection option and opens the items tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemWindowForm = new wndItems();
                ItemWindowForm.ShowDialog();
                LoadComboBox();
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called when the text in the Invoice Number Text Box changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// Ensures only numbers can be inputted in the Invoice Number Text Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the Data grid changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceItemsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (InvoiceItemsDataGrid.SelectedIndex >= 0 && busLog.editing)
                {
                    RemoveButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the Remove button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Refreshes the Data Grid when information changes
        /// </summary>
        private void RefreshDataGrid()
        {
            try
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
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the add button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                busLog.itemInsertList.Add(busLog.itemList[ItemsListComboBox.SelectedIndex]);
                lbItemQueue.Items.Add(busLog.itemList[ItemsListComboBox.SelectedIndex][1]);
                RefreshDataGrid();
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// Called when the Combo box selection changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ItemsListComboBox.SelectedIndex >= 0)
                {
                    ItemCostTextBox.Text = "$" + busLog.itemList[ItemsListComboBox.SelectedIndex][2].ToString();
                    if (busLog.editing || busLog.creating)
                    {
                        AddButton.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the Delete button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the Edit Button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                busLog.editing = true;
                CreateInvoiceButton.IsEnabled = false;
                DeleteInvoiceButton.IsEnabled = false;
                EditInvoiceButton.IsEnabled = false;
                SaveButton.IsEnabled = true;
                InvoiceNumberTextBox.IsEnabled = false;
                InvoiceDatePicker.IsEnabled = true;
                InvoiceItemsDataGrid.IsEnabled = true;

                if (ItemsListComboBox.SelectedIndex > 0)
                {
                    AddButton.IsEnabled = true;
                }

                if (InvoiceItemsDataGrid.SelectedIndex > 0)
                {
                    RemoveButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the Save button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (busLog.editing)
                {
                    busLog.editing = false;
                    DeleteInvoiceButton.IsEnabled = true;
                    EditInvoiceButton.IsEnabled = true;
                    SaveButton.IsEnabled = false;
                    InvoiceNumberTextBox.IsEnabled = true;
                    InvoiceDatePicker.IsEnabled = false;
                    InvoiceItemsDataGrid.IsEnabled = false;
                    AddButton.IsEnabled = false;
                    RemoveButton.IsEnabled = false;

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

                if (busLog.creating)
                {
                    if (!InvoiceDatePicker.SelectedDate.HasValue)
                    {
                        MessageBox.Show("Please enter a Date", "Date Confirmation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        busLog.creating = false;
                        busLog.CreateNewInvoice(InvoiceDatePicker.SelectedDate.Value);
                        InvoiceNumberTextBox.IsReadOnly = false;
                        InvoiceNumberTextBox.Text = busLog.GetnewInvoiceID();

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
                }

                
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the Date in the Date Picker changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (busLog.editing)
                {
                    busLog.UpdateInvoiceTime(Int32.Parse(InvoiceNumberTextBox.Text), InvoiceDatePicker.SelectedDate.Value);
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Called when the Create button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Updates the combo box to reflect any changes to the inventory
        /// </summary>
        private void LoadComboBox()
        {
            try
            {
                ItemsListComboBox.Items.Clear();
                busLog.itemList.Clear();
                busLog.UpdateItemList();

                for (int i = 0; i < busLog.iret; i++)
                {
                    busLog.itemList.Add(busLog.ds.Tables[0].Rows[i]);
                }

                for (int i = 0; i < busLog.itemList.Count; i++)
                {
                    ItemsListComboBox.Items.Add(busLog.itemList[i][1]);
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
