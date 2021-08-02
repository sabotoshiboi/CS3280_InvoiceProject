using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject
{
    public class clsMainSQL
    {

        public int iInvoiceNum;
        public DateTime InvoiceDate;
        public double dInvoiceCost;

        public string sqlGetInvoice = "SELECT *" +
                "FROM Invoice " +
                "WHERE InvoiceID = ";

        public string sqlEditInvoice = "Update Invoice";

        public string sqlCreateNewInvoice = "Insert into Invoice";

        public string sqlDeleteInvoice = "DELETE FROM Invoice" +
                "WHERE InvoiceNum = ";

        public string sqlGetItems = "Select ItemDesc" +
            "From ItemDesc";

        public string GetInvoice
        {
            get { return sqlGetInvoice + iInvoiceNum + ""; }
            set { sqlGetInvoice = value; }
        }


        public string EditInvoice
        {
            get { return sqlEditInvoice +
                "Set InvoiceDate = " + InvoiceDate.Date +
                "Set TotalCost = " + dInvoiceCost +
                "Where InvoiceNum = " + iInvoiceNum; }
            set { sqlEditInvoice = value; }
        }

        public string CreateNewInvoice
        {
            get {
                return CreateNewInvoice +
              "VALUES (" + InvoiceDate.Date + ", " + dInvoiceCost + ")";
            }

            set { CreateNewInvoice = value; }
        }

        public string DeleteInvoice
        {
            get { return sqlDeleteInvoice + iInvoiceNum; }
            set { sqlDeleteInvoice = value; }
        }

        public string GetItems
        {
            get { return sqlGetItems; }
            set { sqlGetItems = value; }
        }


    }
}
