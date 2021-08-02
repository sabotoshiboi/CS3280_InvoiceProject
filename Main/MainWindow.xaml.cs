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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wndSearch SearchWindowForm;
        wndItems ItemWindowForm;
        clsMainSQL sqlClass;
        public MainWindow()
        {
            InitializeComponent();
            sqlClass = new clsMainSQL();

            //A SQL statement will load the combo box with all the needed items so that they can be added to
            //a selected invoice when it is selected.

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
            //ItemWindowForm.ShowDialog();

        }
    }
}
