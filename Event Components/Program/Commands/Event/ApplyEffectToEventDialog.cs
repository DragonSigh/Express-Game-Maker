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
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs;

namespace EGMGame
{
    public partial class ApplyEffectToEventDialog : Form
    {
        bool allowChange = true;

        public ApplyEffectToEventDialog()
        {
            InitializeComponent();

            allowChange = false;
            cbEffects.RefreshList(false, MaterialDataType.Effect_File);
            cbIntType.SelectedIndex = 0;
            cbIntVariable.RefreshList(false);
            cbStrVariable.RefreshList(false);
            cbStrType.SelectedIndex = 0;
            cbBoolType.SelectedIndex = 0;
            cbBoolConst.SelectedIndex = 0;
            cbBoolVar.RefreshList(false);
            cbV2Type.SelectedIndex = 0;
            cbV3Type.SelectedIndex = 0;
            cbV4Type.SelectedIndex = 0;
            cbV2VarX.RefreshList(false);
            cbV2VarY.RefreshList(false);
            cbV3x.RefreshList(false);
            cbV3y.RefreshList(false);
            cbV3z.RefreshList(false);
            cbV4X.RefreshList(false);
            cbV4X.RefreshList(false);
            cbV4X.RefreshList(false);
            cbV4X.RefreshList(false);
            cbListInt.RefreshList(false);
            cbTextures.RefreshList(false, MaterialDataType.Image);
            cbOther.SelectedIndex = 0;
            allowChange = true;
        }

        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; if (action == null) Setup(); }
        }
        IEvent selectedEvent;
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }
        EventPageData selectedPage;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 12;
        }
        List<EffectParam> parameters = new List<EffectParam>();
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            cbEvents.Select((int)action.Value[0]);
            cbEffects.Select((int)action.Value[1]);
            parameters = Global.Duplicate<List<EffectParam>>(action.Value[2]);

            foreach (EffectParam item in parameters)
            {
                listBox.Nodes.Add(item.Name);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbEvents.Data().ID;
            action.Value[1] = cbEffects.Data().ID;
            action.Value[2] = parameters;

            action.GetName(selectedEvent, selectedPage);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
        private void ApplyEffectToEventDialog_Shown(object sender, EventArgs e)
        {
            if (selectedEvent == null || selectedEvent is GlobalEventData)
                cbEvents.RefreshList(false, false, false);
            else if (selectedEvent is EventData)
                cbEvents.RefreshList(false, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
            if (cbEvents.Items.Count > 0)
                cbEvents.SelectedIndex = 0;
        }


        private void addBTn_Click(object sender, EventArgs e)
        {
            ParamTypeDialog dialog = new ParamTypeDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EffectParam item = new EffectParam();
                item.Name = "Parameter Name";
                parameters.Add(item);
                listBox.Nodes.Add(item.Name);
                item.ParamType = dialog.index;

                switch (item.ParamType)
                {
                    case 0: // Integer
                        item.Value = 0;
                        break;
                    case 1: // String
                        item.Value = "";
                        break;
                    case 2: // Bool
                        item.Value = true;
                        break;
                    case 3: // Float
                        item.Value = 0f;
                        break;
                    case 4: // Vector2
                        item.Value = Vector2.Zero;
                        break;
                    case 5: // Vector3
                        item.Value = Vector3.Zero;
                        break;
                    case 6: // Vector4
                        item.Value = Vector4.Zero;
                        break;
                    case 7: // List (Integer)
                        item.Value = 0;
                        break;
                    case 8: // Texture
                        item.Value = 0;
                        break;
                    case 9: // Other
                        item.Value = 0;
                        break;
                }
                listBox.SelectedNode = listBox.Nodes[listBox.Nodes.Count - 1];
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedNode.Index > -1)
            {
                parameters.RemoveAt(listBox.SelectedNode.Index);
                listBox.Nodes.RemoveAt(listBox.SelectedNode.Index);
                if (listBox.Nodes.Count > 0)
                    listBox.SelectedNode = listBox.Nodes[listBox.Nodes.Count - 1];
            }
        }

        private void listBox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            allowChange = false;
            if (listBox.SelectedNode.Index > -1 && listBox.SelectedNode.Index < parameters.Count)
            {
                panel.Enabled = true;
                EffectParam item = parameters[listBox.SelectedNode.Index];
                txtName.Text = item.Name;

                panelInteger.Visible = panelString.Visible =
                panelBool.Visible =
                panelInteger.Visible =
                panelV2.Visible =
                panelV3.Visible =
                panelV4.Visible =
                panelList.Visible =
                panelTex.Visible =
                panelOther.Visible = false;
                switch (item.ParamType)
                {
                    case 0: // Integer
                        panel.Name = "Set Value (Integer)";
                        panelInteger.Visible = true;
                        cbIntType.SelectedIndex = item.ValueType;
                        if (item.ValueType == 0)
                            nudConstantInt.Value = (decimal)(int)item.Value;
                        else
                            cbIntVariable.Select((int)item.Value);
                        break;
                    case 1: // String
                        panel.Name = "Set Value (String)";
                        panelString.Visible = true;
                        cbStrType.SelectedIndex = item.ValueType;
                        if (item.ValueType == 0)
                            txtStrValue.Text = (string)item.Value;
                        else
                            cbStrVariable.Select((int)item.Value);
                        break;
                    case 2: // Bool
                        panel.Name = "Set Value (Bool)";
                        panelBool.Visible = true;
                        cbBoolType.SelectedIndex = item.ValueType;
                        if (item.ValueType == 0)
                            cbBoolConst.SelectedIndex = ((bool)item.Value == true ? 0 : 1);
                        else
                            cbBoolVar.Select((int)item.Value);
                        break;
                    case 3: // Float
                        panel.Name = "Set Value (Float)";
                        panelInteger.Visible = true;
                        cbIntType.SelectedIndex = item.ValueType;
                        if (item.ValueType == 0)
                            nudConstantInt.Value = (decimal)(float)item.Value;
                        else
                            cbIntVariable.Select((int)item.Value);
                        break;
                    case 4: // Vector2
                        panel.Name = "Set Value (Vector2)";
                        panelV2.Visible = true;
                        cbV2Type.SelectedIndex = item.ValueType;
                        if (item.ValueType == 0)
                        {
                            nudV2X.Value = (decimal)((Vector2)item.Value).X;
                            nudV2Y.Value = (decimal)((Vector2)item.Value).Y;
                        }
                        else
                        {
                            cbV2VarX.Select((int)((Vector2)item.Value).X);
                            cbV2VarY.Select((int)((Vector2)item.Value).Y);
                        }
                        break;
                    case 5: // Vector3
                        panel.Name = "Set Value (Vector3)";
                        panelV3.Visible = true;
                        cbV3Type.SelectedIndex = item.ValueType;
                        if (item.ValueType == 0)
                        {
                            nudV3X.Value = (decimal)((Vector3)item.Value).X;
                            nudV3Y.Value = (decimal)((Vector3)item.Value).Y;
                            nudV3Z.Value = (decimal)((Vector3)item.Value).Z;
                        }
                        else
                        {
                            cbV3x.Select((int)((Vector3)item.Value).X);
                            cbV3y.Select((int)((Vector3)item.Value).Y);
                            cbV3z.Select((int)((Vector3)item.Value).Z);
                        }
                        break;
                    case 6: // Vector4
                        panel.Name = "Set Value (Vector4)";
                        panelV4.Visible = true;
                        cbV4Type.SelectedIndex = item.ValueType;
                        if (item.ValueType == 0)
                        {
                            nudV4x.Value = (decimal)((Vector4)item.Value).X;
                            nudV4Y.Value = (decimal)((Vector4)item.Value).Y;
                            nudV4Z.Value = (decimal)((Vector4)item.Value).Z;
                            nudV4W.Value = (decimal)((Vector4)item.Value).W;
                        }
                        else
                        {
                            cbV4X.Select((int)((Vector4)item.Value).X);
                            cbV4Y.Select((int)((Vector4)item.Value).Y);
                            cbV4Z.Select((int)((Vector4)item.Value).Z);
                            cbV4W.Select((int)((Vector4)item.Value).W);
                        }
                        break;
                    case 7: // List (Integer)
                        panel.Name = "Set Value (List)";
                        panelList.Visible = true;
                        cbListInt.Select((int)item.Value);
                        break;
                    case 8: // Texture
                        panel.Name = "Set Value (Texture)";
                        panelTex.Visible = true;
                        cbTextures.Select((int)item.Value);
                        break;
                    case 9: // Other
                        panel.Name = "Set Value (Other)";
                        panelOther.Visible = true;
                        cbOther.SelectedIndex = (int)item.Value;
                        break;
                }
            }
            else
            {
                txtName.Text = "";
                panel.Enabled = false;
            }
            allowChange = true;
        }


        private void upBtn_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedNode.Index > 0)
            {
                int index = listBox.SelectedNode.Index;
                EffectParam item = parameters[listBox.SelectedNode.Index];
                parameters.RemoveAt(listBox.SelectedNode.Index);
                listBox.Nodes.RemoveAt(listBox.SelectedNode.Index);

                parameters.Insert(index - 1, item); ;
                listBox.Nodes.Insert(index - 1, item.Name);

                listBox.SelectedNode = listBox.Nodes[index - 1];
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedNode.Index > -1 && listBox.SelectedNode.Index < listBox.Nodes.Count - 1)
            {
                int index = listBox.SelectedNode.Index;
                EffectParam item = parameters[listBox.SelectedNode.Index];
                parameters.RemoveAt(listBox.SelectedNode.Index);
                listBox.Nodes.RemoveAt(listBox.SelectedNode.Index);

                parameters.Insert(index + 1, item); ;
                listBox.Nodes.Insert(index + 1, item.Name);

                listBox.SelectedNode = listBox.Nodes[index + 1];
            }
        }

        #region Panel Integer/Float
        private void cbIntegerValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelIntCnst.Visible = (cbIntType.SelectedIndex == 0);
            panelIntVar.Visible = (cbIntType.SelectedIndex == 1);

            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].ValueType = cbIntType.SelectedIndex;

                if (cbIntType.SelectedIndex == 0)
                {
                    if (parameters[listBox.SelectedNode.Index].ParamType == 0)
                        parameters[listBox.SelectedNode.Index].Value = (int)nudConstantInt.Value;
                    else
                        parameters[listBox.SelectedNode.Index].Value = (float)nudConstantInt.Value;
                }
                else
                    parameters[listBox.SelectedNode.Index].Value = cbIntVariable.Data().ID;
            }
        }

        private void nudConstantInt_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = (parameters[listBox.SelectedNode.Index].ParamType == 0 ? (int)nudConstantInt.Value : (float)nudConstantInt.Value);
            }
        }

        private void cbIntVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = cbIntVariable.Data().ID;
            }
        }
        #endregion

        #region Panel String
        private void cbStrType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelStrConst.Visible = (cbStrType.SelectedIndex == 0);
            panelStrVar.Visible = (cbStrType.SelectedIndex == 1);
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].ValueType = cbStrType.SelectedIndex;
                if (cbStrType.SelectedIndex == 0)
                    parameters[listBox.SelectedNode.Index].Value = txtStrValue.Text;
                else
                    parameters[listBox.SelectedNode.Index].Value = cbStrVariable.Data().ID;
            }
        }

        private void txtStrValue_TextChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = txtStrValue.Text;
            }
        }

        private void cbStrVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = cbStrVariable.Data().ID;
            }
        }
        #endregion

        #region Panel Bool
        private void cbBoolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelBoolConst.Visible = cbBoolType.SelectedIndex == 0;
            panelBoolVar.Visible = cbBoolType.SelectedIndex == 1;

            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].ValueType = cbBoolType.SelectedIndex;
                if (cbBoolType.SelectedIndex == 0)
                    parameters[listBox.SelectedNode.Index].Value = (cbBoolConst.SelectedIndex == 0);
                else
                    parameters[listBox.SelectedNode.Index].Value = cbBoolVar.Data().ID;
            }
        }

        private void cbBoolVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = cbBoolVar.Data().ID;
            }
        }

        private void cbBoolConst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = (cbBoolConst.SelectedIndex == 0);
            }
        }
        #endregion

        #region Panel Vector2
        private void cbV2Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelV2Const.Visible = cbV2Type.SelectedIndex == 0;
            panelV2Var.Visible = cbV2Type.SelectedIndex == 1;

            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].ValueType = cbV2Type.SelectedIndex;
            }
        }

        private void nudV2X_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector2((float)nudV2X.Value, (float)nudV2Y.Value);
            }
        }

        private void nudV2Y_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector2((float)nudV2X.Value, (float)nudV2Y.Value);
            }
        }

        private void cbV2VarX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector2((float)cbV2VarX.Data().ID, (float)cbV2VarY.Data().ID);
            }
        }

        private void cbV2VarY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector2((float)cbV2VarX.Data().ID, (float)cbV2VarY.Data().ID);
            }
        }
        #endregion

        #region Panel Vector 3
        private void cbV3Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelV3Const.Visible = cbV3Type.SelectedIndex == 0;
            panelV3Var.Visible = cbV3Type.SelectedIndex == 1;

            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].ValueType = cbV3Type.SelectedIndex;
            }
        }

        private void cbV3x_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector3((float)cbV3x.Data().ID, (float)cbV3y.Data().ID, (float)cbV3z.Data().ID);
            }
        }

        private void cbV3y_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector3((float)cbV3x.Data().ID, (float)cbV3y.Data().ID, (float)cbV3z.Data().ID);
            }
        }

        private void cbV3z_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector3((float)cbV3x.Data().ID, (float)cbV3y.Data().ID, (float)cbV3z.Data().ID);
            }
        }

        private void nudV3X_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector3((float)nudV3X.Value, (float)nudV3Y.Value, (float)nudV3Z.Value);
            }
        }

        private void nudV3Y_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector3((float)nudV3X.Value, (float)nudV3Y.Value, (float)nudV3Z.Value);
            }
        }

        private void nudV3Z_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector3((float)nudV3X.Value, (float)nudV3Y.Value, (float)nudV3Z.Value);
            }
        }
        #endregion

        #region Panel Vector 4
        private void cbV4Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelV4Const.Visible = cbV4Type.SelectedIndex == 0;
            panelV4Var.Visible = cbV4Type.SelectedIndex == 1;

            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].ValueType = cbV4Type.SelectedIndex;
            }
        }

        private void cbV4X_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)cbV4X.Data().ID, (float)cbV4Y.Data().ID, (float)cbV4Z.Data().ID, (float)cbV4W.Data().ID);
            }
        }

        private void cbV4Y_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)cbV4X.Data().ID, (float)cbV4Y.Data().ID, (float)cbV4Z.Data().ID, (float)cbV4W.Data().ID);
            }
        }

        private void cbV4Z_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)cbV4X.Data().ID, (float)cbV4Y.Data().ID, (float)cbV4Z.Data().ID, (float)cbV4W.Data().ID);
            }
        }

        private void cbV4W_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)cbV4X.Data().ID, (float)cbV4Y.Data().ID, (float)cbV4Z.Data().ID, (float)cbV4W.Data().ID);
            }
        }

        private void nudV4x_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)nudV4x.Value, (float)nudV4Y.Value, (float)nudV4Z.Value, (float)nudV4W.Value);
            }
        }

        private void nudV4Y_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)nudV4x.Value, (float)nudV4Y.Value, (float)nudV4Z.Value, (float)nudV4W.Value);
            }
        }

        private void nudV4Z_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)nudV4x.Value, (float)nudV4Y.Value, (float)nudV4Z.Value, (float)nudV4W.Value);
            }
        }

        private void nudV4W_ValueChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Value = new Vector4((float)nudV4x.Value, (float)nudV4Y.Value, (float)nudV4Z.Value, (float)nudV4W.Value);
            }
        }
        #endregion

        private void cbListInt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
                parameters[listBox.SelectedNode.Index].Value = cbListInt.Data().ID;
        }

        private void cbTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
                parameters[listBox.SelectedNode.Index].Value = cbTextures.Data().ID;
        }

        private void cbOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
                parameters[listBox.SelectedNode.Index].Value = cbOther.SelectedIndex;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                parameters[listBox.SelectedNode.Index].Name = txtName.Text;
                listBox.SelectedNode.Text = parameters[listBox.SelectedNode.Index].Name;

            }
        }

    }


}
