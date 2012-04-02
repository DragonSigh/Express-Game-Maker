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
    public partial class EnemiesEditor : DockContent, IHistory
    {
        bool allowChange = true;

        public EnemiesEditor()
        {
            MainForm.EnemyHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.EnemyHistory[this];
        }

        private void EnemiesEditor_Shown(object sender, EventArgs e)
        {
            addRemoveList.SetupList(GameData.Enemies, typeof(EnemyData));
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Enemies.Add(data.ID, (EnemyData)data);
            addRemoveList.AddNode(data);

            Global.CBEnemies();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Enemies.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBEnemies();
        }

        bool undoRedoChange = true;
        internal void PropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (addRemoveList.Data() == data)
            {
                SetupProperty((EnemyData)data);
            }
            undoRedoChange = true;
        }
        #endregion
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                int id = Global.GetID(GameData.Enemies);
                EnemyData a = new EnemyData();
                a.Name = Global.GetName("Enemy", GameData.Enemies);
                a.ID = id;
                a.Category = ca.Category;

                foreach (KeyValuePair<int, string> slot in Global.Project.EquipmentSlots)
                {
                    a.Equipments.Add(slot.Key, -1);
                }

                GameData.Enemies.Add(a.ID, a);
                int index = a.ID;

                // History
                MainForm.EnemyHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBEnemies();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "12x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Enemies.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.EnemyHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
                    GameData.Enemies.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Enemies[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBEnemies();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "12x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                if (ca.Index >= 0 && GameData.Enemies.ContainsKey(ca.ID))
                    SetupProperty(GameData.Enemies[ca.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "12x003");
            }
        }

        private void SetupProperty(EnemyData data)
        {
            if (data != null)
            {
                undoRedoChange = false;
                allowChange = false;
                workSpace.Enabled = true;

                UpdateAnimation();
                cbDatabase.RefreshList(GameData.Databases[1], false);

                cbDatabase.Select(data.Database);

                nudGold.Value = (decimal)data.Gold;
                nudExperience.Value = (decimal)data.Experience;

                // Programs
                listPrograms.Items.Clear();
                foreach (EnemyProgram action in data.Programs)
                {
                    listPrograms.Items.Add(action);
                }
                listPrograms.Items.Add("...");

                // 
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
                    node.ImageIndex = data.Elements[element.Key] - 1;
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
                {
                    listSlots.SelectedIndex = 0;

                    if (data.Equipments.ContainsKey(((ItemTag)listSlots.SelectedItem).ID))
                        cbDefaultEquip.Select(data.Equipments[((ItemTag)listSlots.SelectedItem).ID]);
                }
                undoRedoChange = true;
            }
            else
            {
                allowChange = false;
                workSpace.Enabled = false;
                cbDatabase.RefreshList(GameData.Databases[1], false);
                nudGold.Value = nudGold.Minimum;
                nudExperience.Value = nudExperience.Minimum;
                animationViewer.SelectedAction = null;
                animationViewer.SelectedFrame = null;
                listElements.Nodes.Clear();
                listStates.Nodes.Clear();
                listSlots.Items.Clear();
                listPrograms.Items.Clear();
                allowChange = true;
            }
            nudGold.OnChange = false;
            nudExperience.OnChange = false;
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data<EnemyData>().ID > -1)
            {
                if (GameData.Databases[1].Datas.ContainsKey(addRemoveList.Data<EnemyData>().Database))
                {
                    MainForm.Instance.databaseItemOpen(GameData.Databases[1], addRemoveList.Data<EnemyData>().Database);
                }
                else
                {
                    MainForm.Instance.databaseItemOpen(GameData.Databases[1]);
                }
            }
        }

        private void btnAssignAnimation_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -10)
            {
                AnimationAssignment dialog = new AnimationAssignment();
                dialog.Setup(addRemoveList.Data<EnemyData>());
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                    addRemoveList.Data<EnemyData>().Actions = dialog.Actions;
                    UpdateAnimation();
                }
            }
        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -10)
            {
                AnimationListDialog dialog = new AnimationListDialog();
                dialog.SelectedAnimation = addRemoveList.Data<EnemyData>().AnimationID;
                dialog.HideActions = true;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                    if (dialog.SelectedAnimation > -1)
                    {
                        addRemoveList.Data<EnemyData>().AnimationID = dialog.SelectedAnimation;
                    }
                    else
                    {
                        addRemoveList.Data<EnemyData>().AnimationID = -1;
                    }
                    UpdateAnimation();
                }
            }
        }

        private void UpdateAnimation()
        {
            if (addRemoveList.Data<EnemyData>().AnimationID > -1)
            {
                label.Visible = false;
            }
            else
            {
                label.Visible = true;
            }
            if (addRemoveList.Data<EnemyData>().AnimationID > -1 && addRemoveList.Data<EnemyData>().Actions[0] > -1)
            {
                AnimationData a = Global.GetData<AnimationData>(addRemoveList.Data<EnemyData>().AnimationID, GameData.Animations);
                if (a != null)
                {
                    AnimationAction ac = Global.GetData<AnimationAction>(addRemoveList.Data<EnemyData>().Actions[0], a.Actions);

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
                            {
                                animationViewer.SelectedFrame = null;
                            }
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
            MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

            addRemoveList.Data<EnemyData>().Database = cbDatabase.Data().ID;
        }

        private void listSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDefaultEquip.RefreshList(true, ((ItemTag)listSlots.SelectedItem).ID);
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            if (listSlots.SelectedIndex > -1)
            {
                allowChange = false;
                int id;
                if (addRemoveList.Data<EnemyData>().Equipments.TryGetValue(((ItemTag)listSlots.SelectedItem).ID, out id))
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
                if (addRemoveList.Data<EnemyData>().Equipments.ContainsKey(((ItemTag)listSlots.SelectedItem).ID))
                {
                    MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                    addRemoveList.Data<EnemyData>().Equipments[((ItemTag)listSlots.SelectedItem).ID] = cbDefaultEquip.Data().ID;
                }
            }
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

            EnemyData item = addRemoveList.Data<EnemyData>();

            MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
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

            EnemyData item = addRemoveList.Data<EnemyData>();
            MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
            if (!item.States.ContainsKey((int)ca.Tag))
            {
                item.States.Add((int)ca.Tag, ca.ImageIndex + 1);
            }
            else
                item.States[(int)ca.Tag] = ca.ImageIndex + 1;
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            addRemoveList.Data<EnemyData>().Gold = (int)nudGold.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;
            addRemoveList.Data<EnemyData>().Experience = (int)nudExperience.Value;
        }


        private void nudGold_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (addRemoveList.Data().ID < 0) return;

            if (nudGold.OnChange)
            {
                int newValue = addRemoveList.Data<EnemyData>().Gold;
                addRemoveList.Data<EnemyData>().Gold = (int)nudGold.OldValue;
                MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                addRemoveList.Data<EnemyData>().Gold = newValue;
                nudGold.OnChange = false;
            }
        }

        private void nudExperience_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (addRemoveList.Data().ID < 0) return;

            if (nudExperience.OnChange)
            {
                int newValue = addRemoveList.Data<EnemyData>().Experience;
                addRemoveList.Data<EnemyData>().Experience = (int)nudExperience.OldValue;
                MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));
                addRemoveList.Data<EnemyData>().Experience = newValue;
                nudExperience.OnChange = false;
            }
        }

        private void btnDropItems_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;

            DropableItemsDialog dialog = new DropableItemsDialog();
            dialog.Setup(addRemoveList.Data<EnemyData>());

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

                addRemoveList.Data<EnemyData>().ItemDrops = dialog.ItemDrops;
                addRemoveList.Data<EnemyData>().EquipDrops = dialog.EquipDrops;
                addRemoveList.Data<EnemyData>().DropProbality = dialog.DropProb;
            }
        }

        private void btnStealable_Click(object sender, EventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;

            StealableItemsDialog dialog = new StealableItemsDialog();
            dialog.Setup(addRemoveList.Data<EnemyData>());

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

                addRemoveList.Data<EnemyData>().Steal = dialog.ItemID;
                addRemoveList.Data<EnemyData>().StealType = dialog.type;
                addRemoveList.Data<EnemyData>().StealProbality = dialog.DropProb;
            }
        }

        private void listPrograms_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            // Create a new Brush and initialize to a Black colored brush
            // by default.

            e.DrawBackground();
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based on 
            // the index of the item to draw.


            // Draw the current item text based on the current 
            // Font and the custom brush settings.
            //

            if (e.Index > -1 && ((ListBox)sender).Items[e.Index] is EnemyProgram)
            {
                EnemyProgram action = ((EnemyProgram)((ListBox)sender).Items[e.Index]);


                Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height);
                // Draw Priority
                e.Graphics.DrawString(action.Priority.ToString(), e.Font, myBrush, rect, StringFormat.GenericDefault);
                // Draw Action
                switch (action.ActionType)
                {
                    case EnemyActionType.Basic:
                        myBrush = Brushes.Black; break;
                    case EnemyActionType.Item:
                        myBrush = Brushes.Blue; break;
                    case EnemyActionType.Magic:
                        myBrush = Brushes.DarkOrange; break;
                    case EnemyActionType.Skill:
                        myBrush = Brushes.Red; break;
                }
                rect.X += 50;
                e.Graphics.DrawString(action.Name.ToString(),
                e.Font, myBrush, rect, StringFormat.GenericDefault);
                rect.X += 170;
                // Draw Condition
                e.Graphics.DrawString(action.ConditionName.ToString(),
                e.Font, myBrush, rect, StringFormat.GenericDefault);
            }
            else
            {
                Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height);
                // Draw Priority
                if (e.Index > -1)
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, myBrush, rect, StringFormat.GenericDefault);

            }
            // If the ListBox has focus, draw a focus rectangle 
            // around the selected item.

            e.DrawFocusRectangle();
        }

        private void listPrograms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!allowChange || addRemoveList.Data().ID < 0) return;

            listPrograms.ItemHeight = 24;
            listPrograms.Font = new Font(listPrograms.Font.FontFamily, 8.5f);

            EnemyProgramDialog dialog = new EnemyProgramDialog();

            if (listPrograms.SelectedIndex > -1)
            {
                Rectangle rect = listPrograms.GetItemRectangle(listPrograms.SelectedIndex);

                if (rect.Contains(e.Location) && listPrograms.SelectedItem is EnemyProgram)
                {
                    dialog.Setup(((EnemyProgram)((ListBox)sender).Items[listPrograms.SelectedIndex]));
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

                        addRemoveList.Data<EnemyData>().Programs[listPrograms.SelectedIndex] = dialog.Program;

                        addRemoveList.Data<EnemyData>().Programs.Sort(CompareProgramsByPriority);
                        // Programs
                        listPrograms.Items.Clear();
                        foreach (EnemyProgram action in addRemoveList.Data<EnemyData>().Programs)
                        {
                            listPrograms.Items.Add(action);
                        }
                        listPrograms.Items.Add("...");
                    }
                    return;
                }
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

                addRemoveList.Data<EnemyData>().Programs.Add(dialog.Program);
                addRemoveList.Data<EnemyData>().Programs.Sort(CompareProgramsByPriority);

                // Programs
                listPrograms.Items.Clear();
                foreach (EnemyProgram action in addRemoveList.Data<EnemyData>().Programs)
                {
                    listPrograms.Items.Add(action);
                }
                listPrograms.Items.Add("...");
            }

        }
        private static int CompareProgramsByPriority(EnemyProgram x, EnemyProgram y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    if (x.Priority > y.Priority)
                    {
                        return -1;
                    }
                    else
                        return 0;
                }
            }
        }


        internal void RefreshProperty()
        {
            if (addRemoveList.Data().ID > -1)
            {
                SetupProperty(addRemoveList.Data<EnemyData>());
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listPrograms.SelectedIndex > -1)
            {
                if (listPrograms.SelectedItem is EnemyProgram)
                {
                    MainForm.EnemyHistory[MainForm.enemyEditor].Do(new IGameDataChangePropertyHist(addRemoveList.Data(), new DataPropertyDelegate(PropertyChanged)));

                    addRemoveList.Data<EnemyData>().Programs.RemoveAt(listPrograms.SelectedIndex);
                    listPrograms.Items.Remove(listPrograms.SelectedItem);
                }
            }
        }

        private void listPrograms_MouseClick(object sender, MouseEventArgs e)
        {

        }

        #region IHistory Members

        public string GetActionName()
        {
            throw new NotImplementedException();
        }

        #endregion

        internal void ResetProject()
        {
            animationViewer.ResetContentManager();
            addRemoveList.SetupList(GameData.Enemies, typeof(EnemyData));
        }

        internal void Unload()
        {
            animationViewer.ResetContentManager();
        }
    }
}
