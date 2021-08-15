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
    public partial class wndSearch : Window

    {

        //Needs comment about when the invoice is selected, the Invoice ID is saved in a local variable that the main window can access.

        /// <summary>
        /// Data access class
        /// </summary>
        private clsDataAccess db = new clsDataAccess();
        /// <summary>
        /// Search SQL class access
        /// </summary>
        clsSearchSQL clsSearchSQL = new clsSearchSQL();

        /// <summary>
        /// BusLog to acces logic
        /// </summary>
        clsSearchLogic busLog = new clsSearchLogic();

        /// <summary>
        /// Main access
        /// </summary>
        clsMainLogic main;

        string InvoiceNum;


        public string ReturnInvoice
        {
            get { return InvoiceNum; }
            set { InvoiceNum = value; }
        }

        /// <summary>
        /// Initializes the Search window
        /// </summary>
        public wndSearch(clsMainLogic mainlogic)
        {
            InitializeComponent();
            LoadComboBox1();
            LoadComboBox2();
            LoadComboBox3();
            main = mainlogic;

            //Properly shutting the window down
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //Dataset object
            DataSet ds = new DataSet();

            DataGrid.ItemsSource = busLog.SelectSearchData();
        }

        /// <summary>
        /// Select button closes window on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsSearchLogic Item = (clsSearchLogic)DataGrid.SelectedItem;
                int invoiceNum = Item.InvoiceNum;
                LabelSelectedInvoiceNum.Content = invoiceNum.ToString();
                main.InvoiceNum = invoiceNum;
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            //Close search window and give main form focus
            this.Hide();
        }

        /// <summary>
        /// Cancel button closes window on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            //Close search window and give main form focus
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The user selected an item in the combo box 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Here
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The user selected an item in the combo box 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selects object that will be remembered when the Select button is clicked
            try
            {
                //Here
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// The user selected an item in the combo box 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selects object that will be remembered when the Select button is clicked
            try
            {
                //Here
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Selection change makes submit button available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ButtonSelect.IsEnabled = true;
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Loads combo box 1 with invoice numbers
        /// </summary>
        private void LoadComboBox1()
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Get all invoice numbers
                ds = db.ExecuteSQLStatement("SELECT InvoiceNum FROM Invoices", ref iRet);

                //Loop through all the values returned
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Add the invoices to the box
                    ComboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Loads combo box 2 with dates
        /// </summary>
        private void LoadComboBox2()
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Get all invoice dates
                ds = db.ExecuteSQLStatement("SELECT InvoiceDate FROM Invoices", ref iRet);

                //Loop through all the values returned
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Add the dates into the box
                    ComboBox2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Loads combo box 3 with total costs
        /// </summary>
        private void LoadComboBox3()
        {
            try
            {
                //Create a DataSet to hold the data
                DataSet ds;

                //Number of return values
                int iRet = 0;

                //Get all invoice numbers
                ds = db.ExecuteSQLStatement("SELECT TotalCost FROM Invoices", ref iRet);

                //Loop through all the values returned
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Add the totals into the box
                    ComboBox3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Empties combo box 1
        /// </summary>
        private void EmptyComboBox1()
        {
            try
            {
                ComboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Empties combo box 2
        /// </summary>
        private void EmptyComboBox2()
        {
            try
            {
                ComboBox2.SelectedIndex = -1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Empties combo box 3
        /// </summary>
        private void EmptyComboBox3()
        {
            try
            {
                ComboBox3.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Makes the button select enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedIndex > -1)
            {
                ButtonSelect.IsEnabled = true;
                clsSearchLogic Item = (clsSearchLogic)DataGrid.SelectedItem;
                int invoiceNum = Item.InvoiceNum;
                LabelSelectedInvoiceNum.Content = invoiceNum.ToString();
            }
            else
            {
                LabelSelectedInvoiceNum.Content = "";
            }
        }
    }
}
