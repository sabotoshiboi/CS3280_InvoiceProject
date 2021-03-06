using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Windows;

namespace GroupProject
{
    public class clsSearchLogic
    {
        private clsDataAccess db = new clsDataAccess();
        /// <summary>
        /// Instance of the Data Set Class
        /// </summary>
        public DataSet ds = new DataSet();
        /// <summary>
        /// Instance of the SQL class
        /// </summary>
        public clsSearchSQL sqlString = new clsSearchSQL();
        /// <summary>
        /// Instance of the Item List
        /// </summary>
        public List<DataRow> invoiceList = new List<DataRow>();
        /// <summary>
        /// Instace of the item list that is queued to be inserted
        /// </summary>
        public List<DataRow> dateList = new List<DataRow>();
        /// <summary>
        /// Instance of the Item List
        /// </summary>
        public List<DataRow> costList = new List<DataRow>();

        public List<DataRow> filterList = new List<DataRow>();

        /// <summary>
        /// Holds InvoiceNum
        /// </summary>
        private int invoiceNum;
        /// <summary>
        /// Holds InvoiceDate
        /// </summary>
        private string invoiceDate;
        /// <summary>
        /// Holds totalCost
        /// </summary>
        private int totalCost;

        /// <summary>
        /// Holds the number of rows the Query returned
        /// </summary>
        int IRet;

        /// <summary>
        /// Getter/Setter method for IRet
        /// </summary>
        public int iret
        {
            get { return IRet; }
            set { IRet = value; }
        }

        /// <summary>
        /// String that holds SQL statements
        /// </summary>
        string sSQL;

        /// <summary>
        /// Setter/Getter Method for sSQL
        /// </summary>
        public string SSQL
        {
            get { return sSQL; }
            set { sSQL = value; }
        }

        /// <summary>
        /// Setter/Getter Method for the InvoiceNum
        /// </summary>
        public int InvoiceNum
        {
            get { return invoiceNum; }
            set { invoiceNum = value; }
        }

        /// <summary>
        /// Setter/Getter Method for the InvoiceDate
        /// </summary>
        public string InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
        }

        /// <summary>
        /// Setter/Getter Method for the TotalCost
        /// </summary>
        public int TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        /// <summary>
        /// Overriding the ToString() method
        /// </summary>
        public override string ToString()
        {
            return InvoiceNum + " | " + InvoiceDate + " | " + TotalCost;
        }

        /// <summary>
        /// Error handler
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        public void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Select search data logic for a selected invoice
        /// </summary>
        public List<clsSearchLogic> SelectSearchData()
        {
            try
            {
                //create data set
                DataSet ds;

                //number of return values
                int iRet = 0;

                //create items list
                List<clsSearchLogic> lstInvoices = new List<clsSearchLogic>();

                //create the string variable holding the SQL statement to get invoices
                string sSQL;

                //creating a clsFlight object to hold invoice dataset
                clsSearchLogic clsSearchLogic;

                //defining a database to hold the row slected by the SQL
                db = new clsDataAccess();

                sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices";

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                //loop through all the values
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //create list of invoices
                    clsSearchLogic = new clsSearchLogic();
                    clsSearchLogic.InvoiceNum = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    clsSearchLogic.InvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                    clsSearchLogic.totalCost = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalCost"]);
                    lstInvoices.Add(clsSearchLogic);
                }

                return lstInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void GetInvoices()
        {
            SSQL = sqlString.SelectAllInvoiceData();
            ds = db.ExecuteSQLStatement(SSQL, ref IRet);
        }

       
    }
}
