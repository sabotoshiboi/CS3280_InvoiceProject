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
    public class clsMainLogic
    {
        /// <summary>
        /// Instance of the Data Set Class
        /// </summary>
        public DataSet ds = new DataSet();
        /// <summary>
        /// Instance of the Data Access Class
        /// </summary>
        public clsDataAccess db = new clsDataAccess();
        /// <summary>
        /// Instance of the SQL class
        /// </summary>
        public clsMainSQL sqlString = new clsMainSQL();
        /// <summary>
        /// Instance of the Item List
        /// </summary>
        public List<DataRow> itemList = new List<DataRow>();
        /// <summary>
        /// Instace of the item list that is queued to be inserted
        /// </summary>
        public List<DataRow> itemInsertList = new List<DataRow>();

        /// <summary>
        /// Keeps track of whether the invoice is getting editted
        /// </summary>
        public bool editing = false;
        /// <summary>
        /// Keeps track of whether an invoice is being created
        /// </summary>
        public bool creating = false;
        /// <summary>
        /// String that holds SQL statements
        /// </summary>
        string sSQL;

        public int InvoiceNum;

        /// <summary>
        /// Setter/Getter Method for sSQL
        /// </summary>
        public string SSQL
        {
            get { return sSQL; }
            set { sSQL = value; }
        }

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
        /// Variable that occasionally holds the cost of a certain invoice
        /// </summary>
        int InvoiceCost;
        /// <summary>
        /// Getter/Setter Method for InvoiceCost
        /// </summary>
        public int invoicecost
        {
            get { return InvoiceCost; }
            set { InvoiceCost = value; }
        }
        /// <summary>
        /// Occasionally holds the value for the invoice date
        /// </summary>
        DateTime InvoiceDate;

        /// <summary>
        /// Getter/Setter method for the InvoiceDate
        /// </summary>
        public DateTime invoicedate
        {
            get { return InvoiceDate; }
            set { InvoiceDate = value; }
        }

        /// <summary>
        /// Returns a certain invoice by the InvoiceNum
        /// </summary>
        /// <param name="ID"></param>
        public void GetInvoiceByID(int ID)
        {
            try
            {
                int count = Int32.Parse(db.ExecuteScalarSQL(sqlString.GetInvoiceRowCount(ID)));
                SSQL = sqlString.GetInvoice(ID);
                ds = db.ExecuteSQLStatement(SSQL, ref IRet);
                if (count > 0)
                {
                    invoicedate = DateTime.Parse(ds.Tables[0].Rows[0][1].ToString());
                    invoicecost = Int32.Parse(ds.Tables[0].Rows[0][2].ToString());

                    SSQL = sqlString.sqlGetInvoiceItems(ID);
                    ds = db.ExecuteSQLStatement(SSQL, ref IRet);

                }
                else
                {
                    DateTime thisdate = new DateTime(2021, 1, 1);
                    invoicedate = thisdate;
                    invoicecost = 0;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Removes a selected item from the invoice
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="LineItemNumber"></param>
        public void RemoveItemFromGrid(int InvoiceID, int LineItemNumber)
        {
            try
            {
                SSQL = sqlString.RemoveFromDataGrid(LineItemNumber, InvoiceID);
                db.ExecuteNonQuery(SSQL);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Reloads the item list with all the items in the database
        /// </summary>
        public void UpdateItemList()
        {
            try
            {
                SSQL = sqlString.getItemList;
                ds = db.ExecuteSQLStatement(SSQL, ref IRet);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Inserts and item into the invoice
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="LineNum"></param>
        /// <param name="ItemCode"></param>
        public void InsertItemIntoInvoice(int InvoiceID, int LineNum, string ItemCode)
        {
            try
            {
                SSQL = sqlString.InsertItemIntoInvoice(InvoiceID, LineNum, ItemCode);
                db.ExecuteNonQuery(SSQL);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Deletes an invoice from the database
        /// </summary>
        /// <param name="InvoiceID"></param>
        public void RemoveInvoice(int InvoiceID)
        {
            try
            {
                SSQL = sqlString.DeleteInvoiceFromLine(InvoiceID);
                db.ExecuteNonQuery(SSQL);
                SSQL = sqlString.DeleteInvoiceFromInvoice(InvoiceID);
                db.ExecuteNonQuery(SSQL);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Updates the Date for an invoice
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="newTime"></param>
        public void UpdateInvoiceTime(int InvoiceID, DateTime newTime)
        {
            try
            {
                SSQL = sqlString.UpdateInvoiceDate(InvoiceID, newTime);
                db.ExecuteNonQuery(SSQL);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Inserts a new invoice into the database
        /// </summary>
        /// <param name="newDate"></param>
        public void CreateNewInvoice(DateTime newDate)
        {
            try
            {
                SSQL = sqlString.CreateNewInvoice(newDate);
                db.ExecuteNonQuery(SSQL);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Retrives the InvoiceNum of the newly created Invoice
        /// </summary>
        /// <returns></returns>
        public string GetnewInvoiceID()
        {
            SSQL = sqlString.GetNewInvoiceNumber;
            return db.ExecuteScalarSQL(SSQL);
        }
        /// <summary>
        /// Gets the sum of all the item costs for a certain invoice
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public int GetCostSum(int InvoiceID)
        {

            SSQL = sqlString.GetCostSum(InvoiceID);
            return Int32.Parse(db.ExecuteScalarSQL(SSQL));


        }
        /// <summary>
        /// Takes the sum of all the items for a certain invoice and updates the TotalCost value
        /// </summary>
        /// <param name="InvoiceID"></param>
        public void UpdateCost(int InvoiceID)
        {
            try
            {
                invoicecost = GetCostSum(InvoiceID);
                SSQL = sqlString.UpdateCost(InvoiceID, GetCostSum(InvoiceID));
                db.ExecuteNonQuery(SSQL);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Checks to see if the inputted Invoice number matches with an existing Invoice in the database
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public bool ValidInvoice(string InvoiceID)
        {

            if (InvoiceID != "")
            {
                SSQL = sqlString.ValidateInvoice(Int32.Parse(InvoiceID));
                if (db.ExecuteScalarSQL(SSQL) != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// Handles all errors that are thrown
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
    }
}
