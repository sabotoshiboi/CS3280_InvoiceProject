using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    public class clsMainSQL
    {
        public string sqlGetInvoice = "SELECT *" +
                " FROM Invoices " +
                " WHERE InvoiceNum = ";

        public string sqlGetInvoiceRows = "SELECT Count(*)" +
                " FROM Invoices " +
                " WHERE InvoiceNum = ";

        string GetItemList = "Select * From ItemDesc";

        public string getItemList
        {
            get { return GetItemList; }
            set { GetItemList = value; }
        }

        public string sqlGetInvoiceItems(int ID) {
            return "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost, LineItems.LineItemNum FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + ID;
        }

        public string GetInvoice(int ID)
        {
            return sqlGetInvoice + ID;
        }

        public string GetInvoiceRowCount(int ID)
        {
            return sqlGetInvoiceRows + ID;
        }

        public string RemoveFromDataGrid(int LineItemNum, int InvoiceID)
        {
            return "Delete From LineItems Where LineItemNum = " + LineItemNum + " And InvoiceNum = " + InvoiceID;
        }


       public string InsertItemIntoInvoice(int InvoiceID, int LineNum, string ItemCode)
        {
            return "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values (" + InvoiceID + ", " + LineNum + ", '" + ItemCode + "')";
        }

        public string DeleteInvoiceFromInvoice(int InvoiceID)
        {
            return "DELETE From Invoices WHERE InvoiceNum = " + InvoiceID;
        }

        public string DeleteInvoiceFromLine(int InvoiceID)
        {
            return "DELETE From LineItems WHERE InvoiceNum = " + InvoiceID;
        }

        public string UpdateInvoiceDate(int InvoiceID, DateTime newtime)
        {
            return "Update Invoices Set InvoiceDate = '" + newtime + "' Where InvoiceNum = " + InvoiceID;
        }

        public string CreateNewInvoice(DateTime newDate)
        {
            return "INSERT INTO Invoices (InvoiceDate, TotalCost) Values ('" + newDate + "' , 0)";
        }

        public string ValidateInvoice(int InvoiceID)
        {
            return "Select InvoiceNum from Invoices Where InvoiceNum = " + InvoiceID;
        }

        public string GetCostSum(int InvoiceID)
        {
            return "Select Sum(ItemDesc.Cost) from ItemDesc, LineItems Where LineItems.ItemCode = ItemDesc.ItemCode AND LineItems.InvoiceNum = " + InvoiceID;
        }

        public string UpdateCost(int InvoiceID, int Amount)
        {
            return "Update Invoices Set TotalCost = " + Amount + " Where InvoiceNum = " + InvoiceID;
        }

        public string GetNewInvoiceNumber = "Select Max(InvoiceNum) From Invoices";

    }
}
