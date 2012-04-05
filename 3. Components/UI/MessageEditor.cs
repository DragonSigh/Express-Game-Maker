//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Library;
using EGMGame.Dialogs;

namespace EGMGame.Controls
{
    public partial class MessageEditor : UserControl
    {
        public FontData CurrentFont;

        public Color LastSelectedColor;
        public FontStyleData LastSelectedStyle;
        public VariableData LastSelectedVariable;
        public StringData LastSelectedString;
        public DatabaseHelper LastSelectedData;

        public string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        ToolStripNumericUpDown sizeBox;
        Color[] allowedColors;
        string[] colorNames;

        public EventHandler TextChangeEvent;

        public MessageEditor()
        {
            InitializeComponent();
            toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();

            allowedColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black,
                Color.Brown,
                Color.Gray,
                Color.Purple,
                Color.Yellow,
                Color.Pink,
                Color.Orange,
                Color.Gold,
                Color.Cyan
            };
            colorNames = new string[]
            {
                "Red",
                "Green",
                "Blue",
                "White",
                "Black",
                "Brown",
                "Gray",
                "Purple",
                "Yellow",
                "Pink",
                "Orange",
                "Gold",
                "Cyan"
            };

            PopulateColors();

            sizeBox = new ToolStripNumericUpDown();
            ((NumericUpDown)sizeBox.Control).Maximum = 100;
            ((NumericUpDown)sizeBox.Control).Minimum = 1;
            ((NumericUpDown)sizeBox.Control).ValueChanged += new EventHandler(MessageEditor_ValueChanged);
            toolStrip1.Items.Insert(2, sizeBox);
        }

        void MessageEditor_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void SetupProperty(FontData obj)
        {
            if (obj != null)
            {
                CurrentFont = obj;

                PopulateStyles();
                PopulateVariables();
                PopulateStrings();
            }
            else
            {
                CurrentFont = null;
                styleBtn.DropDownItems.Clear();
            }
        }
        public void Repopulate()
        {
            PopulateVariables();
            PopulateStrings();
        }
        private void PopulateStyles()
        {
            styleBtn.DropDownItems.Clear();

            foreach (FontStyleData data in CurrentFont.Styles)
            {
                if (data.Name != "Regular")
                {
                    if (data.MaterialID > -1)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = data.ID.ToString() + ". " + data.Name;
                        item.Tag = data;
                        item.Click += new EventHandler(styleMenuItem_Click);
                        styleBtn.DropDownItems.Add(item);
                    }
                }
            }
        }
        private void PopulateColors()
        {
            for (int i = 0; i < allowedColors.Length; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = colorNames[i];
                item.Tag = allowedColors[i];
                item.Click += new EventHandler(colorMenuItem_Click);
                colorBtn.DropDownItems.Add(item);
            }
        }
        private void PopulateVariables()
        {
            variableButton.DropDownItems.Clear();

            List<NodeCategory> categories = Global.Project.Categories[typeof(VariableData).ToString()];

            foreach (NodeCategory c in categories)
            {
                ToolStripMenuItem item = new ToolStripMenuItem() { Text = c.Name };
                variableButton.DropDownItems.Add(item);
            }
            foreach (VariableData var in GameData.Variables.Values)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = var.Name;
                item.Tag = var;
                item.Click += new EventHandler(variableMenuItem_Click);
                ((ToolStripMenuItem)variableButton.DropDownItems[var.Category]).DropDownItems.Add(item);
            }
        }

        private void PopulateStrings()
        {
            btnString.DropDownItems.Clear();

            List<NodeCategory> categories = Global.Project.Categories[typeof(StringData).ToString()];

            foreach (NodeCategory c in categories)
            {
                ToolStripMenuItem item = new ToolStripMenuItem() { Text = c.Name };
                btnString.DropDownItems.Add(item);
            }
            foreach (StringData var in GameData.Strings.Values)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = var.Name;
                item.Tag = var;
                item.Click += new EventHandler(stringMenuItem_Click);
                ((ToolStripMenuItem)btnString.DropDownItems[var.Category]).DropDownItems.Add(item);
            }
        }
        /// <summary>
        /// Apply last selected style.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void styleBtn_ButtonClick(object sender, EventArgs e)
        {
            if (LastSelectedStyle != null)
                AddTag("s", LastSelectedStyle.ID.ToString());
        }

        private void colorBtn_ButtonClick(object sender, EventArgs e)
        {
            if (LastSelectedColor != null)
                AddTag("c", ColorToHex(LastSelectedColor));
        }

        private void variableButton_ButtonClick(object sender, EventArgs e)
        {
            if (LastSelectedVariable != null)
                AddDataTag("v", LastSelectedVariable.ID.ToString());
        }

        private void btnString_ButtonClick(object sender, EventArgs e)
        {
            if (LastSelectedString != null)
                AddDataTag("t", LastSelectedString.ID.ToString());
        }

        private void colorMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            Color chosenColor = (Color)item.Tag;//new Color();

            //foreach (Color color in allowedColors)
            //{
            //    if ((Color)item.Tag == color)
            //        chosenColor = color;
            //}
            string hex = ColorToHex(chosenColor);
            AddTag("c", hex);

            LastSelectedColor = chosenColor;
        }

        private void variableMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            VariableData data = (VariableData)item.Tag;

            AddDataTag("v", data.ID.ToString());

            LastSelectedVariable = data;
        }

        private void stringMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            StringData data = (StringData)item.Tag;

            AddDataTag("t", data.ID.ToString());

            LastSelectedString = data;
        }

        //private void databaseMenuItem_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem item = (ToolStripMenuItem)sender;

        //    DatabaseHelper data = (DatabaseHelper)item.Tag;

        //    AddDataTag("d", data.DatabaseID.ToString() + "," +
        //            data.DatasetID.ToString() + "," +
        //            data.DataPropertyID.ToString());

        //    LastSelectedData = data;
        //}


        void propertyItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private string ColorToHex(Color rgb)
        {
            string red = Convert.ToString(rgb.R, 16);
            if (red.Length < 2) red = "0" + red;
            string green = Convert.ToString(rgb.G, 16);
            if (green.Length < 2) green = "0" + green;
            string blue = Convert.ToString(rgb.B, 16);
            if (blue.Length < 2) blue = "0" + blue;

            return red.ToUpper() + green.ToUpper() + blue.ToUpper();
        }

        private void styleMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            FontStyleData chosenStyle = (FontStyleData)item.Tag;//new FontStyleData() ;

            //foreach (FontStyleData style in CurrentFont.Styles)
            //{
            //    string ID = item.Text.Substring(0,item.Text.IndexOf('.'));
            //    if(int.Parse(ID) == style.ID)
            //        chosenStyle = style;
            //}
            AddTag("s", chosenStyle.ID.ToString());

            LastSelectedStyle = chosenStyle;
        }

        private void AddTag(string tag, string tagValue)
        {
            // determine the string to append in the text box
            string startString = "[" + tag + "=" + tagValue + "]";
            string closeString = "[/" + tag + "]";

            // if there is text selected
            if (textBox.SelectionLength > 0)
            {
                int i = textBox.SelectionStart;
                int l = textBox.SelectionLength;
                textBox.Text = textBox.Text.Insert(i, startString);
                textBox.Text = textBox.Text.Insert((i + l + startString.Length), closeString);
                textBox.Select(i, (l + startString.Length + closeString.Length));
                textBox.Update();
            }
            else
            {
                int i = textBox.SelectionStart;
                textBox.Text = textBox.Text.Insert(i, startString + closeString);
                textBox.SelectionStart = i + startString.Length;
                textBox.Update();
            }
        }
        private void AddDataTag(string tag, string tagValue)
        {
            string startString = "[" + tag + "=" + tagValue + "]";
            int i = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(i, startString);
            textBox.SelectionStart = i + startString.Length;
            textBox.Update();
        }

        private void chooseColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorPickerDialog dialog = new ColorPickerDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Color c = new Color(dialog.colorPickerCtrl.SelectedColor.R,
                    dialog.colorPickerCtrl.SelectedColor.G,
                dialog.colorPickerCtrl.SelectedColor.B,
                dialog.colorPickerCtrl.SelectedColor.A);
                string hex = ColorToHex(c);
                AddTag("c", hex);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChangeEvent != null)
                TextChangeEvent(textBox, EventArgs.Empty);
        }

        private void variableButton_DropDownOpened(object sender, EventArgs e)
        {

        }
    }
    public class DatabaseHelper
    {
        public DatabaseHelper(int db, int ds, int dp)
        {
            DatabaseID = db;
            DatasetID = ds;
            DataPropertyID = dp;
        }
        public int DatabaseID = -1;
        public int DatasetID = -1;
        public int DataPropertyID = -1;
    }
}
