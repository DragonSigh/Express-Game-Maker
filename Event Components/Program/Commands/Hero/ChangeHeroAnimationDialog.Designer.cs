﻿namespace EGMGame.Controls.EventControls.EventDialogs
{
    partial class ChangeHeroAnimationDialog
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.directionsList = new System.Windows.Forms.ComboBox();
            this.animationViewer = new EGMGame.Controls.AnimationViewer();
            this.actionList = new EGMGame.Controls.Game.AnimationActionComboBox(this.components);
            this.groupBox = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.listBox = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbHero = new EGMGame.Controls.Game.HeroComboBox(this.components);
            this.cbActionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(314, 408);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(233, 408);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox2.CanCollapse = false;
            this.groupBox2.Controls.Add(this.directionsList);
            this.groupBox2.Controls.Add(this.animationViewer);
            this.groupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox2.Image = null;
            this.groupBox2.IsCollapsed = false;
            this.groupBox2.Location = new System.Drawing.Point(171, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(220, 223);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation";
            // 
            // directionsList
            // 
            this.directionsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionsList.FormattingEnabled = true;
            this.directionsList.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right",
            "Up/Left",
            "Up/Right",
            "Down/Left",
            "Down/Right"});
            this.directionsList.Location = new System.Drawing.Point(7, 194);
            this.directionsList.Name = "directionsList";
            this.directionsList.Size = new System.Drawing.Size(97, 21);
            this.directionsList.TabIndex = 10;
            this.directionsList.SelectedIndexChanged += new System.EventHandler(this.directionsList_SelectedIndexChanged);
            // 
            // animationViewer
            // 
            this.animationViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationViewer.Location = new System.Drawing.Point(7, 28);
            this.animationViewer.Name = "animationViewer";
            this.animationViewer.SelectedFrame = null;
            this.animationViewer.Size = new System.Drawing.Size(206, 160);
            this.animationViewer.TabIndex = 5;
            // 
            // actionList
            // 
            this.actionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.actionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionList.FormattingEnabled = true;
            this.actionList.Location = new System.Drawing.Point(9, 410);
            this.actionList.Name = "actionList";
            this.actionList.Noneable = false;
            this.actionList.Size = new System.Drawing.Size(156, 21);
            this.actionList.TabIndex = 11;
            // 
            // groupBox
            // 
            this.groupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.groupBox.CanCollapse = false;
            this.groupBox.Controls.Add(this.listBox);
            this.groupBox.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.groupBox.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.groupBox.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.groupBox.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.groupBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.groupBox.Image = null;
            this.groupBox.IsCollapsed = false;
            this.groupBox.Location = new System.Drawing.Point(9, 76);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.groupBox.Size = new System.Drawing.Size(156, 288);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Animations";
            // 
            // listBox
            // 
            this.listBox.AllowAdd = true;
            this.listBox.AllowCategories = true;
            this.listBox.AllowClipboard = true;
            this.listBox.AllowRemove = true;
            this.listBox.DisplayToolbar = false;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.EnableUpDown = false;
            this.listBox.Export = true;
            this.listBox.ImageList = null;
            this.listBox.Import = true;
            this.listBox.Location = new System.Drawing.Point(4, 25);
            this.listBox.Master = false;
            this.listBox.MultipleSelection = false;
            this.listBox.Name = "listBox";
            this.listBox.SelectedIndex = -1;
            this.listBox.ShowWarning = true;
            this.listBox.Size = new System.Drawing.Size(148, 258);
            this.listBox.TabIndex = 0;
            this.listBox.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.listBox_SelectItem);
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.CanCollapse = false;
            this.impactGroupBox3.Controls.Add(this.cbHero);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Image = null;
            this.impactGroupBox3.IsCollapsed = false;
            this.impactGroupBox3.Location = new System.Drawing.Point(9, 12);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(156, 58);
            this.impactGroupBox3.TabIndex = 9;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Hero";
            // 
            // cbHero
            // 
            this.cbHero.AllowCategories = true;
            this.cbHero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHero.FormattingEnabled = true;
            this.cbHero.Location = new System.Drawing.Point(4, 28);
            this.cbHero.Name = "cbHero";
            this.cbHero.Noneable = true;
            this.cbHero.SelectedNode = null;
            this.cbHero.Size = new System.Drawing.Size(145, 21);
            this.cbHero.TabIndex = 0;
            // 
            // cbActionType
            // 
            this.cbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionType.FormattingEnabled = true;
            this.cbActionType.Items.AddRange(new object[] {
            "Idle",
            "Walking",
            "Equipment (Offensive)",
            "Equipment (Defensive)",
            "Skill",
            "Magic",
            "Item",
            "Hit",
            "Jump",
            "Death"});
            this.cbActionType.Location = new System.Drawing.Point(9, 383);
            this.cbActionType.Name = "cbActionType";
            this.cbActionType.Size = new System.Drawing.Size(133, 21);
            this.cbActionType.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Select action type and action.";
            // 
            // ChangeHeroAnimationDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(401, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbActionType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.actionList);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeHeroAnimationDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Event Animation";
            this.Shown += new System.EventHandler(this.ChangeAnimationDialog_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.impactGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        internal EGMGame.Controls.Game.AnimationActionComboBox actionList;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox groupBox2;
        private System.Windows.Forms.ComboBox directionsList;
        private AnimationViewer animationViewer;
        private AddRemoveList listBox;
        private Game.HeroComboBox cbHero;
        private System.Windows.Forms.ComboBox cbActionType;
        private System.Windows.Forms.Label label1;
    }
}