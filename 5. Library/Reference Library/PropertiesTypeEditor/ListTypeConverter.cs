//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Controls;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using EGMGame.Dialogs;
using System.ComponentModel;

namespace EGMGame.Library
{

    public class ListItemTypeConvert : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            //context.Instance; Use to get the menu part data.
            
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                List<ListItem> clone = new List<ListItem>((List<ListItem>)value);
                ListItemDialog dialog = new ListItemDialog();
                dialog.ListItems = clone;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    value = dialog.ListItems;
                }

            }
            return value;
        }
    }
}
