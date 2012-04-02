using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.Game
{
    public partial class WindowsComboBox : ComboBox
    {
        List<IMenuParts> menuParts = new List<IMenuParts>();
        /// <summary>
        /// Initialize
        /// </summary>
        public WindowsComboBox()
        {
            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbWindows.Add(this);
        }
        public WindowsComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //this.DropDownStyle = ComboBoxStyle.DropDownList;

            Global.CbWindows.Add(this);
        }
        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(bool memorize)
        {
            this.Items.Clear();
            menuParts.Clear();
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            // Add All Items To list

            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }
        /// <summary>
        /// Get Selected Event
        /// </summary>
        /// <returns></returns>
        public IMenuParts Data()
        {
            if (this.SelectedIndex > -1)
                return menuParts[this.SelectedIndex];
            else
            {
                MenuWindow dd = new MenuWindow();
                dd.ID = -10;
                dd.Name = "{No Window}";
                return dd;
            }
        }

        internal void SetIndexFromID(int i)
        {
            if (i > -1)
            {
                int j = 0;
                foreach (IMenuParts part in menuParts)
                {
                    if (part.ID == i)
                        break;
                    j++;
                }
                this.SelectedIndex = j;
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            Global.CbWindows.Remove(this);

            base.Dispose(disposing);
        }

        
    }
}
