using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    class clsItemsSQL
    {

        /// <summary>
        /// this method will return the data from a specific invoice number on the LineItems table
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <returns></returns>
        public string SelectInvoiceData(int sInvoiceNum)

        {
            string sSQL = "SELECT DISTINCT(sInvoiceNum) FROM LineItems WHERE ItemCode =" + sInvoiceNum;
            return sSQL;
        }

        /// <summary>
        /// this method will return all item information from ItemDesc table
        /// </summary>
        /// <returns></returns>
        public string SelectItemData()
        {
            string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
            return sSQL;
        }

        /// <summary>
        /// this method will pull up a specific items whos infromation we want to edit
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sItemCode"></param>
        /// <param name="sCost"></param>
        /// <returns></returns>
        public string UpdateItemData(char sItemDesc, char sItemCode, double sCost)
        {
            string sSQL = "UPDATE ItemDesc SET ItemDesc = " + sItemDesc + ", Cost = " + sCost + " WHERE ItemCode =" + sItemCode;
            return sSQL;
        }

        /// <summary>
        /// this method will allow the user to add a new item
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        /// <returns></returns>
        public string AddNewItem(char sItemCode, char sItemDesc, double sCost)
        {
            string sSQL = "INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES(" + sItemCode + ", " + sItemDesc + ", " + sCost + ")";
            return sSQL;
        }

        /// <summary>
        /// this method will allow users to delete items
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string DeleteItem(char sItemCode)
        {
            string sSQL = "DELETE FROM ItemDesc WHERE ItemCode = " + sItemCode;
            return sSQL;
        }
    }
}
