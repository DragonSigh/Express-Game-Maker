using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace EGMGame.Controls
{
    public class DataListBox : ListBox
    {
        List<string> dataList = new List<string>();

        #region Properties
        [Browsable(false)]
        public List<string> DataList
        {	
			//When first loaded set property with the first item in the rule list.
            get { return dataList; }
            set { dataList = value; RefreshList(); }
        }
        #endregion

        #region Methods
        // Refresh List
        public void RefreshList()
        {
            int index = this.SelectedIndex;
            // Clear List
            this.Items.Clear();
            // List All Items
            foreach (string item in DataList)
            {
                this.Items.Add(item);
            }
            // 
            if (index > this.Items.Count - 1)
                this.SelectedIndex = this.Items.Count - 1;
            else
                this.SelectedIndex = index;
        }
        // Get Index From Text
        internal int GetIndexFromText(string p)
        {
            int index = 0;
            foreach (string item in this.Items)
            {
                if (item == p) break;
                index++;
            }
            return index;
        }
        #endregion
    }
}
