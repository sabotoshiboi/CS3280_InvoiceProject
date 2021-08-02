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
using System.Windows.Shapes;
using System.Data;

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
        clsDataAccess db;

        /// <summary>
        /// Initializes the Search window
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();

            //Properly shutting the window down
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //string to hold SQL statement(s)
            string sSQL;

            //Return value of rows
            int iRet = 0;

            //Dataset object
            DataSet ds = new DataSet();

            //Used for a class that would hold invoices
            //clsInvoices Invoices
            
            //Selects numbers, dates, and costs of invoices
            sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices";

            //Executes the SQL statement
            //ds = db.ExecuteSQLStatement(sSQL, ref iRet);

            //Loop through the data and create invoices classes. Populates with iRet
            //for (int i = 0; i < iRet; i++)
            //{
            //    Invoices = new clsPInvoices();
            //    Invoices.InvoiceNum = ds.Tables[0].Rows[i][0].ToString();
            //    Invoices.InvoiceDate = ds.Tables[0].Rows[i]["Invoice_Date"].ToString();
            //    Invoices.TotalCost = ds.Tables[0].Rows[i]["Total_Cost"].ToString();

            //    ComboBox1.Items.Add(Invoice);
            //    ComboBox2.Items.Add(Invoice);
            //    ComboBox3.Items.Add(Invoice);
            //}
        }

        /// <summary>
        /// Select button closes window on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            //Close search window and give main form focus
            this.Hide();

            //On the final draft, this will cause the program to select a certain invoice that will be returned to the main menu 
            //by being passed as an object

        }

        /// <summary>
        /// Cancel button closes window on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            //Close search window and give main form focus
            this.Hide();

        }

        /// <summary>
        /// The user selected an item in the combo box 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selects object that will be remembered when the Select button is clicked
        }

        /// <summary>
        /// The user selected an item in the combo box 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selects object that will be remembered when the Select button is clicked
        }

        /// <summary>
        /// The user selected an item in the combo box 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selects object that will be remembered when the Select button is clicked
        }
    }
}
