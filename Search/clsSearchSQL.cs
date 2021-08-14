using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    /// <summary>
    /// clsSearchSQL contains all SQL statements for the Search Window
    /// </summary>
    public class clsSearchSQL
    {

        /// <summary>
        /// SQL statement for all invoice data
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectAllInvoiceData()

        {
            string sSQL = "SELECT DISTINCT * FROM Invoices";

            return sSQL;

        }

        ////// <summary>
        /// SQL statement for all invoice data with a specific ID
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecID(string sInvoiceID)

        {
            string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;

            return sSQL;

        }

        /// <summary>
        /// SQL statement for all invoice data with a specific ID and date/time
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecIDDate(string sInvoiceID, DateTime sDateTime)

        {
            string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID + " AND InvoiceDate = #" + sDateTime + "#";

            return sSQL;

        }

        /// <summary>
        /// SQL statement for all invoice data with a specific ID, date/time, and cost
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecIDDateCost(string sInvoiceID, DateTime sDateTime, int sTotalCost)

        {
            string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID + " AND InvoiceDate = #" + sDateTime + "# AND TotalCost = " + sTotalCost;

            return sSQL;

        }

        /// <summary>
        /// SQL statement for all invoice data with a specific cost
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecCost(int sTotalCost)

        {
            string sSQL = "SELECT DISTINCT * FROM Invoices WHERE TotalCost = " + sTotalCost;

            return sSQL;

        }

        /// <summary>
        /// SQL statement for all invoice data with a specific cost and date/time
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecCostDate(int sTotalCost, DateTime sDateTime)

        {
            string sSQL = "SELECT DISTINCT * FROM Invoices WHERE TotalCost = " + sTotalCost + " AND InvoiceDate = #" + sDateTime + "#";

            return sSQL;

        }

        /// <summary>
        /// SQL statement for all invoice data with a specific date/time
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public string SelectInvoiceDataSpecDate(DateTime sDateTime)

        {
            string sSQL = "SELECT DISTINCT * FROM Invoices WHERE InvoiceDate = #" + sDateTime + "#";

            return sSQL;

        }


    }
}
