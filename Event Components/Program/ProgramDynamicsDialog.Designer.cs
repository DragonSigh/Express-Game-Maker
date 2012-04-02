namespace EGMGame.Controls.EventControls.EventDialogs
{
    partial class ProgramMovementDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.okBtn = new System.Windows.Forms.Button();
            this.repeatBtn = new System.Windows.Forms.CheckBox();
            this.ignoreBtn = new System.Windows.Forms.CheckBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.chkWait = new System.Windows.Forms.CheckBox();
            this.settingsBtn = new System.Windows.Forms.CheckBox();
            this.movementBtn = new System.Windows.Forms.CheckBox();
            this.conditionsBtn = new System.Windows.Forms.CheckBox();
            this.cbEvents = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.groupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listBox = new EGMGame.Controls.UpDownCheckedListBox();
            this.movementBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnStopAnimation = new System.Windows.Forms.Button();
            this.btnNextFrame = new System.Windows.Forms.Button();
            this.btnAnimate = new System.Windows.Forms.Button();
            this.btnClearForce = new System.Windows.Forms.Button();
            this.btnApplyRotation = new System.Windows.Forms.Button();
            this.btnApplyAngularImpulse = new System.Windows.Forms.Button();
            this.btnApplyTorque = new System.Windows.Forms.Button();
            this.btnTurnRand = new System.Windows.Forms.Button();
            this.btnMoveRand = new System.Windows.Forms.Button();
            this.btnMoveToEvent = new System.Windows.Forms.Button();
            this.btnApplyForce = new System.Windows.Forms.Button();
            this.waitBtn = new System.Windows.Forms.Button();
            this.genPathBtn = new System.Windows.Forms.Button();
            this.moveBtn = new System.Windows.Forms.Button();
            this.moveTowardEventBtn = new System.Windows.Forms.Button();
            this.moveAwayFromEventsBtn = new System.Windows.Forms.Button();
            this.turnBtn = new System.Windows.Forms.Button();
            this.turnTowardEventBtn = new System.Windows.Forms.Button();
            this.turnAwayEventBtn = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.settingsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.btnSyncAngleRotOff = new System.Windows.Forms.Button();
            this.btnSyncAngleRotOn = new System.Windows.Forms.Button();
            this.btnPassOff = new System.Windows.Forms.Button();
            this.btnPassOn = new System.Windows.Forms.Button();
            this.btnChangeFreq = new System.Windows.Forms.Button();
            this.btnFreqOff = new System.Windows.Forms.Button();
            this.btnFreqOn = new System.Windows.Forms.Button();
            this.playSeBtn = new System.Windows.Forms.Button();
            this.chngAnimeBtn = new System.Windows.Forms.Button();
            this.turnCollisionOffBtn = new System.Windows.Forms.Button();
            this.turnCollisionOnBtn = new System.Windows.Forms.Button();
            this.directionFixOffBtn = new System.Windows.Forms.Button();
            this.directionFixOnBtn = new System.Windows.Forms.Button();
            this.animationOffBtn = new System.Windows.Forms.Button();
            this.animationOnBtn = new System.Windows.Forms.Button();
            this.chngSpdBtn = new System.Windows.Forms.Button();
            this.btnIgnoreGravity = new System.Windows.Forms.Button();
            this.btnChangeSTatic = new System.Windows.Forms.Button();
            this.btnSetRotation = new System.Windows.Forms.Button();
            this.btnChangeFriction = new System.Windows.Forms.Button();
            this.btnChangeRotationalDrag = new System.Windows.Forms.Button();
            this.btnChangeBounce = new System.Windows.Forms.Button();
            this.btnChangeMass = new System.Windows.Forms.Button();
            this.btnChangeLinearDrag = new System.Windows.Forms.Button();
            this.btnChangeForce = new System.Windows.Forms.Button();
            this.btnChangeImpulse = new System.Windows.Forms.Button();
            this.conditionsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.chngLocalVariableValueBtn = new System.Windows.Forms.Button();
            this.chngLocalSwitchBtn = new System.Windows.Forms.Button();
            this.chngVariableValueBtn = new System.Windows.Forms.Button();
            this.chngSwitchCondBtn = new System.Windows.Forms.Button();
            this.btnCustomGravity = new System.Windows.Forms.Button();
            this.physicsBtn = new System.Windows.Forms.CheckBox();
            this.physicsBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.attachmentList = new EGMGame.Controls.Game.AttachmentComboBox(this.components);
            this.groupBox1.SuspendLayout();
            this.movementBox.SuspendLayout();
            this.settingsBox.SuspendLayout();
            this.conditionsBox.SuspendLayout();
            this.physicsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(449, 445);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // repeatBtn
            // 
            this.repeatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatBtn.AutoSize = true;
            this.repeatBtn.Location = new System.Drawing.Point(12, 447);
            this.repeatBtn.Name = "repeatBtn";
            this.repeatBtn.Size = new System.Drawing.Size(61, 17);
            this.repeatBtn.TabIndex = 53;
            this.repeatBtn.Text = "Repeat";
            this.repeatBtn.UseVisualStyleBackColor = true;
            this.repeatBtn.CheckedChanged += new System.EventHandler(this.repeatBtn_CheckedChanged);
            // 
            // ignoreBtn
            // 
            this.ignoreBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ignoreBtn.AutoSize = true;
            this.ignoreBtn.Location = new System.Drawing.Point(80, 447);
            this.ignoreBtn.Name = "ignoreBtn";
            this.ignoreBtn.Size = new System.Drawing.Size(108, 17);
            this.ignoreBtn.TabIndex = 54;
            this.ignoreBtn.Text = "Ignore Impassible";
            this.ignoreBtn.UseVisualStyleBackColor = true;
            this.ignoreBtn.CheckedChanged += new System.EventHandler(this.ignoreBtn_CheckedChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(530, 445);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // chkWait
            // 
            this.chkWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWait.AutoSize = true;
            this.chkWait.Enabled = false;
            this.chkWait.Location = new System.Drawing.Point(194, 447);
            this.chkWait.Name = "chkWait";
            this.chkWait.Size = new System.Drawing.Size(103, 17);
            this.chkWait.TabIndex = 56;
            this.chkWait.Text = "Wait Completion";
            this.chkWait.UseVisualStyleBackColor = true;
            this.chkWait.CheckedChanged += new System.EventHandler(this.chkWait_CheckedChanged);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.settingsBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingsBtn.Location = new System.Drawing.Point(224, 75);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(77, 57);
            this.settingsBtn.TabIndex = 48;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // movementBtn
            // 
            this.movementBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.movementBtn.BackColor = System.Drawing.Color.Transparent;
            this.movementBtn.Checked = true;
            this.movementBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.movementBtn.Location = new System.Drawing.Point(224, 12);
            this.movementBtn.Name = "movementBtn";
            this.movementBtn.Size = new System.Drawing.Size(77, 57);
            this.movementBtn.TabIndex = 49;
            this.movementBtn.Text = "Movement";
            this.movementBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.movementBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.movementBtn.UseVisualStyleBackColor = true;
            this.movementBtn.Click += new System.EventHandler(this.moveBtn_Click);
            // 
            // conditionsBtn
            // 
            this.conditionsBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.conditionsBtn.BackColor = System.Drawing.Color.Transparent;
            this.conditionsBtn.Location = new System.Drawing.Point(224, 139);
            this.conditionsBtn.Name = "conditionsBtn";
            this.conditionsBtn.Size = new System.Drawing.Size(77, 57);
            this.conditionsBtn.TabIndex = 50;
            this.conditionsBtn.Text = "Data";
            this.conditionsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.conditionsBtn.UseVisualStyleBackColor = true;
            this.conditionsBtn.Click += new System.EventHandler(this.conditionsBtn_Click);
            // 
            // cbEvents
            // 
            this.cbEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.Enabled = false;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(12, 12);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.ShowPlayer = true;
            this.cbEvents.ShowTarget = true;
            this.cbEvents.ShowTargets = false;
            this.cbEvents.Size = new System.Drawing.Size(206, 21);
            this.cbEvents.TabIndex = 55;
            this.cbEvents.ThisEvent = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox1.CanCollapse = false;
            this.groupBox1.Controls.Add(this.listBox);
            this.groupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox1.Image = null;
            this.groupBox1.IsCollapsed = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(206, 405);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dynamics";
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Location = new System.Drawing.Point(4, 25);
            this.listBox.Margin = new System.Windows.Forms.Padding(4);
            this.listBox.Master = true;
            this.listBox.Name = "listBox";
            this.listBox.SelectedIndex = -1;
            this.listBox.Size = new System.Drawing.Size(198, 375);
            this.listBox.TabIndex = 0;
            this.listBox.AddItem += new EGMGame.Controls.UpDownCheckedListBox.AddItemEvent(this.listBox_AddItem);
            this.listBox.RemoveItem += new EGMGame.Controls.UpDownCheckedListBox.RemoveItemEvent(this.listBox_RemoveItem);
            this.listBox.SelectItem += new EGMGame.Controls.UpDownCheckedListBox.SelectItemEvent(this.listBox_SelectItem);
            this.listBox.ItemCheckState += new EGMGame.Controls.UpDownCheckedListBox.ItemCheckStateEvent(this.listBox_ItemCheckState);
            this.listBox.ItemCheckedState += new EGMGame.Controls.UpDownCheckedListBox.ItemCheckedStateEvent(this.listBox_ItemCheckedState);
            this.listBox.EditItem += new EGMGame.Controls.UpDownCheckedListBox.EditItemEvent(this.listBox_EditItem);
            this.listBox.UpItem += new EGMGame.Controls.UpDownCheckedListBox.UpItemEvent(this.listBox_UpItem);
            this.listBox.DownItem += new EGMGame.Controls.UpDownCheckedListBox.DownItemEvent(this.listBox_DownItem);
            this.listBox.CopyItem += new EGMGame.Controls.UpDownCheckedListBox.CopyItemEvent(this.listBox_CopyItem);
            this.listBox.PasteItem += new EGMGame.Controls.UpDownCheckedListBox.PasteItemEvent(this.listBox_PasteItem);
            // 
            // movementBox
            // 
            this.movementBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.movementBox.CanCollapse = false;
            this.movementBox.Controls.Add(this.btnStopAnimation);
            this.movementBox.Controls.Add(this.btnNextFrame);
            this.movementBox.Controls.Add(this.btnAnimate);
            this.movementBox.Controls.Add(this.btnClearForce);
            this.movementBox.Controls.Add(this.btnApplyRotation);
            this.movementBox.Controls.Add(this.btnApplyAngularImpulse);
            this.movementBox.Controls.Add(this.btnApplyTorque);
            this.movementBox.Controls.Add(this.btnTurnRand);
            this.movementBox.Controls.Add(this.btnMoveRand);
            this.movementBox.Controls.Add(this.btnMoveToEvent);
            this.movementBox.Controls.Add(this.btnApplyForce);
            this.movementBox.Controls.Add(this.waitBtn);
            this.movementBox.Controls.Add(this.genPathBtn);
            this.movementBox.Controls.Add(this.moveBtn);
            this.movementBox.Controls.Add(this.moveTowardEventBtn);
            this.movementBox.Controls.Add(this.moveAwayFromEventsBtn);
            this.movementBox.Controls.Add(this.turnBtn);
            this.movementBox.Controls.Add(this.turnTowardEventBtn);
            this.movementBox.Controls.Add(this.turnAwayEventBtn);
            this.movementBox.Controls.Add(this.btnJump);
            this.movementBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.movementBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.movementBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.movementBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.movementBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.movementBox.Image = null;
            this.movementBox.IsCollapsed = false;
            this.movementBox.Location = new System.Drawing.Point(307, 12);
            this.movementBox.Name = "movementBox";
            this.movementBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.movementBox.Size = new System.Drawing.Size(296, 424);
            this.movementBox.TabIndex = 51;
            this.movementBox.TabStop = false;
            this.movementBox.Text = "Movement";
            // 
            // btnStopAnimation
            // 
            this.btnStopAnimation.Location = new System.Drawing.Point(149, 321);
            this.btnStopAnimation.Name = "btnStopAnimation";
            this.btnStopAnimation.Size = new System.Drawing.Size(136, 27);
            this.btnStopAnimation.TabIndex = 74;
            this.btnStopAnimation.Text = "Stop Animation";
            this.btnStopAnimation.UseVisualStyleBackColor = true;
            this.btnStopAnimation.Click += new System.EventHandler(this.btnStopAnimation_Click);
            // 
            // btnNextFrame
            // 
            this.btnNextFrame.Location = new System.Drawing.Point(149, 288);
            this.btnNextFrame.Name = "btnNextFrame";
            this.btnNextFrame.Size = new System.Drawing.Size(136, 27);
            this.btnNextFrame.TabIndex = 73;
            this.btnNextFrame.Text = "Next Frame";
            this.btnNextFrame.UseVisualStyleBackColor = true;
            this.btnNextFrame.Click += new System.EventHandler(this.btnNextFrame_Click);
            // 
            // btnAnimate
            // 
            this.btnAnimate.Location = new System.Drawing.Point(149, 255);
            this.btnAnimate.Name = "btnAnimate";
            this.btnAnimate.Size = new System.Drawing.Size(136, 27);
            this.btnAnimate.TabIndex = 72;
            this.btnAnimate.Text = "Animate";
            this.btnAnimate.UseVisualStyleBackColor = true;
            this.btnAnimate.Click += new System.EventHandler(this.btnAnimate_Click);
            // 
            // btnClearForce
            // 
            this.btnClearForce.Location = new System.Drawing.Point(149, 157);
            this.btnClearForce.Name = "btnClearForce";
            this.btnClearForce.Size = new System.Drawing.Size(136, 27);
            this.btnClearForce.TabIndex = 70;
            this.btnClearForce.Text = "Clear Force";
            this.btnClearForce.UseVisualStyleBackColor = true;
            this.btnClearForce.Click += new System.EventHandler(this.btnClearForce_Click);
            // 
            // btnApplyRotation
            // 
            this.btnApplyRotation.Location = new System.Drawing.Point(149, 124);
            this.btnApplyRotation.Name = "btnApplyRotation";
            this.btnApplyRotation.Size = new System.Drawing.Size(136, 27);
            this.btnApplyRotation.TabIndex = 65;
            this.btnApplyRotation.Text = "Apply Rotation";
            this.btnApplyRotation.UseVisualStyleBackColor = true;
            this.btnApplyRotation.Click += new System.EventHandler(this.btnApplyRotation_Click);
            // 
            // btnApplyAngularImpulse
            // 
            this.btnApplyAngularImpulse.Location = new System.Drawing.Point(149, 58);
            this.btnApplyAngularImpulse.Name = "btnApplyAngularImpulse";
            this.btnApplyAngularImpulse.Size = new System.Drawing.Size(136, 27);
            this.btnApplyAngularImpulse.TabIndex = 64;
            this.btnApplyAngularImpulse.Text = "Apply Angular Impulse";
            this.btnApplyAngularImpulse.UseVisualStyleBackColor = true;
            this.btnApplyAngularImpulse.Click += new System.EventHandler(this.btnApplyAngularImpulse_Click);
            // 
            // btnApplyTorque
            // 
            this.btnApplyTorque.Location = new System.Drawing.Point(149, 91);
            this.btnApplyTorque.Name = "btnApplyTorque";
            this.btnApplyTorque.Size = new System.Drawing.Size(136, 27);
            this.btnApplyTorque.TabIndex = 63;
            this.btnApplyTorque.Text = "Apply Torque";
            this.btnApplyTorque.UseVisualStyleBackColor = true;
            this.btnApplyTorque.Click += new System.EventHandler(this.btnApplyTorque_Click);
            // 
            // btnTurnRand
            // 
            this.btnTurnRand.Location = new System.Drawing.Point(7, 321);
            this.btnTurnRand.Name = "btnTurnRand";
            this.btnTurnRand.Size = new System.Drawing.Size(136, 27);
            this.btnTurnRand.TabIndex = 59;
            this.btnTurnRand.Text = "Turn Random";
            this.btnTurnRand.Click += new System.EventHandler(this.btnTurnRand_Click);
            // 
            // btnMoveRand
            // 
            this.btnMoveRand.Location = new System.Drawing.Point(7, 288);
            this.btnMoveRand.Name = "btnMoveRand";
            this.btnMoveRand.Size = new System.Drawing.Size(136, 27);
            this.btnMoveRand.TabIndex = 58;
            this.btnMoveRand.Text = "Move Random";
            this.btnMoveRand.UseVisualStyleBackColor = true;
            this.btnMoveRand.Click += new System.EventHandler(this.btnMoveRand_Click);
            // 
            // btnMoveToEvent
            // 
            this.btnMoveToEvent.Location = new System.Drawing.Point(7, 57);
            this.btnMoveToEvent.Name = "btnMoveToEvent";
            this.btnMoveToEvent.Size = new System.Drawing.Size(136, 27);
            this.btnMoveToEvent.TabIndex = 57;
            this.btnMoveToEvent.Text = "Move To Event";
            this.btnMoveToEvent.UseVisualStyleBackColor = true;
            this.btnMoveToEvent.Click += new System.EventHandler(this.btnMoveToEvent_Click);
            // 
            // btnApplyForce
            // 
            this.btnApplyForce.Location = new System.Drawing.Point(149, 25);
            this.btnApplyForce.Name = "btnApplyForce";
            this.btnApplyForce.Size = new System.Drawing.Size(136, 27);
            this.btnApplyForce.TabIndex = 55;
            this.btnApplyForce.Text = "Apply Force";
            this.btnApplyForce.UseVisualStyleBackColor = true;
            this.btnApplyForce.Click += new System.EventHandler(this.btnApplyForce_Click);
            // 
            // waitBtn
            // 
            this.waitBtn.Location = new System.Drawing.Point(149, 222);
            this.waitBtn.Name = "waitBtn";
            this.waitBtn.Size = new System.Drawing.Size(136, 27);
            this.waitBtn.TabIndex = 53;
            this.waitBtn.Text = "Wait";
            this.waitBtn.UseVisualStyleBackColor = true;
            this.waitBtn.Click += new System.EventHandler(this.waitBtn_Click);
            // 
            // genPathBtn
            // 
            this.genPathBtn.Location = new System.Drawing.Point(7, 24);
            this.genPathBtn.Name = "genPathBtn";
            this.genPathBtn.Size = new System.Drawing.Size(136, 27);
            this.genPathBtn.TabIndex = 32;
            this.genPathBtn.Text = "Move To";
            this.genPathBtn.UseVisualStyleBackColor = true;
            this.genPathBtn.Click += new System.EventHandler(this.genPathBtn_Click);
            // 
            // moveBtn
            // 
            this.moveBtn.Location = new System.Drawing.Point(7, 90);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(136, 27);
            this.moveBtn.TabIndex = 33;
            this.moveBtn.Text = "Move";
            this.moveBtn.UseVisualStyleBackColor = true;
            this.moveBtn.Click += new System.EventHandler(this.moveBtn_Click_1);
            // 
            // moveTowardEventBtn
            // 
            this.moveTowardEventBtn.Location = new System.Drawing.Point(7, 123);
            this.moveTowardEventBtn.Name = "moveTowardEventBtn";
            this.moveTowardEventBtn.Size = new System.Drawing.Size(136, 27);
            this.moveTowardEventBtn.TabIndex = 38;
            this.moveTowardEventBtn.Text = "Move Toward Events";
            this.moveTowardEventBtn.UseVisualStyleBackColor = true;
            this.moveTowardEventBtn.Click += new System.EventHandler(this.moveTowardEventBtn_Click);
            // 
            // moveAwayFromEventsBtn
            // 
            this.moveAwayFromEventsBtn.Location = new System.Drawing.Point(7, 156);
            this.moveAwayFromEventsBtn.Name = "moveAwayFromEventsBtn";
            this.moveAwayFromEventsBtn.Size = new System.Drawing.Size(136, 27);
            this.moveAwayFromEventsBtn.TabIndex = 39;
            this.moveAwayFromEventsBtn.Text = "Move Away From Events";
            this.moveAwayFromEventsBtn.UseVisualStyleBackColor = true;
            this.moveAwayFromEventsBtn.Click += new System.EventHandler(this.moveAwayFromEventsBtn_Click);
            // 
            // turnBtn
            // 
            this.turnBtn.Location = new System.Drawing.Point(7, 189);
            this.turnBtn.Name = "turnBtn";
            this.turnBtn.Size = new System.Drawing.Size(136, 27);
            this.turnBtn.TabIndex = 45;
            this.turnBtn.Text = "Turn";
            this.turnBtn.UseVisualStyleBackColor = true;
            this.turnBtn.Click += new System.EventHandler(this.turnBtn_Click);
            // 
            // turnTowardEventBtn
            // 
            this.turnTowardEventBtn.Location = new System.Drawing.Point(7, 222);
            this.turnTowardEventBtn.Name = "turnTowardEventBtn";
            this.turnTowardEventBtn.Size = new System.Drawing.Size(136, 27);
            this.turnTowardEventBtn.TabIndex = 44;
            this.turnTowardEventBtn.Text = "Turn Toward Events";
            this.turnTowardEventBtn.UseVisualStyleBackColor = true;
            this.turnTowardEventBtn.Click += new System.EventHandler(this.turnTowardEventBtn_Click);
            // 
            // turnAwayEventBtn
            // 
            this.turnAwayEventBtn.Location = new System.Drawing.Point(7, 255);
            this.turnAwayEventBtn.Name = "turnAwayEventBtn";
            this.turnAwayEventBtn.Size = new System.Drawing.Size(136, 27);
            this.turnAwayEventBtn.TabIndex = 46;
            this.turnAwayEventBtn.Text = "Turn Away From Events";
            this.turnAwayEventBtn.UseVisualStyleBackColor = true;
            this.turnAwayEventBtn.Click += new System.EventHandler(this.turnAwayEventBtn_Click);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(149, 189);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(136, 27);
            this.btnJump.TabIndex = 42;
            this.btnJump.Text = "Jump";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.jumpBtn_Click);
            // 
            // settingsBox
            // 
            this.settingsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.settingsBox.CanCollapse = false;
            this.settingsBox.Controls.Add(this.btnSyncAngleRotOff);
            this.settingsBox.Controls.Add(this.btnSyncAngleRotOn);
            this.settingsBox.Controls.Add(this.btnPassOff);
            this.settingsBox.Controls.Add(this.btnPassOn);
            this.settingsBox.Controls.Add(this.btnChangeFreq);
            this.settingsBox.Controls.Add(this.btnFreqOff);
            this.settingsBox.Controls.Add(this.btnFreqOn);
            this.settingsBox.Controls.Add(this.playSeBtn);
            this.settingsBox.Controls.Add(this.chngAnimeBtn);
            this.settingsBox.Controls.Add(this.turnCollisionOffBtn);
            this.settingsBox.Controls.Add(this.turnCollisionOnBtn);
            this.settingsBox.Controls.Add(this.directionFixOffBtn);
            this.settingsBox.Controls.Add(this.directionFixOnBtn);
            this.settingsBox.Controls.Add(this.animationOffBtn);
            this.settingsBox.Controls.Add(this.animationOnBtn);
            this.settingsBox.Controls.Add(this.chngSpdBtn);
            this.settingsBox.Enabled = false;
            this.settingsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.settingsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.settingsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.settingsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.settingsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.settingsBox.Image = null;
            this.settingsBox.IsCollapsed = false;
            this.settingsBox.Location = new System.Drawing.Point(307, 12);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.settingsBox.Size = new System.Drawing.Size(296, 424);
            this.settingsBox.TabIndex = 52;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            this.settingsBox.Visible = false;
            // 
            // btnSyncAngleRotOff
            // 
            this.btnSyncAngleRotOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncAngleRotOff.Location = new System.Drawing.Point(149, 255);
            this.btnSyncAngleRotOff.Name = "btnSyncAngleRotOff";
            this.btnSyncAngleRotOff.Size = new System.Drawing.Size(136, 27);
            this.btnSyncAngleRotOff.TabIndex = 71;
            this.btnSyncAngleRotOff.Text = "Sync Angle to Rot OFF";
            this.btnSyncAngleRotOff.UseVisualStyleBackColor = true;
            this.btnSyncAngleRotOff.Click += new System.EventHandler(this.btnSyncAngleRotOff_Click);
            // 
            // btnSyncAngleRotOn
            // 
            this.btnSyncAngleRotOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncAngleRotOn.Location = new System.Drawing.Point(7, 255);
            this.btnSyncAngleRotOn.Name = "btnSyncAngleRotOn";
            this.btnSyncAngleRotOn.Size = new System.Drawing.Size(136, 27);
            this.btnSyncAngleRotOn.TabIndex = 70;
            this.btnSyncAngleRotOn.Text = "Sync Angle to Rot ON";
            this.btnSyncAngleRotOn.UseVisualStyleBackColor = true;
            this.btnSyncAngleRotOn.Click += new System.EventHandler(this.btnSyncAngleRotOn_Click);
            // 
            // btnPassOff
            // 
            this.btnPassOff.Location = new System.Drawing.Point(7, 189);
            this.btnPassOff.Name = "btnPassOff";
            this.btnPassOff.Size = new System.Drawing.Size(136, 27);
            this.btnPassOff.TabIndex = 68;
            this.btnPassOff.Text = "Passthrough OFF";
            this.btnPassOff.UseVisualStyleBackColor = true;
            this.btnPassOff.Click += new System.EventHandler(this.btnPassOff_Click);
            // 
            // btnPassOn
            // 
            this.btnPassOn.Location = new System.Drawing.Point(7, 157);
            this.btnPassOn.Name = "btnPassOn";
            this.btnPassOn.Size = new System.Drawing.Size(136, 27);
            this.btnPassOn.TabIndex = 67;
            this.btnPassOn.Text = "Passthrough ON";
            this.btnPassOn.UseVisualStyleBackColor = true;
            this.btnPassOn.Click += new System.EventHandler(this.btnPassOn_Click);
            // 
            // btnChangeFreq
            // 
            this.btnChangeFreq.Location = new System.Drawing.Point(7, 222);
            this.btnChangeFreq.Name = "btnChangeFreq";
            this.btnChangeFreq.Size = new System.Drawing.Size(136, 27);
            this.btnChangeFreq.TabIndex = 55;
            this.btnChangeFreq.Text = "Change Frequency";
            this.btnChangeFreq.UseVisualStyleBackColor = true;
            this.btnChangeFreq.Click += new System.EventHandler(this.btnChangeFreq_Click);
            // 
            // btnFreqOff
            // 
            this.btnFreqOff.Location = new System.Drawing.Point(149, 123);
            this.btnFreqOff.Name = "btnFreqOff";
            this.btnFreqOff.Size = new System.Drawing.Size(136, 27);
            this.btnFreqOff.TabIndex = 54;
            this.btnFreqOff.Text = "Frequency OFF";
            this.btnFreqOff.UseVisualStyleBackColor = true;
            this.btnFreqOff.Click += new System.EventHandler(this.btnFreqOff_Click);
            // 
            // btnFreqOn
            // 
            this.btnFreqOn.Location = new System.Drawing.Point(149, 90);
            this.btnFreqOn.Name = "btnFreqOn";
            this.btnFreqOn.Size = new System.Drawing.Size(136, 27);
            this.btnFreqOn.TabIndex = 53;
            this.btnFreqOn.Text = "Frequency ON";
            this.btnFreqOn.UseVisualStyleBackColor = true;
            this.btnFreqOn.Click += new System.EventHandler(this.btnFreqOn_Click);
            // 
            // playSeBtn
            // 
            this.playSeBtn.Location = new System.Drawing.Point(149, 190);
            this.playSeBtn.Name = "playSeBtn";
            this.playSeBtn.Size = new System.Drawing.Size(136, 27);
            this.playSeBtn.TabIndex = 52;
            this.playSeBtn.Text = "Play SE";
            this.playSeBtn.UseVisualStyleBackColor = true;
            this.playSeBtn.Click += new System.EventHandler(this.playSeBtn_Click);
            // 
            // chngAnimeBtn
            // 
            this.chngAnimeBtn.Location = new System.Drawing.Point(149, 157);
            this.chngAnimeBtn.Name = "chngAnimeBtn";
            this.chngAnimeBtn.Size = new System.Drawing.Size(136, 27);
            this.chngAnimeBtn.TabIndex = 49;
            this.chngAnimeBtn.Text = "Change Animation";
            this.chngAnimeBtn.UseVisualStyleBackColor = true;
            this.chngAnimeBtn.Click += new System.EventHandler(this.chngAnimeBtn_Click);
            // 
            // turnCollisionOffBtn
            // 
            this.turnCollisionOffBtn.Location = new System.Drawing.Point(7, 124);
            this.turnCollisionOffBtn.Name = "turnCollisionOffBtn";
            this.turnCollisionOffBtn.Size = new System.Drawing.Size(136, 27);
            this.turnCollisionOffBtn.TabIndex = 48;
            this.turnCollisionOffBtn.Text = "Turn Collision OFF";
            this.turnCollisionOffBtn.UseVisualStyleBackColor = true;
            this.turnCollisionOffBtn.Click += new System.EventHandler(this.turnCollisionOffBtn_Click);
            // 
            // turnCollisionOnBtn
            // 
            this.turnCollisionOnBtn.Location = new System.Drawing.Point(7, 91);
            this.turnCollisionOnBtn.Name = "turnCollisionOnBtn";
            this.turnCollisionOnBtn.Size = new System.Drawing.Size(136, 27);
            this.turnCollisionOnBtn.TabIndex = 47;
            this.turnCollisionOnBtn.Text = "Turn Collision ON";
            this.turnCollisionOnBtn.UseVisualStyleBackColor = true;
            this.turnCollisionOnBtn.Click += new System.EventHandler(this.turnCollisionOnBtn_Click);
            // 
            // directionFixOffBtn
            // 
            this.directionFixOffBtn.Location = new System.Drawing.Point(149, 57);
            this.directionFixOffBtn.Name = "directionFixOffBtn";
            this.directionFixOffBtn.Size = new System.Drawing.Size(136, 27);
            this.directionFixOffBtn.TabIndex = 46;
            this.directionFixOffBtn.Text = "Direction Fix OFF";
            this.directionFixOffBtn.UseVisualStyleBackColor = true;
            this.directionFixOffBtn.Click += new System.EventHandler(this.directionFixOffBtn_Click);
            // 
            // directionFixOnBtn
            // 
            this.directionFixOnBtn.Location = new System.Drawing.Point(149, 25);
            this.directionFixOnBtn.Name = "directionFixOnBtn";
            this.directionFixOnBtn.Size = new System.Drawing.Size(136, 27);
            this.directionFixOnBtn.TabIndex = 45;
            this.directionFixOnBtn.Text = "Direction Fix ON";
            this.directionFixOnBtn.UseVisualStyleBackColor = true;
            this.directionFixOnBtn.Click += new System.EventHandler(this.directionFixOnBtn_Click);
            // 
            // animationOffBtn
            // 
            this.animationOffBtn.Location = new System.Drawing.Point(7, 58);
            this.animationOffBtn.Name = "animationOffBtn";
            this.animationOffBtn.Size = new System.Drawing.Size(136, 27);
            this.animationOffBtn.TabIndex = 44;
            this.animationOffBtn.Text = "Animation OFF";
            this.animationOffBtn.UseVisualStyleBackColor = true;
            this.animationOffBtn.Click += new System.EventHandler(this.animationOffBtn_Click);
            // 
            // animationOnBtn
            // 
            this.animationOnBtn.Location = new System.Drawing.Point(7, 25);
            this.animationOnBtn.Name = "animationOnBtn";
            this.animationOnBtn.Size = new System.Drawing.Size(136, 27);
            this.animationOnBtn.TabIndex = 43;
            this.animationOnBtn.Text = "Animation ON";
            this.animationOnBtn.UseVisualStyleBackColor = true;
            this.animationOnBtn.Click += new System.EventHandler(this.animationOnBtn_Click);
            // 
            // chngSpdBtn
            // 
            this.chngSpdBtn.Location = new System.Drawing.Point(149, 222);
            this.chngSpdBtn.Name = "chngSpdBtn";
            this.chngSpdBtn.Size = new System.Drawing.Size(136, 27);
            this.chngSpdBtn.TabIndex = 41;
            this.chngSpdBtn.Text = "Change Speed";
            this.chngSpdBtn.UseVisualStyleBackColor = true;
            this.chngSpdBtn.Click += new System.EventHandler(this.chngSpdBtn_Click);
            // 
            // btnIgnoreGravity
            // 
            this.btnIgnoreGravity.Location = new System.Drawing.Point(149, 160);
            this.btnIgnoreGravity.Name = "btnIgnoreGravity";
            this.btnIgnoreGravity.Size = new System.Drawing.Size(136, 27);
            this.btnIgnoreGravity.TabIndex = 69;
            this.btnIgnoreGravity.Text = "Ignore Gravity";
            this.btnIgnoreGravity.UseVisualStyleBackColor = true;
            this.btnIgnoreGravity.Click += new System.EventHandler(this.btnIgnoreGravity_Click);
            // 
            // btnChangeSTatic
            // 
            this.btnChangeSTatic.Location = new System.Drawing.Point(7, 160);
            this.btnChangeSTatic.Name = "btnChangeSTatic";
            this.btnChangeSTatic.Size = new System.Drawing.Size(136, 27);
            this.btnChangeSTatic.TabIndex = 66;
            this.btnChangeSTatic.Text = "Change Static";
            this.btnChangeSTatic.UseVisualStyleBackColor = true;
            this.btnChangeSTatic.Click += new System.EventHandler(this.btnChangeSTatic_Click);
            // 
            // btnSetRotation
            // 
            this.btnSetRotation.Location = new System.Drawing.Point(149, 127);
            this.btnSetRotation.Name = "btnSetRotation";
            this.btnSetRotation.Size = new System.Drawing.Size(136, 27);
            this.btnSetRotation.TabIndex = 65;
            this.btnSetRotation.Text = "Fixed Rotation";
            this.btnSetRotation.UseVisualStyleBackColor = true;
            this.btnSetRotation.Click += new System.EventHandler(this.btnSetRotation_Click);
            // 
            // btnChangeFriction
            // 
            this.btnChangeFriction.Location = new System.Drawing.Point(7, 127);
            this.btnChangeFriction.Name = "btnChangeFriction";
            this.btnChangeFriction.Size = new System.Drawing.Size(136, 27);
            this.btnChangeFriction.TabIndex = 63;
            this.btnChangeFriction.Text = "Change Friction";
            this.btnChangeFriction.UseVisualStyleBackColor = true;
            this.btnChangeFriction.Click += new System.EventHandler(this.btnChangeFriction_Click);
            // 
            // btnChangeRotationalDrag
            // 
            this.btnChangeRotationalDrag.Location = new System.Drawing.Point(7, 94);
            this.btnChangeRotationalDrag.Name = "btnChangeRotationalDrag";
            this.btnChangeRotationalDrag.Size = new System.Drawing.Size(136, 27);
            this.btnChangeRotationalDrag.TabIndex = 60;
            this.btnChangeRotationalDrag.Text = "Change Rotational Drag";
            this.btnChangeRotationalDrag.UseVisualStyleBackColor = true;
            this.btnChangeRotationalDrag.Click += new System.EventHandler(this.btnChangeRotationalDrag_Click);
            // 
            // btnChangeBounce
            // 
            this.btnChangeBounce.Location = new System.Drawing.Point(149, 94);
            this.btnChangeBounce.Name = "btnChangeBounce";
            this.btnChangeBounce.Size = new System.Drawing.Size(136, 27);
            this.btnChangeBounce.TabIndex = 61;
            this.btnChangeBounce.Text = "Change Bounce";
            this.btnChangeBounce.UseVisualStyleBackColor = true;
            this.btnChangeBounce.Click += new System.EventHandler(this.btnChangeBounce_Click);
            // 
            // btnChangeMass
            // 
            this.btnChangeMass.Location = new System.Drawing.Point(7, 61);
            this.btnChangeMass.Name = "btnChangeMass";
            this.btnChangeMass.Size = new System.Drawing.Size(136, 27);
            this.btnChangeMass.TabIndex = 59;
            this.btnChangeMass.Text = "Change Mass";
            this.btnChangeMass.UseVisualStyleBackColor = true;
            this.btnChangeMass.Click += new System.EventHandler(this.btnChangeMass_Click);
            // 
            // btnChangeLinearDrag
            // 
            this.btnChangeLinearDrag.Location = new System.Drawing.Point(149, 61);
            this.btnChangeLinearDrag.Name = "btnChangeLinearDrag";
            this.btnChangeLinearDrag.Size = new System.Drawing.Size(136, 27);
            this.btnChangeLinearDrag.TabIndex = 58;
            this.btnChangeLinearDrag.Text = "Change Linear Drag";
            this.btnChangeLinearDrag.UseVisualStyleBackColor = true;
            this.btnChangeLinearDrag.Click += new System.EventHandler(this.btnChangeLinearDrag_Click);
            // 
            // btnChangeForce
            // 
            this.btnChangeForce.Location = new System.Drawing.Point(7, 28);
            this.btnChangeForce.Name = "btnChangeForce";
            this.btnChangeForce.Size = new System.Drawing.Size(136, 27);
            this.btnChangeForce.TabIndex = 56;
            this.btnChangeForce.Text = "Change Force";
            this.btnChangeForce.UseVisualStyleBackColor = true;
            this.btnChangeForce.Click += new System.EventHandler(this.btnChangeForce_Click);
            // 
            // btnChangeImpulse
            // 
            this.btnChangeImpulse.Location = new System.Drawing.Point(149, 28);
            this.btnChangeImpulse.Name = "btnChangeImpulse";
            this.btnChangeImpulse.Size = new System.Drawing.Size(136, 27);
            this.btnChangeImpulse.TabIndex = 57;
            this.btnChangeImpulse.Text = "Change Impulse";
            this.btnChangeImpulse.UseVisualStyleBackColor = true;
            this.btnChangeImpulse.Click += new System.EventHandler(this.btnChangeImpulse_Click);
            // 
            // conditionsBox
            // 
            this.conditionsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.conditionsBox.CanCollapse = false;
            this.conditionsBox.Controls.Add(this.chngLocalVariableValueBtn);
            this.conditionsBox.Controls.Add(this.chngLocalSwitchBtn);
            this.conditionsBox.Controls.Add(this.chngVariableValueBtn);
            this.conditionsBox.Controls.Add(this.chngSwitchCondBtn);
            this.conditionsBox.Enabled = false;
            this.conditionsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.conditionsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.conditionsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.conditionsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.conditionsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.conditionsBox.Image = null;
            this.conditionsBox.IsCollapsed = false;
            this.conditionsBox.Location = new System.Drawing.Point(307, 12);
            this.conditionsBox.Name = "conditionsBox";
            this.conditionsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.conditionsBox.Size = new System.Drawing.Size(296, 424);
            this.conditionsBox.TabIndex = 53;
            this.conditionsBox.TabStop = false;
            this.conditionsBox.Text = "Data";
            this.conditionsBox.Visible = false;
            // 
            // chngLocalVariableValueBtn
            // 
            this.chngLocalVariableValueBtn.Location = new System.Drawing.Point(7, 123);
            this.chngLocalVariableValueBtn.Name = "chngLocalVariableValueBtn";
            this.chngLocalVariableValueBtn.Size = new System.Drawing.Size(140, 27);
            this.chngLocalVariableValueBtn.TabIndex = 44;
            this.chngLocalVariableValueBtn.Text = "Change Local Variable";
            this.chngLocalVariableValueBtn.UseVisualStyleBackColor = true;
            this.chngLocalVariableValueBtn.Click += new System.EventHandler(this.chngLocalVariableValueBtn_Click);
            // 
            // chngLocalSwitchBtn
            // 
            this.chngLocalSwitchBtn.Location = new System.Drawing.Point(7, 90);
            this.chngLocalSwitchBtn.Name = "chngLocalSwitchBtn";
            this.chngLocalSwitchBtn.Size = new System.Drawing.Size(140, 27);
            this.chngLocalSwitchBtn.TabIndex = 43;
            this.chngLocalSwitchBtn.Text = "Change Local Switch ";
            this.chngLocalSwitchBtn.UseVisualStyleBackColor = true;
            this.chngLocalSwitchBtn.Click += new System.EventHandler(this.chngLocalSwitchBtn_Click);
            // 
            // chngVariableValueBtn
            // 
            this.chngVariableValueBtn.Location = new System.Drawing.Point(7, 57);
            this.chngVariableValueBtn.Name = "chngVariableValueBtn";
            this.chngVariableValueBtn.Size = new System.Drawing.Size(140, 27);
            this.chngVariableValueBtn.TabIndex = 42;
            this.chngVariableValueBtn.Text = "Change Variable";
            this.chngVariableValueBtn.UseVisualStyleBackColor = true;
            this.chngVariableValueBtn.Click += new System.EventHandler(this.chngVariableValueBtn_Click);
            // 
            // chngSwitchCondBtn
            // 
            this.chngSwitchCondBtn.Location = new System.Drawing.Point(7, 24);
            this.chngSwitchCondBtn.Name = "chngSwitchCondBtn";
            this.chngSwitchCondBtn.Size = new System.Drawing.Size(140, 27);
            this.chngSwitchCondBtn.TabIndex = 41;
            this.chngSwitchCondBtn.Text = "Change Switch";
            this.chngSwitchCondBtn.UseVisualStyleBackColor = true;
            this.chngSwitchCondBtn.Click += new System.EventHandler(this.chngSwitchCondBtn_Click);
            // 
            // btnCustomGravity
            // 
            this.btnCustomGravity.Location = new System.Drawing.Point(7, 193);
            this.btnCustomGravity.Name = "btnCustomGravity";
            this.btnCustomGravity.Size = new System.Drawing.Size(136, 27);
            this.btnCustomGravity.TabIndex = 70;
            this.btnCustomGravity.Text = "Custom Gravity";
            this.btnCustomGravity.UseVisualStyleBackColor = true;
            this.btnCustomGravity.Click += new System.EventHandler(this.btnCustomGravity_Click);
            // 
            // physicsBtn
            // 
            this.physicsBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.physicsBtn.BackColor = System.Drawing.Color.Transparent;
            this.physicsBtn.Location = new System.Drawing.Point(224, 201);
            this.physicsBtn.Name = "physicsBtn";
            this.physicsBtn.Size = new System.Drawing.Size(77, 57);
            this.physicsBtn.TabIndex = 57;
            this.physicsBtn.Text = "Physics";
            this.physicsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.physicsBtn.UseVisualStyleBackColor = true;
            this.physicsBtn.Click += new System.EventHandler(this.physicsBtn_Click);
            // 
            // physicsBox
            // 
            this.physicsBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.physicsBox.CanCollapse = false;
            this.physicsBox.Controls.Add(this.btnCustomGravity);
            this.physicsBox.Controls.Add(this.btnChangeForce);
            this.physicsBox.Controls.Add(this.btnIgnoreGravity);
            this.physicsBox.Controls.Add(this.btnChangeImpulse);
            this.physicsBox.Controls.Add(this.btnChangeLinearDrag);
            this.physicsBox.Controls.Add(this.btnChangeMass);
            this.physicsBox.Controls.Add(this.btnChangeSTatic);
            this.physicsBox.Controls.Add(this.btnChangeBounce);
            this.physicsBox.Controls.Add(this.btnSetRotation);
            this.physicsBox.Controls.Add(this.btnChangeRotationalDrag);
            this.physicsBox.Controls.Add(this.btnChangeFriction);
            this.physicsBox.Enabled = false;
            this.physicsBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.physicsBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.physicsBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.physicsBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.physicsBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.physicsBox.Image = null;
            this.physicsBox.IsCollapsed = false;
            this.physicsBox.Location = new System.Drawing.Point(307, 12);
            this.physicsBox.Name = "physicsBox";
            this.physicsBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.physicsBox.Size = new System.Drawing.Size(296, 424);
            this.physicsBox.TabIndex = 58;
            this.physicsBox.TabStop = false;
            this.physicsBox.Text = "Physics";
            this.physicsBox.Visible = false;
            // 
            // attachmentList
            // 
            this.attachmentList.AllowCategories = true;
            this.attachmentList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.attachmentList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.attachmentList.FormattingEnabled = true;
            this.attachmentList.Location = new System.Drawing.Point(12, 12);
            this.attachmentList.Name = "attachmentList";
            this.attachmentList.SelectedNode = null;
            this.attachmentList.Size = new System.Drawing.Size(206, 21);
            this.attachmentList.TabIndex = 59;
            this.attachmentList.Visible = false;
            // 
            // ProgramMovementDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 477);
            this.Controls.Add(this.attachmentList);
            this.Controls.Add(this.physicsBtn);
            this.Controls.Add(this.chkWait);
            this.Controls.Add(this.cbEvents);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ignoreBtn);
            this.Controls.Add(this.repeatBtn);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.movementBtn);
            this.Controls.Add(this.conditionsBtn);
            this.Controls.Add(this.settingsBox);
            this.Controls.Add(this.conditionsBox);
            this.Controls.Add(this.movementBox);
            this.Controls.Add(this.physicsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramMovementDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Program Dynamics";
            this.groupBox1.ResumeLayout(false);
            this.movementBox.ResumeLayout(false);
            this.settingsBox.ResumeLayout(false);
            this.conditionsBox.ResumeLayout(false);
            this.physicsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox1;
        private UpDownCheckedListBox listBox;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox settingsBox;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox conditionsBox;
        private System.Windows.Forms.Button chngLocalVariableValueBtn;
        private System.Windows.Forms.Button chngLocalSwitchBtn;
        private System.Windows.Forms.Button chngVariableValueBtn;
        private System.Windows.Forms.Button chngSwitchCondBtn;
        private System.Windows.Forms.Button playSeBtn;
        private System.Windows.Forms.Button chngAnimeBtn;
        private System.Windows.Forms.Button turnCollisionOffBtn;
        private System.Windows.Forms.Button turnCollisionOnBtn;
        private System.Windows.Forms.Button directionFixOffBtn;
        private System.Windows.Forms.Button directionFixOnBtn;
        private System.Windows.Forms.Button animationOffBtn;
        private System.Windows.Forms.Button animationOnBtn;
        private System.Windows.Forms.Button chngSpdBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox movementBox;
        private System.Windows.Forms.Button genPathBtn;
        private System.Windows.Forms.Button moveBtn;
        private System.Windows.Forms.Button turnBtn;
        private System.Windows.Forms.CheckBox conditionsBtn;
        private System.Windows.Forms.CheckBox movementBtn;
        private System.Windows.Forms.CheckBox settingsBtn;
        private System.Windows.Forms.CheckBox repeatBtn;
        private System.Windows.Forms.CheckBox ignoreBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Button waitBtn;
        private EGMGame.Controls.Game.MapEventComboBox cbEvents;
        private System.Windows.Forms.CheckBox chkWait;
        private System.Windows.Forms.Button btnChangeFreq;
        private System.Windows.Forms.Button btnFreqOff;
        private System.Windows.Forms.Button btnFreqOn;
        private System.Windows.Forms.Button btnApplyForce;
        private System.Windows.Forms.Button btnMoveToEvent;
        private System.Windows.Forms.Button btnTurnRand;
        private System.Windows.Forms.Button btnMoveRand;
        private System.Windows.Forms.Button moveTowardEventBtn;
        private System.Windows.Forms.Button moveAwayFromEventsBtn;
        private System.Windows.Forms.Button turnTowardEventBtn;
        private System.Windows.Forms.Button turnAwayEventBtn;
        private System.Windows.Forms.Button btnChangeFriction;
        private System.Windows.Forms.Button btnChangeRotationalDrag;
        private System.Windows.Forms.Button btnChangeBounce;
        private System.Windows.Forms.Button btnChangeMass;
        private System.Windows.Forms.Button btnChangeLinearDrag;
        private System.Windows.Forms.Button btnChangeForce;
        private System.Windows.Forms.Button btnChangeImpulse;
        private System.Windows.Forms.Button btnSetRotation;
        private System.Windows.Forms.Button btnApplyTorque;
        private System.Windows.Forms.Button btnApplyAngularImpulse;
        private System.Windows.Forms.Button btnApplyRotation;
        private System.Windows.Forms.Button btnClearForce;
        private System.Windows.Forms.Button btnAnimate;
        private System.Windows.Forms.Button btnNextFrame;
        private System.Windows.Forms.Button btnChangeSTatic;
        private System.Windows.Forms.Button btnPassOn;
        private System.Windows.Forms.Button btnPassOff;
        private System.Windows.Forms.Button btnIgnoreGravity;
        private System.Windows.Forms.Button btnCustomGravity;
        private System.Windows.Forms.CheckBox physicsBtn;
        private ImpactUI.ImpactGroupBox physicsBox;
        private System.Windows.Forms.Button btnStopAnimation;
        private Game.AttachmentComboBox attachmentList;
        private System.Windows.Forms.Button btnSyncAngleRotOn;
        private System.Windows.Forms.Button btnSyncAngleRotOff;

    }
}