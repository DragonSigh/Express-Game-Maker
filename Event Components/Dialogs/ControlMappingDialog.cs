using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Dialogs;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls
{
    public partial class ControlMappingDialog : Form
    {
        List<Hotkey> magics;
        List<Hotkey> skills;
        List<Hotkey> items;

        public ControlMappingDialog()
        {
            InitializeComponent();

            cbActionBtn.SelectedIndex = GameData.Player.Buttons["Action"];
            cbActionKey.SelectedIndex = GameData.Player.Keys["Action"];
            cbAttackBtn.SelectedIndex = GameData.Player.Buttons["Attack"];
            cbAttackKey.SelectedIndex = GameData.Player.Keys["Attack"];
            cbCancelBtn.SelectedIndex = GameData.Player.Buttons["Cancel"];
            cbCancelKey.SelectedIndex = GameData.Player.Keys["Cancel"];
            cbDefendBtn.SelectedIndex = GameData.Player.Buttons["Defend"];
            cbDefendKey.SelectedIndex = GameData.Player.Keys["Defend"];
            cbMovementBtn.SelectedIndex = GameData.Player.Buttons["Movement"];
            cbMovementKey.SelectedIndex = GameData.Player.Keys["Movement"];
            magics = GameData.Player.MagicKeys;
            skills = GameData.Player.SkillKeys;
            items = GameData.Player.ItemKeys;
            cbAttackPress.SelectedIndex = GameData.Player.AttackPress;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            MainForm.PlayerHistory[MainForm.playerEditor].Do(new IGameDataChangePropertyHist(GameData.Player));

            GameData.Player.Buttons["Action"] = cbActionBtn.SelectedIndex;
            GameData.Player.Keys["Action"] = cbActionKey.SelectedIndex;
            GameData.Player.Buttons["Attack"] = cbAttackBtn.SelectedIndex;
            GameData.Player.Keys["Attack"] = cbAttackKey.SelectedIndex;
            GameData.Player.Buttons["Cancel"] = cbCancelBtn.SelectedIndex;
            GameData.Player.Keys["Cancel"] = cbCancelKey.SelectedIndex;
            GameData.Player.Buttons["Defend"] = cbDefendBtn.SelectedIndex;
            GameData.Player.Keys["Defend"] = cbDefendKey.SelectedIndex;
            GameData.Player.Buttons["Movement"] = cbMovementBtn.SelectedIndex;
            GameData.Player.Keys["Movement"] = cbMovementKey.SelectedIndex;
            GameData.Player.MagicKeys = magics;
            GameData.Player.SkillKeys = skills;
            GameData.Player.ItemKeys = items;
            GameData.Player.AttackPress = cbAttackPress.SelectedIndex;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMagHotkey_Click(object sender, EventArgs e)
        {
            MagicHotkeyDialog dialog = new MagicHotkeyDialog();
            dialog.Setup(magics);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                magics = dialog.Keys;
            }
        }

        private void btnSkillHotkey_Click(object sender, EventArgs e)
        {
            SkillHotkeysDialog dialog = new SkillHotkeysDialog();
            dialog.Setup(skills);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                skills = dialog.Keys;
            }
        }

        private void btnItemHotkey_Click(object sender, EventArgs e)
        {
            ItemHotkeyDialog dialog = new ItemHotkeyDialog();
            dialog.Setup(items);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                items = dialog.Keys;
            }
        }

        private void ControlMappingDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
