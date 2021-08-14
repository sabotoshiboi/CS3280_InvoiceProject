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
        clsDataAccess db;

        clsSearchSQL clsSearchSQL = new clsSearchSQL();

        clsSearchLogic busLog = new clsSearchLogic();

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
            //On the final draft, this will cause the program to select a certain invoice that will be returned to the main menu 
            //by being passed as an object
            string invoice;

            try
            {
                clsSearchLogic Invoice = (clsSearchLogic)DataGrid.SelectedItem;
                invoice = LabelSelectedInvoiceNum.Content.ToString();
                InvoiceNum = invoice;

                //Don't pay too much attention to the syntax right now.
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
            //While selecting a date or total, the combo box is reset for the invoice number
            //while selecting the invoice number, both other boxes are reset

            //Selects object that will be remembered when the Select button is clicked
            try
            {

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

            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void LoadComboBox1()
        {
            try
            {
                ComboBox1.Items.Clear();
                busLog.invoiceList.Clear();
                busLog.SelectSearchData();

                for (int i = 0; i < busLog.iret; i++)
                {
                    busLog.invoiceList.Add(busLog.ds.Tables[0].Rows[i]);
                }

                for (int i = 0; i < busLog.invoiceList.Count; i++)
                {
                    ComboBox1.Items.Add(busLog.invoiceList[i][1]);
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void LoadComboBox2()
        {
            try
            {
                ComboBox2.Items.Clear();
                busLog.dateList.Clear();
                busLog.SelectSearchData();

                for (int i = 0; i < busLog.iret; i++)
                {
                    busLog.dateList.Add(busLog.ds.Tables[0].Rows[i]);
                }

                for (int i = 0; i < busLog.dateList.Count; i++)
                {
                    ComboBox2.Items.Add(busLog.dateList[i][1]);
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void LoadComboBox3()
        {
            try
            {
                ComboBox3.Items.Clear();
                busLog.costList.Clear();
                busLog.SelectSearchData();

                for (int i = 0; i < busLog.iret; i++)
                {
                    busLog.costList.Add(busLog.ds.Tables[0].Rows[i]);
                }

                for (int i = 0; i < busLog.costList.Count; i++)
                {
                    ComboBox3.Items.Add(busLog.costList[i][1]);
                }
            }
            catch (Exception ex)
            {
                busLog.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedIndex > -1)
            {
                clsSearchLogic Item = (clsSearchLogic)DataGrid.SelectedItem;
                int invoiceNum = Item.InvoiceNum;
                LabelSelectedInvoiceNum.Content = invoiceNum.ToString();
                main.InvoiceNum = invoiceNum;
            }
            else
            {
                LabelSelectedInvoiceNum.Content = "";
            }
        }
    }
}
