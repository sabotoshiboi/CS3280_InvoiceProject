using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    public class clsMainSQL
    {
        /// <summary>
        /// SQL statement for getting an Invoice
        /// </summary>
        public string sqlGetInvoice = "SELECT *" +
                " FROM Invoices " +
                " WHERE InvoiceNum = ";
        /// <summary>
        /// SQL statement for getting number of rows to check for existence
        /// </summary>
        public string sqlGetInvoiceRows = "SELECT Count(*)" +
                " FROM Invoices " +
                " WHERE InvoiceNum = ";
        /// <summary>
        /// Gets all items in the database
        /// </summary>
        string GetItemList = "Select * From ItemDesc";
        /// <summary>
        /// Getter/Setter method for GetItemList
        /// </summary>
        public string getItemList
        {
            get { return GetItemList; }
            set { GetItemList = value; }
        }
        /// <summary>
        /// SQL statement that gets all item info for displaying in the Data Grid
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string sqlGetInvoiceItems(int ID) {
            return "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost, LineItems.LineItemNum FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + ID;
        }
        /// <summary>
        /// Gets an invoice by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetInvoice(int ID)
        {
            return sqlGetInvoice + ID;
        }
        /// <summary>
        /// Getter method for retrieving the row count
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetInvoiceRowCount(int ID)
        {
            return sqlGetInvoiceRows + ID;
        }
        /// <summary>
        /// Removes an Item from the Invoice
        /// </summary>
        /// <param name="LineItemNum"></param>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public string RemoveFromDataGrid(int LineItemNum, int InvoiceID)
        {
            return "Delete From LineItems Where LineItemNum = " + LineItemNum + " And InvoiceNum = " + InvoiceID;
        }

        /// <summary>
        /// SQL Statement for adding an item to an invoice
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="LineNum"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
       public string InsertItemIntoInvoice(int InvoiceID, int LineNum, string ItemCode)
        {
            return "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values (" + InvoiceID + ", " + LineNum + ", '" + ItemCode + "')";
        }
        /// <summary>
        /// SQL Statement for removing invoice from database
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public string DeleteInvoiceFromInvoice(int InvoiceID)
        {
            return "DELETE From Invoices WHERE InvoiceNum = " + InvoiceID;
        }
        /// <summary>
        /// Deletes all Invoice instances in the LineItems table
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public string DeleteInvoiceFromLine(int InvoiceID)
        {
            return "DELETE From LineItems WHERE InvoiceNum = " + InvoiceID;
        }
        /// <summary>
        /// SQL statement for updating the invoice date
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="newtime"></param>
        /// <returns></returns>
        public string UpdateInvoiceDate(int InvoiceID, DateTime newtime)
        {
            return "Update Invoices Set InvoiceDate = '" + newtime + "' Where InvoiceNum = " + InvoiceID;
        }
        /// <summary>
        /// SQL Statement for creating a new invoice
        /// </summary>
        /// <param name="newDate"></param>
        /// <returns></returns>
        public string CreateNewInvoice(DateTime newDate)
        {
            return "INSERT INTO Invoices (InvoiceDate, TotalCost) Values ('" + newDate + "' , 0)";
        }
        /// <summary>
        /// Check to see if a invoice exists
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public string ValidateInvoice(int InvoiceID)
        {
            return "Select InvoiceNum from Invoices Where InvoiceNum = " + InvoiceID;
        }
        /// <summary>
        /// Gets the sum of all item costs in an invoice
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public string GetCostSum(int InvoiceID)
        {
            return "Select Sum(ItemDesc.Cost) from ItemDesc, LineItems Where LineItems.ItemCode = ItemDesc.ItemCode AND LineItems.InvoiceNum = " + InvoiceID;
        }
        /// <summary>
        /// Updates the total cost with the sum of the item costs
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public string UpdateCost(int InvoiceID, int Amount)
        {
            return "Update Invoices Set TotalCost = " + Amount + " Where InvoiceNum = " + InvoiceID;
        }
        /// <summary>
        /// Gets the number of the next invoice number that is to be created
        /// </summary>
        public string GetNewInvoiceNumber = "Select Max(InvoiceNum) From Invoices";

    }
}
