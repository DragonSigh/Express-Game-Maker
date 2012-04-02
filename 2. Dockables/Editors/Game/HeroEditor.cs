using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;
using EGMGame.Controls.EventControls.EventDialogs;
using EGMGame.Docking.Editors.Database;
using GenericUndoRedo;

namespace EGMGame.Docking.Editors
{
    public partial class HeroEditor : DockContent, IHistory
    {
        bool allowChange = false;
        public HeroEditor()
        {
            MainForm.HeroHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;

            cbDatabase.RefreshList(GameData.Databases[0], false);
            cbSkills.RefreshList(true);
            cbMagic.RefreshList(true);
            cbItems.RefreshList(true);
            cbEquipment.RefreshList(true);


        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.HeroHistory[this];
        }

        private void HeroEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Heroes, typeof(HeroData));
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Heroes.Add(data.ID, (HeroData)data);
            addRemoveList.AddNode(data);

            Global.CBHeroes();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Heroes.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBHeroes();
        }
        #endregion

        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                int id = Global.GetID(GameData.Heroes);
                HeroData a = new HeroData();
                a.Name = Global.GetName("Hero", GameData.Heroes);
                a.ID = id;
                a.Category = ca.Category;

                foreach (KeyValuePair<int, string> slot in Global.Project.EquipmentSlots)
                {
                    a.Equipments.Add(slot.Key, -1);
                }

                GameData.Heroes.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.HeroHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBHeroes();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "20x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Heroes.ContainsKey(addRemoveList.SelectedID))
                {

                    // History
                    MainForm.HeroHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    // Edit Equipments
                    foreach (EquipmentData equipment in GameData.Equipments.Values)
                    {
                        equipment.HeroActions.Remove(addRemoveList.SelectedID);
                    }
                    MainForm.equipmentEditor.RefreshProperty();
                    // Remove Hero
                    GameData.Heroes.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Heroes[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBHeroes();

                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "20x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0 && GameData.Heroes.ContainsKey(ca.ID))
                    SetupProperty(GameData.Heroes[ca.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "20x003");
            }
        }

        private void SetupProperty(HeroData data)
        {
            if (data != null)
            {
                allowChange = false;
                workSpace.Enabled = true;

                UpdateAnimation();
                cbDatabase.RefreshList(GameData.Databases[0], false);

                cbDatabase.Select(data.Database);

                cbItems.RefreshList(false);
                cbEquipment.RefreshList(false);
                cbSkills.RefreshList(false);
                cbMagic.RefreshList(false);

                cbItems.Select(data.ItemsInventory);
                cbEquipment.Select(data.EquipmentsInventory);
                cbSkills.Select(data.SkillsList);
                cbMagic.Select(data.MagicsList);

                cbAutoBattle.Checked = data.AutoBattle;
                cbLockEquipment.Checked = data.LockEquipment;
                cbCanUseSkills.Checked = data.CanUseSkills;
                cbCanUseMagic.Checked = data.CanUseMagic;

                listSkills.Nodes.Clear();

                TreeNode item;
                TreeNode levelNode = new TreeNode();
                int level = 0;
                foreach (SkillToLearn skill in data.SkillsToLearn)
                {
                    if (skill.Level != level)
                    {
                        levelNode = new TreeNode("Level " + skill.Level.ToString());
                        levelNode.Tag = skill.Level;
                        listSkills.Nodes.Add(levelNode);
                    }
                    level = skill.Level;

                    item = new TreeNode(skill.Name);
                    item.Tag = skill;
                    levelNode.Nodes.Add(item);
                }

                listMagics.Nodes.Clear();
                level = 0;
                foreach (SkillToLearn skill in data.MagicsToLearn)
                {
                    if (skill.Level != level)
                    {
                        levelNode = new TreeNode("Level " + skill.Level.ToString());
                        levelNode.Tag = skill.Level;
                        listMagics.Nodes.Add(levelNode);
                    }
                    level = skill.Level;

                    item = new TreeNode(skill.Name);
                    item.Tag = skill;
                    levelNode.Nodes.Add(item);
                }


                listSlots.Items.Clear();
                ItemTag tag;
                foreach (KeyValuePair<int, string> slot in Global.Project.EquipmentSlots)
                {
                    tag = new ItemTag(slot.Key, slot.Value);
                    listSlots.Items.Add(tag);
                }

                // Settings
                TreeNode node;
                listElements.Nodes.Clear();
                foreach (KeyValuePair<int, string> element in Global.Project.Elements)
                {
                    node = new TreeNode(element.Value);
                    node.Tag = element.Key;
                    if (!data.Elements.ContainsKey(element.Key))
                    {
                        data.Elements.Add(element.Key, 5);
                    }
                    if (data.Elements[element.Key] == 0)
                        data.Elements[element.Key] = 5;
                    node.ImageIndex = data.States[element.Key] - 1;
                    listElements.Nodes.Add(node);
                }

                listStates.Nodes.Clear();
                foreach (StateData state in GameData.States.Values)
                {
                    node = new TreeNode(state.Name);
                    node.Tag = state.ID;
                    if (!data.States.ContainsKey(state.ID))
                    {
                        data.States.Add(state.ID, 5);
                    }
                    if (data.States[state.ID] == 0)
                        data.States[state.ID] = 5;
                    node.ImageIndex = data.States[state.ID] - 1;
                    listStates.Nodes.Add(node);
                }
                allowChange = true;
                if (listSlots.Items.Count > 0)
                    listSlots.SelectedIndex = 0;

            }
            else
            {
                allowChange = false;
                workSpace.Enabled = false;
                cbDatabase.RefreshList(GameData.Databases[0], false);

                cbItems.RefreshList(false);
                cbEquipment.RefreshList(false);
                cbSkills.RefreshList(false);
                cbMagic.RefreshList(false);

                cbAutoBattle.Checked = false;
                cbLockEquipment.Checked = false;
                cbCanUseSkills.Checked = false;
                cbCanUseMagic.Checked = false;
                animationViewer.SelectedAction = null;
                animationViewer.SelectedFrame = null;
                listElements.Nodes.Clear();
                listStates.Nodes.Clear();
                listSlots.Items.Clear();
                listSkills.Nodes.Clear();
                listMagics.Nodes.Clear();

                allowChange = true;
            }
        }

        internal void PropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (addRemoveList.Data() == data)
            {
                SetupProperty((HeroData)data);
            }
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data<HeroData>().ID > -1)
            {
                if (GameData.Databases[0].Datas.ContainsKey(addRemoveList.Data<HeroData>().Database))
                {
                    MainForm.Instance.databaseItemOpen(GameData.Databases[0], addRemoveList.Data<HeroData>().Database);
                }
                else
                {
                    MainForm.Instance.databaseItemOpen(GameData.Databases[0]);
                }
            }
        }

        private void btnAssignAnimation_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -10)
            {
                AnimationAssignment dialog = new AnimationAssignment();
                dialog.Setup(addRemoveList.Data<HeroData>());
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                    addRemoveList.Data<HeroData>().Actions = dialog.Actions;
                    UpdateAnimation();
                }
            }
        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -10)
            {
                AnimationListDialog dialog = new AnimationListDialog();
                dialog.SelectedAnimation = addRemoveList.Data<HeroData>().AnimationID;
                dialog.HideActions = true;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                    if (dialog.SelectedAnimation > -1)
                    {
                        addRemoveList.Data<HeroData>().AnimationID = dialog.SelectedAnimation;
                    }
                    else
                    {
                        addRemoveList.Data<HeroData>().AnimationID = -1;
                    }
                    UpdateAnimation();
                }
            }
        }

        private void UpdateAnimation()
        {
            if (addRemoveList.Data<HeroData>().AnimationID > -1)
            {
                label.Visible = false;
            }
            else
            {
                label.Visible = true;
            }
            if (addRemoveList.Data<HeroData>().AnimationID > -1 && addRemoveList.Data<HeroData>().Actions[0] > -1)
            {
                AnimationData a = Global.GetData<AnimationData>(addRemoveList.Data<HeroData>().AnimationID, GameData.Animations);
                if (a != null)
                {
                    AnimationAction ac = Global.GetData<AnimationAction>(addRemoveList.Data<HeroData>().Actions[0], a.Actions);

                    if (ac != null)
                    {
                        for (int i = 0; i < ac.Directions.Count; i++)
                        {

                            if (ac.Directions.Count > i && ac.Directions[i] != null && ac.Directions[i].Count > 0)
                            {
                                animationViewer.SelectedAction = ac;
                                animationViewer.SelectedFrame = ac.Directions[i][0];
                                return;
                            }
                            else
                                animationViewer.SelectedFrame = null;
                        }
                    }
                }

            }
            else
            {
                animationViewer.SelectedFrame = null;
            }
        }

        private void workSpace_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == false)
            {
                animationViewer.SelectedFrame = null;
            }
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().Database = cbDatabase.Data().ID;
        }

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().ItemsInventory = cbItems.Data().ID;

        }

        private void cbEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().EquipmentsInventory = cbEquipment.Data().ID;

        }

        private void cbSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().SkillsList = cbSkills.Data().ID;

        }

        private void cbMagic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().MagicsList = cbMagic.Data().ID;

        }

        private void listSkills_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            SkillSelector dialog = new SkillSelector();
            TreeNode item = listSkills.GetNodeAt(e.X, e.Y);

            if (item != null && item.Tag is SkillToLearn)
            {
                SkillToLearn s = (SkillToLearn)item.Tag;
                dialog.Setup(s);
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SkillToLearn skill = new SkillToLearn();
                skill.Level = dialog.Level;
                skill.ID = dialog.Skill;

                MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

                addRemoveList.Data<HeroData>().SkillsToLearn.Add(skill);

                addRemoveList.Data<HeroData>().SkillsToLearn.Sort(delegate(SkillToLearn a, SkillToLearn b)
                {
                    int xdiff = a.Level - b.Level;
                    if (xdiff != 0) return xdiff;
                    return a.Level - b.Level;
                });
                bool added = false;
                foreach (TreeNode levelNode in listSkills.Nodes)
                {
                    if ((int)levelNode.Tag == skill.Level)
                    {
                        // Add skill to this level
                        item = new TreeNode(skill.Name);
                        item.Tag = skill;
                        levelNode.Nodes.Add(item);
                        levelNode.Expand();
                        added = true; break;
                    }
                    else if ((int)levelNode.Tag > skill.Level)
                    {
                        // Add new level before this node.
                        TreeNode newLevel = new TreeNode("Level " + skill.Level.ToString());
                        newLevel.Tag = skill.Level;
                        int index = listSkills.Nodes.IndexOf(levelNode);
                        listSkills.Nodes.Insert(index, newLevel);
                        // Add skill
                        item = new TreeNode(skill.Name);
                        item.Tag = skill;
                        newLevel.Nodes.Add(item);
                        newLevel.Expand();
                        added = true; break;
                    }
                }
                if (!added)
                {
                    // Add new level before this node.
                    TreeNode newLevel = new TreeNode("Level " + skill.Level.ToString());
                    newLevel.Tag = skill.Level;
                    listSkills.Nodes.Add(newLevel);
                    // Add skill
                    item = new TreeNode(skill.Name);
                    item.Tag = skill;
                    newLevel.Nodes.Add(item);
                    newLevel.Expand();
                }
            }
        }

        private void listMagics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MagicsSelector dialog = new MagicsSelector();

            TreeNode item = listMagics.GetNodeAt(e.X, e.Y);

            if (item != null && item.Tag is SkillToLearn)
            {
                SkillToLearn s = (SkillToLearn)item.Tag;
                dialog.Setup(s);
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SkillToLearn skill = new SkillToLearn();
                skill.Level = dialog.Level;
                skill.ID = dialog.Skill;
                MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                addRemoveList.Data<HeroData>().MagicsToLearn.Add(skill);
                addRemoveList.Data<HeroData>().MagicsToLearn.Sort(delegate(SkillToLearn a, SkillToLearn b)
                {
                    int xdiff = a.Level - b.Level;
                    if (xdiff != 0) return xdiff;
                    return a.Level - b.Level;
                });

                bool added = false;
                foreach (TreeNode levelNode in listMagics.Nodes)
                {
                    if ((int)levelNode.Tag == skill.Level)
                    {
                        // Add skill to this level
                        item = new TreeNode(skill.Name);
                        item.Tag = skill;
                        levelNode.Nodes.Add(item);
                        levelNode.Expand();
                        added = true; break;
                    }
                    else if ((int)levelNode.Tag > skill.Level)
                    {
                        // Add new level before this node.
                        TreeNode newLevel = new TreeNode("Level " + skill.Level.ToString());
                        newLevel.Tag = skill.Level;
                        int index = listMagics.Nodes.IndexOf(levelNode);
                        listMagics.Nodes.Insert(index, newLevel);
                        // Add skill
                        item = new TreeNode(skill.Name);
                        item.Tag = skill;
                        newLevel.Nodes.Add(item);
                        newLevel.Expand();
                        added = true; break;
                    }
                }
                if (!added)
                {
                    // Add new level before this node.
                    TreeNode newLevel = new TreeNode("Level " + skill.Level.ToString());
                    newLevel.Tag = skill.Level;
                    listMagics.Nodes.Add(newLevel);
                    // Add skill
                    item = new TreeNode(skill.Name);
                    item.Tag = skill;
                    newLevel.Nodes.Add(item);
                    newLevel.Expand();
                }
            }

        }

        private void addSkillBtn_Click(object sender, EventArgs e)
        {
            listSkills_MouseDoubleClick(listSkills, new MouseEventArgs(MouseButtons.Left, 1, -1, -1, 0));
        }

        private void deleteSkillBtn_Click(object sender, EventArgs e)
        {
            if (listSkills.SelectedNode != null && listSkills.SelectedNode.Tag is SkillToLearn)
            {
                TreeNode parent;

                MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                addRemoveList.Data<HeroData>().SkillsToLearn.Remove((SkillToLearn)listSkills.SelectedNode.Tag);

                if (listSkills.SelectedNode.Parent.Nodes.Count - 1 == 0)
                    parent = listSkills.SelectedNode.Parent;
                else
                    parent = null;

                listSkills.SelectedNode.Remove();

                if (parent != null)
                    listSkills.Nodes.Remove(parent);
            }
            else
            {
                if (listSkills.SelectedNode != null && listSkills.SelectedNode.Level == 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you wish to delete all data for " + listSkills.SelectedNode.Text + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                        foreach (TreeNode node in listSkills.SelectedNode.Nodes)
                        {
                            if (node != null && node.Tag is SkillToLearn)
                            {
                                addRemoveList.Data<HeroData>().SkillsToLearn.Remove((SkillToLearn)node.Tag);
                                node.Remove();
                            }
                        }
                        listSkills.SelectedNode.Remove();
                    }
                }
            }
        }

        private void addMagicBtn_Click(object sender, EventArgs e)
        {
            listMagics_MouseDoubleClick(listMagics, new MouseEventArgs(MouseButtons.Left, 1, -1, -1, 0));
        }

        private void removeMagicBtn_Click(object sender, EventArgs e)
        {
            if (listMagics.SelectedNode != null && listMagics.SelectedNode.Tag is SkillToLearn)
            {
                TreeNode parent;

                MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                addRemoveList.Data<HeroData>().MagicsToLearn.Remove((SkillToLearn)listSkills.SelectedNode.Tag);

                if (listMagics.SelectedNode.Parent.Nodes.Count - 1 == 0)
                    parent = listMagics.SelectedNode.Parent;
                else
                    parent = null;

                listMagics.SelectedNode.Remove();

                if (parent != null)
                    listMagics.Nodes.Remove(parent);
            }
            else
            {
                if (listMagics.SelectedNode != null && listMagics.SelectedNode.Level == 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you wish to delete all data for " + listMagics.SelectedNode.Text + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                        foreach (TreeNode node in listMagics.SelectedNode.Nodes)
                        {
                            if (node != null && node.Tag is SkillToLearn)
                            {
                                addRemoveList.Data<HeroData>().MagicsToLearn.Remove((SkillToLearn)node.Tag);
                                node.Remove();
                            }
                        }
                        listMagics.SelectedNode.Remove();
                    }
                }
            }
        }

        private void cbCanUseSkills_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().CanUseSkills = cbCanUseSkills.Checked;
        }

        private void cbCanUseMagic_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().CanUseMagic = cbCanUseMagic.Checked;
        }

        private void cbAutoBattle_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().AutoBattle = cbAutoBattle.Checked;
        }

        private void cbLockEquipment_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            addRemoveList.Data<HeroData>().LockEquipment = cbLockEquipment.Checked;
        }

        private void listSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            if (listSlots.SelectedIndex > -1)
            {
                allowChange = false;
                cbDefaultEquip.RefreshList(false, ((ItemTag)listSlots.SelectedItem).ID);
                int id;
                if (addRemoveList.Data<HeroData>().Equipments.TryGetValue(((ItemTag)listSlots.SelectedItem).ID, out id))
                {
                    cbDefaultEquip.Select(id);
                }
                allowChange = true;
            }
        }

        private void cbDefaultEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            if (listSlots.SelectedIndex > -1)
            {
                if (addRemoveList.Data<HeroData>().Equipments.ContainsKey(((ItemTag)listSlots.SelectedItem).ID))
                {
                    MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                    addRemoveList.Data<HeroData>().Equipments[((ItemTag)listSlots.SelectedItem).ID] = cbDefaultEquip.Data().ID;
                }
            }
        }

        private void listSkills_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listElements_ClickStateItem(object sender, TreeNode ca)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            int oldIndex = ca.ImageIndex;
            if (ca.ImageIndex < 9)
                ca.ImageIndex++;
            else
                ca.ImageIndex = 0;

            HeroData item = addRemoveList.Data<HeroData>();
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            if (!item.Elements.ContainsKey((int)ca.Tag))
            {
                item.Elements.Add((int)ca.Tag, ca.ImageIndex + 1);
            }
            else
                item.Elements[(int)ca.Tag] = ca.ImageIndex + 1;
        }

        private void listStates_ClickStateItem(object sender, TreeNode ca)
        {
            if (!allowChange || addRemoveList.Data().ID < 0)
                return;
            int oldIndex = ca.ImageIndex;
            if (ca.ImageIndex < 9)
                ca.ImageIndex++;
            else
                ca.ImageIndex = 0;

            HeroData item = addRemoveList.Data<HeroData>();
            MainForm.HeroHistory[MainForm.heroEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            if (!item.States.ContainsKey((int)ca.Tag))
            {
                item.States.Add((int)ca.Tag, ca.ImageIndex + 1);
            }
            else
                item.States[(int)ca.Tag] = ca.ImageIndex + 1;
        }

        private void animationViewer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label_DoubleClick(null, null);
        }

        internal void RefreshProperty()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty(addRemoveList.Data<HeroData>());
            }
        }

        private void listSkills_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        #region IHistory Members

        string IHistory.GetActionName()
        {
            throw new NotImplementedException();
        }

        #endregion

        internal void ResetProject()
        {
            animationViewer.ResetContentManager();
            addRemoveList.SetupList(GameData.Heroes, typeof(HeroData));
        }

        internal void Unload()
        {
            animationViewer.ResetContentManager();
        }
    }
}
