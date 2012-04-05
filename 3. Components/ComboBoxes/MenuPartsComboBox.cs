//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    public partial class MenuPartsComboBox : ComboBox
    {

        List<IMenuParts> menuParts = new List<IMenuParts>();
        /// <summary>
        /// Initialize
        /// </summary>
        public MenuPartsComboBox()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public MenuPartsComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            e.DrawBackground();
            if (e.Index > -1)
            {
                if (this.Enabled)
                {
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, System.Drawing.Brushes.Black, e.Bounds);
                }
                else
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, System.Drawing.Brushes.Gray, e.Bounds);

                if (e.Index == this.SelectedIndex)
                {
                    e.DrawFocusRectangle();
                }
            }
        }

        /// <summary>
        /// Refreshes List
        /// </summary>
        public void RefreshList(bool memorize)
        {
            // Memorize
            int i = -1;
            if (memorize)
                i = this.SelectedIndex;
            this.Items.Clear();
            menuParts.Clear();
            // Add All Items To list
            MenuData menu = (MenuData)MainForm.menuEditor.addRemoveList.Data();
            if (menu != null)
            {
                this.Items.Add("This Menupart");
                IMenuParts m = new MenuWindow();
                m.ID = -1;
                m.Name = "This Menupart";
                menuParts.Add(m);
                foreach (IMenuParts e in menu.MenuParts)
                {
                    this.Items.Add(e.Name + " (" + e.ID + ")");
                    menuParts.Add(e);
                    AddChildParts(e);
                }
            }
            // Dump
            if (memorize && this.Items.Count > i)
                this.SelectedIndex = i;
            if (this.Items.Count > 0 && this.SelectedIndex == -1)
                this.SelectedIndex = 0;
        }

        private void AddChildParts(IMenuParts menu)
        {
            foreach (IMenuParts e in menu.MenuParts)
            {
                this.Items.Add(e.Name + " (" + e.ID + ")");
                menuParts.Add(e);
                AddChildParts(e);
            }
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
                IMenuParts dd = new MenuWindow();
                dd.ID = -10;
                dd.Name = "{No Menupart}";
                return dd;
            }
        }

        public void Select(int id)
        {
            int j = 0;
            foreach (IMenuParts e in menuParts)
            {
                if (e.ID == id && j < this.Items.Count)
                {
                    this.SelectedIndex = j;
                    return;
                }
                j++;
            }
        }

        private void CheckChildParts(IMenuParts parent, int id, ref int j)
        {
            foreach (IMenuParts e in parent.MenuParts)
            {
                if (e.ID == id && j < this.Items.Count)
                {
                    this.SelectedIndex = j;
                    return;
                }
                j++;
                CheckChildParts(e, id, ref j);
            }
        }
    }
}
