using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Dialogs
{
    public partial class MagicHotkeyDialog : Form
    {
        internal List<Hotkey> Keys;
        bool allowChange = true;
        public MagicHotkeyDialog()
        {
            InitializeComponent();
        }

        internal void Setup(List<Hotkey> list)
        {
            Keys = Global.Duplicate<List<Hotkey>>(list);
            addRemoveList1.SetupList(Keys, typeof(Hotkey));
        }

        private void addRemoveList1_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                Hotkey a = new Hotkey();
                a.Name = Global.GetName("Hotkey", Keys);
                a.ID = Global.GetID(Keys);
                a.Category = ca.Category;
                Keys.Add(a);

                addRemoveList1.AddNode(a);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "25x001");
            }
        }

        private void addRemoveList1_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList1.Data().ID > -1)
                {
                    Keys.Remove(addRemoveList1.Data<Hotkey>());
                    addRemoveList1.RemoveSelectedNode();
                    if (addRemoveList1.Data().ID > -1)
                        SetupProperty(addRemoveList1.Data<Hotkey>());
                    else
                        SetupProperty(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "25x002");
            }
        }

        private void addRemoveList1_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList1.Data().ID > -1)
                    SetupProperty(addRemoveList1.Data<Hotkey>());
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "25x003");
            }
        }

        private void SetupProperty(Hotkey hotkey)
        {
            allowChange = false;
            if (hotkey != null)
            {
                impactGroupBox2.Enabled = true;

                cbActionBtn.SelectedIndex = hotkey.Button1;
                cbActionBtn2.SelectedIndex = hotkey.Button2 + 1;

                cbActionKey.SelectedIndex = hotkey.Key1;
                cbActionKey2.SelectedIndex = hotkey.Key2 + 1;

                cbSkills.RefreshList(false, EGMGame.Library.SkillType.Magic);
                cbSkills.Select(hotkey.DefaultID);
            }
            else
            {
                cbActionBtn.SelectedIndex = 0;
                cbActionBtn2.SelectedIndex = 0;
                cbActionKey.SelectedIndex = 0;
                cbActionKey2.SelectedIndex = 0;
                cbSkills.Items.Clear();
                impactGroupBox2.Enabled = false;
            }
            allowChange = true;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbActionKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addRemoveList1.Data().ID > -1 && allowChange)
            {
                addRemoveList1.Data<Hotkey>().Key1 = cbActionKey.SelectedIndex;
            }
        }

        private void cbActionKey2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addRemoveList1.Data().ID > -1 && allowChange)
            {
                addRemoveList1.Data<Hotkey>().Key2 = cbActionKey2.SelectedIndex - 1;
            }
        }

        private void cbActionBtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addRemoveList1.Data().ID > -1 && allowChange)
            {
                addRemoveList1.Data<Hotkey>().Button1 = cbActionBtn.SelectedIndex;
            }
        }

        private void cbActionBtn2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addRemoveList1.Data().ID > -1 && allowChange)
            {
                addRemoveList1.Data<Hotkey>().Button2 = cbActionBtn2.SelectedIndex - 1;
            }
        }

        private void cbSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addRemoveList1.Data().ID > -1 && allowChange)
            {
                addRemoveList1.Data<Hotkey>().DefaultID = cbSkills.Data().ID;
            }
        }
    }
}
