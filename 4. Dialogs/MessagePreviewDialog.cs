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
    public partial class MessagePreviewDialog : Form
    {
        public EventProgramData Data
        {
            set
            {
                if (value != null)
                {
                    MenuData data = Global.GetData<MenuData>((int)value.Value[2], GameData.Menus);

                    mP.IsEditable = false;
                    if (data != null)
                    {
                        data = Global.Duplicate<MenuData>(data);
                        mP.SelectedMenu = data;
                        string text = "";
                        // Get Text
                        if ((int)value.Value[0] == 0) // Text
                        {
                        }
                        else // Message=
                            text = value.Value[1].ToString();

                        mP.SetupMessage(text, (int)value.Value[3], (Vector2)value.Value[4], (int)value.Value[5], (int)value.Value[6], (Vector2)value.Value[7]);
                    }
                }
            }
        }

        public MessagePreviewDialog()
        {
            InitializeComponent();
        }
    }
}
