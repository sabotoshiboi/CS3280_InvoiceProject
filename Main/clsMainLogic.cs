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
        DataSet ds = new DataSet();
        clsDataAccess db = new clsDataAccess();
        clsMainSQL sqlString = new clsMainSQL();
        public List<string> listItems = new List<string>();

        string sSQL;
        public string SSQL
        {
            get { return sSQL; }
            set { sSQL = value; }
        }

        int IRet;

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

                for(int i = 0; i < IRet; i++)
                {
                    listItems.Add(ds.Tables[0].Rows[0][i].ToString());
                }


                
            }
            else
            {
                DateTime thisdate = new DateTime(2000, 1, 1);
                invoicedate = thisdate;
                invoicecost = 0;
            }

        }
    }
}
