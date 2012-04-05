//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using EGMGame.Controls.EventControls.EventDialogs;
using EGMGame.Controls;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Dialogs;
using Microsoft.Xna.Framework;

namespace EGMGame.Library
{
    public class XnaColorTypeConvert : UITypeEditor
    {

        IWindowsFormsEditorService wfes;

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                Color clone = (Color)value;
                ColorPickerDialog dialog = new ColorPickerDialog();
                dialog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                dialog.colorPickerCtrl.SelectedColor = System.Drawing.Color.FromArgb(clone.A, clone.R, clone.G, clone.B);
                dialog.FormClosed += new System.Windows.Forms.FormClosedEventHandler(dialog_FormClosed);
                dialog.TopLevel = false;
                wfes.DropDownControl(dialog);
                if (dialog.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    System.Drawing.Color c = dialog.colorPickerCtrl.SelectedColor;
                    value = new Color(c.R, c.G, c.B, c.A);
                }

            }
            return value;
        }

        void dialog_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            wfes.CloseDropDown();
        }
    }

}
