using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject
{
    /// <summary>
    /// clsSearchSQL contains all SQL statements for the Search Window
    /// </summary>
    public class clsSearchSQL
    {
        wndSearch wndSearch;

        private clsDataAccess db;

        public void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        

        /// <summary>
        /// SQL statement for all invoice data
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectAllInvoiceData()

        {
            try
            {
                return "SELECT DISTINCT * FROM Invoices";
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        string GetAllData;

        /// <summary>
        /// Getter/Setter method for GetItemList
        /// </summary>
        public string getAllData
        {
            get { return GetAllData; }
            set { GetAllData = value; }
        }

        ////// <summary>
        /// SQL statement for all invoice data with a specific ID
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecID(string sInvoiceID)

        {
            try
            {
                string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
                string results = db.ExecuteScalarSQL(sSQL);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// SQL statement for all invoice data with a specific ID and date/time
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecIDDate(string sInvoiceID, DateTime sDateTime)

        {
            try
            {
                string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID + " AND InvoiceDate = #" + sDateTime + "#";
                string results = db.ExecuteScalarSQL(sSQL);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// SQL statement for all invoice data with a specific ID, date/time, and cost
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecIDDateCost(string sInvoiceID, DateTime sDateTime, int sTotalCost)

        {
            try
            {
                string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID + " AND InvoiceDate = #" + sDateTime + "# AND TotalCost = " + sTotalCost;
                string results = db.ExecuteScalarSQL(sSQL);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// SQL statement for all invoice data with a specific cost
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecCost(int sTotalCost)

        {
            try
            {
                string sSQL = "SELECT DISTINCT * FROM Invoices WHERE TotalCost = " + sTotalCost;
                string results = db.ExecuteScalarSQL(sSQL);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// SQL statement for all invoice data with a specific cost and date/time
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecCostDate(int sTotalCost, DateTime sDateTime)

        {
            try
            {
                string sSQL = "SELECT DISTINCT * FROM Invoices WHERE TotalCost = " + sTotalCost + " AND InvoiceDate = #" + sDateTime + "#";
                string results = db.ExecuteScalarSQL(sSQL);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// SQL statement for all invoice data with a specific date/time
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecDate(DateTime sDateTime)

        {
            try
            {
                string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceDate = #" + sDateTime + "#";
                string results = db.ExecuteScalarSQL(sSQL);
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        

        //string sInvoiceID = "";
        //string sTotalCost;
        //string sDateTime;
        //string allInvoices = "SELECT DISTINCT * FROM Invoices";
        //string num = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
        //string costTime = "SELECT DISTINCT * FROM Invoices WHERE TotalCost = " + sTotalCost + " AND InvoiceDate = #" + sDateTime + "#";
        //string invTimeCost = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID + " AND InvoiceDate = #" + sDateTime + "# AND TotalCost = " + sTotalCost;
        //string cost = "SELECT DISTINCT * FROM Invoices WHERE TotalCost = " + sTotalCost;
        //string costTime = "SELECT DISTINCT * FROM Invoices WHERE TotalCost = " + sTotalCost + " AND InvoiceDate = #" + sDateTime + "#";
        //string date = "SELECT DISTINCT * FROM Invoices WHERE InvoiceDate = #" + sDateTime + "#";

    }
}
