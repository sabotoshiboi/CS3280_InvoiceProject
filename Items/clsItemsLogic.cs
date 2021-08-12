using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject
{
    public class clsItemsLogic
    {
        private string itemCode;
        private string itemDesc;
        private int itemCost;

        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        public string ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }

        public int ItemCost
        {
            get { return itemCost; }
            set { itemCost = value; }
        }

        public override string ToString()
        {
            return ItemCode + " | " + ItemDesc + " | " + ItemCost;
        }
    }
}
