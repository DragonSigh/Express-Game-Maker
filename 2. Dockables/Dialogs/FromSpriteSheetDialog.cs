//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using Microsoft.Xna.Framework;

namespace EGMGame.Dialogs
{
    public partial class FromSpriteSheetDialog : Form
    {
        internal AnimationAction Action;
        public bool IsOk;
        public Vector2 Canvas = new Vector2(100, 100);

        public FromSpriteSheetDialog()
        {
            InitializeComponent();

            cbSprites.RefreshList(false, MaterialDataType.Image);

            nudRows.Value = Global.Project.SpriteRows;
            nudCols.Value = Global.Project.SpriteCols;
            nudFrames.Value = Global.Project.SpriteFrames;
            listBox1.Items.Clear();
            foreach (object item in Global.Project.SpriteDirections)
            {
                listBox1.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbSprites.Data().ID > -1)
            {
                bool layer = false;
                // if (DialogResult.Yes == MessageBox.Show("Layer on top if frame exists?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                // layer = true;
                Global.Project.SpriteRows = nudRows.Value;
                Global.Project.SpriteCols = nudCols.Value;
                Global.Project.SpriteFrames = nudFrames.Value;
                Global.Project.SpriteDirections.Clear();
                foreach (object item in listBox1.Items)
                {
                    Global.Project.SpriteDirections.Add(item);
                }

                int sira = 0;
                for (int j = 0; j < nudRows.Value; j++)
                {
                    int row = GetIndex(j);
                    for (int col = 0; col < nudCols.Value; col++)
                    {
                        AnimationFrame a;
                        if (!layer || col >= Action.Directions[row].Count)
                        {
                            a = new AnimationFrame();
                            a.ID = Global.GetID(Action.Directions[row]);
                            Action.Directions[row].Add(a);
                        }
                        else
                        {
                            a = Action.Directions[row][col];
                        }
                        a.TimeElapse = (int)nudFrames.Value;
                        a.Name = a.TimeElapse.ToString() + " Frames";

                        // History
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(a, new DataAddDelegate(MainForm.animationEditor.DataFrameAdded), new DataRemoveDelegate(MainForm.animationEditor.DataFrameRemoved), Action.Directions[row], Action.Directions[row].IndexOf(a)));

                        // Add sprite
                        AnimationSprite sprite = new AnimationSprite();
                        sprite.Name = Global.GetName("Sprite", a.Sprites);
                        sprite.ID = Global.GetID(a.Sprites);

                        sprite.MaterialId = cbSprites.Data().ID;

                        sprite.AspectToTexture();

                        sira = j;

                        Microsoft.Xna.Framework.Rectangle r = sprite.DisplayRect;
                        r.Height = (int)sprite.Height / (int)nudRows.Value;
                        r.Width = (int)sprite.Width / (int)nudCols.Value;
                        r.X = r.Width * col;
                        r.Y = r.Height * sira;
                        sprite.DisplayRect = r;
                        sprite.Position = new Microsoft.Xna.Framework.Vector2(sprite.DisplayRect.Width / 2, sprite.DisplayRect.Height / 2);
                        Canvas = new Vector2(r.Width, r.Height);
                        a.Sprites.Add(sprite);
                        // History
                        MainForm.AnimationHistory[MainForm.animationEditor].Do(new IGameDataAddedHist(sprite, new DataAddDelegate(MainForm.animationEditor.DataSpriteAdded), new DataRemoveDelegate(MainForm.animationEditor.DataSpriteRemoved), a.Sprites, a.Sprites.IndexOf(sprite)));

                    }
                }
            }
            IsOk = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private int GetIndex(int row)
        {
            if (row > -1 && row < 8)
            {
                string item = listBox1.Items[row].ToString();
                switch (item)
                {
                    case "Up":
                        return 0;
                    case "Down":
                        return 1;
                    case "Left":
                        return 2;
                    case "Right":
                        return 3;
                    case "Up/Left":
                        return 4;
                    case "Up/Right":
                        return 5;
                    case "Down/Left":
                        return 6;
                    case "Down/Right":
                        return 7;
                }
                switch (row)
                {
                    case 0: // Up
                        return listBox1.Items.IndexOf("Up");
                    case 1: // Down
                        return listBox1.Items.IndexOf("Down");
                    case 2: // Left
                        return listBox1.Items.IndexOf("Left");
                    case 3: // Right
                        return listBox1.Items.IndexOf("Right");
                    case 4: // Up/Left
                        return listBox1.Items.IndexOf("Up/Left");
                    case 5: // Up/Right
                        return listBox1.Items.IndexOf("Up/Right");
                    case 6: // Down/Left
                        return listBox1.Items.IndexOf("Down/Left");
                    case 7: // Down/Right
                        return listBox1.Items.IndexOf("Down/Right");
                }
            }
            return 0;
        }

        //private int GetIndex(int row)
        //{
        //    if (row > -1 && row < 8)
        //    {
        //        switch (row)
        //        {
        //            case 0: // Up
        //                return listBox1.Items.IndexOf("Up");
        //            case 1: // Down
        //                return listBox1.Items.IndexOf("Down");
        //            case 2: // Left
        //                return listBox1.Items.IndexOf("Left");
        //            case 3: // Right
        //                return listBox1.Items.IndexOf("Right");
        //            case 4: // Up/Left
        //                return listBox1.Items.IndexOf("Up/Left");
        //            case 5: // Up/Right
        //                return listBox1.Items.IndexOf("Up/Right");
        //            case 6: // Down/Left
        //                return listBox1.Items.IndexOf("Down/Left");
        //            case 7: // Down/Right
        //                return listBox1.Items.IndexOf("Down/Right");
        //        }
        //    }
        //    return 0;
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                int i = listBox1.SelectedIndex;
                string text = (string)listBox1.Items[listBox1.SelectedIndex];
                listBox1.Items.RemoveAt(i);
                listBox1.Items.Insert(i - 1, text);

                listBox1.SelectedIndex = i - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1 && listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                int i = listBox1.SelectedIndex;
                string text = (string)listBox1.Items[listBox1.SelectedIndex];
                listBox1.Items.RemoveAt(i);
                listBox1.Items.Insert(i + 1, text);

                listBox1.SelectedIndex = i + 1;
            }
        }

        internal void SelectMaterial(MaterialData materialData)
        {
            cbSprites.Select(materialData.ID);
        }

        private void FromSpriteSheetDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
