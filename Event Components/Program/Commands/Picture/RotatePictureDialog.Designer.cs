﻿namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Picture
{
    partial class RotatePictureDialog
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
            this.impactGroupBox4 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.picIndex = new EGMGame.CustomUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.operationTypeList = new System.Windows.Forms.ComboBox();
            this.coordinatePanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRotateTo = new EGMGame.CustomUpDown();
            this.variablesPanel = new EGMGame.Controls.ImpactUI.ImpactPanel();
            this.cbRotateVar = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chkCenter = new System.Windows.Forms.CheckBox();
            this.impactGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.coordinatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbRotateTo)).BeginInit();
            this.variablesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactGroupBox4
            // 
            this.impactGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox4.CanCollapse = false;
            this.impactGroupBox4.Controls.Add(this.picIndex);
            this.impactGroupBox4.Controls.Add(this.label1);
            this.impactGroupBox4.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox4.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox4.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox4.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox4.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox4.Image = null;
            this.impactGroupBox4.IsCollapsed = false;
            this.impactGroupBox4.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox4.Name = "impactGroupBox4";
            this.impactGroupBox4.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox4.Size = new System.Drawing.Size(193, 67);
            this.impactGroupBox4.TabIndex = 30;
            this.impactGroupBox4.TabStop = false;
            this.impactGroupBox4.Text = "Picture";
            // 
            // picIndex
            // 
            this.picIndex.Location = new System.Drawing.Point(8, 41);
            this.picIndex.Name = "picIndex";
            this.picIndex.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.picIndex.OnChange = false;
            this.picIndex.Size = new System.Drawing.Size(43, 20);
            this.picIndex.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Choose the index of the picture.";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(131, 219);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 31;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(50, 219);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 28;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.operationTypeList);
            this.impactGroupBox1.Controls.Add(this.coordinatePanel);
            this.impactGroupBox1.Controls.Add(this.variablesPanel);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 85);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(193, 98);
            this.impactGroupBox1.TabIndex = 29;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Rotation";
            // 
            // operationTypeList
            // 
            this.operationTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationTypeList.FormattingEnabled = true;
            this.operationTypeList.Items.AddRange(new object[] {
            "Coordinates",
            "Variables"});
            this.operationTypeList.Location = new System.Drawing.Point(12, 24);
            this.operationTypeList.Name = "operationTypeList";
            this.operationTypeList.Size = new System.Drawing.Size(95, 21);
            this.operationTypeList.TabIndex = 11;
            this.operationTypeList.SelectedIndexChanged += new System.EventHandler(this.operationTypeList_SelectedIndexChanged);
            // 
            // coordinatePanel
            // 
            this.coordinatePanel.BackColor = System.Drawing.Color.Transparent;
            this.coordinatePanel.Controls.Add(this.label4);
            this.coordinatePanel.Controls.Add(this.cbRotateTo);
            this.coordinatePanel.Location = new System.Drawing.Point(12, 51);
            this.coordinatePanel.Name = "coordinatePanel";
            this.coordinatePanel.Size = new System.Drawing.Size(174, 36);
            this.coordinatePanel.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(2, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rotate To: ";
            // 
            // cbRotateTo
            // 
            this.cbRotateTo.Location = new System.Drawing.Point(69, 3);
            this.cbRotateTo.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.cbRotateTo.Name = "cbRotateTo";
            this.cbRotateTo.OldValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.cbRotateTo.OnChange = false;
            this.cbRotateTo.Size = new System.Drawing.Size(61, 20);
            this.cbRotateTo.TabIndex = 7;
            // 
            // variablesPanel
            // 
            this.variablesPanel.BackColor = System.Drawing.Color.Transparent;
            this.variablesPanel.Controls.Add(this.cbRotateVar);
            this.variablesPanel.Controls.Add(this.label2);
            this.variablesPanel.Location = new System.Drawing.Point(12, 51);
            this.variablesPanel.Name = "variablesPanel";
            this.variablesPanel.Size = new System.Drawing.Size(174, 36);
            this.variablesPanel.TabIndex = 11;
            this.variablesPanel.Visible = false;
            // 
            // cbRotateVar
            // 
            this.cbRotateVar.AllowCategories = true;
            this.cbRotateVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRotateVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotateVar.FormattingEnabled = true;
            this.cbRotateVar.Location = new System.Drawing.Point(70, 5);
            this.cbRotateVar.Name = "cbRotateVar";
            this.cbRotateVar.Noneable = false;
            this.cbRotateVar.SelectedNode = null;
            this.cbRotateVar.Size = new System.Drawing.Size(99, 21);
            this.cbRotateVar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rotate To: ";
            // 
            // chkCenter
            // 
            this.chkCenter.AutoSize = true;
            this.chkCenter.Checked = true;
            this.chkCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCenter.Location = new System.Drawing.Point(12, 189);
            this.chkCenter.Name = "chkCenter";
            this.chkCenter.Size = new System.Drawing.Size(118, 17);
            this.chkCenter.TabIndex = 32;
            this.chkCenter.Text = "Rotate From Center";
            this.chkCenter.UseVisualStyleBackColor = true;
            // 
            // RotatePictureDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 251);
            this.Controls.Add(this.chkCenter);
            this.Controls.Add(this.impactGroupBox4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RotatePictureDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rotate Picture";
            this.impactGroupBox4.ResumeLayout(false);
            this.impactGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.coordinatePanel.ResumeLayout(false);
            this.coordinatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbRotateTo)).EndInit();
            this.variablesPanel.ResumeLayout(false);
            this.variablesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImpactUI.ImpactGroupBox impactGroupBox4;
        private CustomUpDown picIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private ImpactUI.ImpactGroupBox impactGroupBox1;
        private ImpactUI.ImpactPanel variablesPanel;
        private Game.VariableComboBox cbRotateVar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox operationTypeList;
        private ImpactUI.ImpactPanel coordinatePanel;
        private System.Windows.Forms.Label label4;
        private CustomUpDown cbRotateTo;
        private System.Windows.Forms.CheckBox chkCenter;
    }
}