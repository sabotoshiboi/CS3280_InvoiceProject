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
        private double itemCost;

        public string ItemCode
        {
            get { return ItemCode; }
            set { itemCode = value; }
        }

        public string ItemDesc
        {
            get { return ItemDesc; }
            set { itemDesc = value; }
        }

        public double ItemCost
        {
            get { return ItemCost; }
            set { itemCost = value; }
        }

        public override string ToString()
        {
            return ItemCode + " | " + ItemDesc + " | " + ItemCost;
        }
    }
}
