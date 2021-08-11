using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace GroupProject
{
    public class clsMainLogic
    {
        public DataSet ds = new DataSet();
        public clsDataAccess db = new clsDataAccess();
        public clsMainSQL sqlString = new clsMainSQL();
        public List<DataRow> itemList = new List<DataRow>();

        string sSQL;
        public string SSQL
        {
            get { return sSQL; }
            set { sSQL = value; }
        }

        int IRet;

        public int iret
        {
            get { return IRet; }
            set { IRet = value; }
        }

        int InvoiceID;

        public int invoiceid
        {
            get { return InvoiceID; }
            set { InvoiceID = value; }
        }
        int InvoiceCost;

        public int invoicecost
        {
            get { return InvoiceCost; }
            set { InvoiceCost = value; }
        }
        DateTime InvoiceDate;

        public DateTime invoicedate
        {
            get { return InvoiceDate; }
            set { InvoiceDate = value; }
        }


        public void GetInvoiceByID(int ID)
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
                DateTime thisdate = new DateTime(2000, 1, 1);
                invoicedate = thisdate;
                invoicecost = 0;
            }

        }

        public void RemoveItemFromGrid(int InvoiceID, int LineItemNumber)
        {
            SSQL = sqlString.RemoveFromDataGrid(LineItemNumber, InvoiceID);

            db.ExecuteNonQuery(SSQL);
        }

        public void SubtractFromTotalCost(int InvoiceID, int Amount) 
        {
            SSQL = sqlString.SubtractFromTotal(InvoiceID, Amount);
            db.ExecuteNonQuery(SSQL);
        }

        public void UpdateItemList()
        {
            SSQL = sqlString.getItemList;
            ds = db.ExecuteSQLStatement(SSQL, ref IRet);
        }

       public void InsertItemIntoInvoice(int InvoiceID, int LineNum, string ItemCode)
        {
            SSQL = sqlString.InsertItemIntoInvoice(InvoiceID, LineNum, ItemCode);
            db.ExecuteNonQuery(SSQL);
        }

        public void AddToTotalCost(int InvoiceID, int Amount)
        {
            SSQL = sqlString.AddToTotal(InvoiceID, Amount);
            db.ExecuteNonQuery(SSQL);
        }
    }
}
