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
    class clsItemsSQL
    {
        private clsDataAccess db;
        /// <summary>
        /// this method helps display information for potential errors
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
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// this method will return the data from a specific invoice number on the LineItems table
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <returns></returns>
        public string SelectInvoiceData(string sItemCode)

        {
            try
            {
                string sSQL = "SELECT DISTINCT(sInvoiceNum) FROM LineItems WHERE ItemCode =" + sItemCode;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// this method will return all item information from ItemDesc table
        /// </summary>
        /// <returns></returns>
        public List<clsItemsLogic> SelectItemData()
        {
            try
            {
                //create data set
                DataSet ds;

                //number of return values
                int iRet = 0;

                //create items list
                List<clsItemsLogic> lstItems = new List<clsItemsLogic>();

                //create the string variable holding the SQL statement to get flgiths
                string sSQL;

                //creating a clsFlight object to hold flight dataset
                clsItemsLogic clsItemsLogic;

                //defining a database to hold the row slected by the SQL
                db = new clsDataAccess();

                sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                //loop through all the values
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //create list of flights
                    clsItemsLogic = new clsItemsLogic();
                    clsItemsLogic.ItemCode = (string)ds.Tables[0].Rows[i][0];
                    clsItemsLogic.ItemDesc = ds.Tables[0].Rows[i]["ItemDesc"].ToString();
                    clsItemsLogic.ItemCost = Convert.ToInt32(ds.Tables[0].Rows[i]["Cost"]);
                    lstItems.Add(clsItemsLogic);
                }

                return lstItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// this method will pull up a specific items whos infromation we want to edit
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sItemCode"></param>
        /// <param name="sCost"></param>
        /// <returns></returns>
        public void UpdateItemData(string sItemDesc, string sItemCode, int sCost)
        {
            try
            {
                string sSQL = "UPDATE ItemDesc SET ItemDesc = " + sItemDesc + ", Cost = " + sCost + " WHERE ItemCode =" + sItemCode;
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            } 
        }

        /// <summary>
        /// this method will allow the user to add a new item
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <param name="sItemDesc"></param>
        /// <param name="sCost"></param>
        /// <returns></returns>
        public void AddNewItem(string sItemCode, string sItemDesc, int sCost)
        {
            try
            {
                string sSQL = "INSERT INTO ItemDesc(ItemCode, ItemDesc, Cost) VALUES(" + sItemCode + ", " + sItemDesc + ", " + sCost + ")";
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

        /// <summary>
        /// this method will allow users to delete items
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public void DeleteItem(string sItemCode)
        {
            try
            {
                string sSQL = "DELETE FROM ItemDesc WHERE ItemCode = " + sItemCode;
                db.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }
    }
}
