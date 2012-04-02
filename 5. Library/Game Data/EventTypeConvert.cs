using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using EGMGame.Controls.EventControls.EventDialogs;
using EGMGame.Controls;
using EGMGame.Dialogs;

namespace EGMGame.Library
{
    public class EventTypeConvert : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                MenuEventDialog dialog = new MenuEventDialog();
                dialog.Programs = (List<EventProgramData>)value;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    value = dialog.Programs;
                }
                //frmContrast _frmContrast = new frmContrast();

                //_frmContrast.trackBar1.Value = (int)value;
                //_frmContrast.BarValue = _frmContrast.trackBar1.Value;
                //_frmContrast._wfes = wfes;

                //wfes.DropDownControl(_frmContrast);
                //value = _frmContrast.BarValue;

            }
            return value;
        }
    }


    public class ImageTypeConvert : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes != null)
            {
                ChooseImagesDialog dialog = new ChooseImagesDialog();
                dialog.lbImages.SelectionMode = System.Windows.Forms.SelectionMode.One;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (dialog.SelectedImages.Count > 0)
                        value = dialog.SelectedImages[0].ID.ToString();
                }

            }
            return value;
        }
    }

}
