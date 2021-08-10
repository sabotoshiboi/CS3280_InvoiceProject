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


        public string sqlEditInvoice = "Update Invoice";

        public string sqlCreateNewInvoice = "Insert into Invoice";

        public string sqlDeleteInvoice = "DELETE FROM Invoice" +
                "WHERE InvoiceNum = ";

        public string sqlGetInvoiceItems(int ID) {
            return "Select i.ItemDesc" +
            " From ItemDesc i " +
            " Join LineItems l  ON l.ItemCode = i.ItemCode" +
            " WHERE l.InvoiceNum = " + ID;
        }

        public string GetInvoice(int ID)
        {
            return sqlGetInvoice + ID;
        }

        public string GetInvoiceRowCount(int ID)
        {
            return sqlGetInvoiceRows + ID;
        }


        //public string EditInvoice
        //{
        //    get { return sqlEditInvoice +
        //        "Set InvoiceDate = " + InvoiceDate.Date +
        //        "Set TotalCost = " + dInvoiceCost +
        //        "Where InvoiceNum = " + iInvoiceNum; }
        //    set { sqlEditInvoice = value; }
        //}

        //public string CreateNewInvoice
        //{
        //    get {
        //        return CreateNewInvoice +
        //      "VALUES (" + InvoiceDate.Date + ", " + dInvoiceCost + ")";
        //    }

        //    set { CreateNewInvoice = value; }
        //}

        //public string DeleteInvoice
        //{
        //    get { return sqlDeleteInvoice + iInvoiceNum; }
        //    set { sqlDeleteInvoice = value; }
        //}

        //public string GetItems
        //{
        //    get { return sqlGetItems; }
        //    set { sqlGetItems = value; }
        //}


    }
}
