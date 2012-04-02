namespace EGMGame.Controls.EventControls.EventDialogs
{
    partial class LocalVariablesDialog
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
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.conditionsList = new EGMGame.Controls.AddRemoveList();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.orBox = new System.Windows.Forms.CheckBox();
            this.variableList = new EGMGame.Controls.Game.VariableComboBox(this.components);
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.variableCondList = new System.Windows.Forms.ComboBox();
            this.numberBox = new CustomUpDown();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.addRemoveList = new EGMGame.Controls.AddRemoveList();
            this.impactGroupBox3.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).BeginInit();
            this.impactGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.Controls.Add(this.conditionsList);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(186, 120);
            this.impactGroupBox3.TabIndex = 14;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Conditions";
            // 
            // conditionsList
            // 
            this.conditionsList.AllowAdd = true;
            this.conditionsList.AllowCategories = false;
            this.conditionsList.AllowRemove = true;
            this.conditionsList.DisplayToolbar = true;
            this.conditionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conditionsList.EnableUpDown = true;
            this.conditionsList.ImageList = null;
            this.conditionsList.Location = new System.Drawing.Point(4, 25);
            this.conditionsList.Master = false;
            this.conditionsList.MultipleSelection = false;
            this.conditionsList.Name = "conditionsList";
            this.conditionsList.SelectedIndex = -1;
            this.conditionsList.ShowWarning = true;
            this.conditionsList.Size = new System.Drawing.Size(178, 90);
            this.conditionsList.TabIndex = 1;
            this.conditionsList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.conditionsList_RemoveItem);
            this.conditionsList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.conditionsList_SelectItem);
            this.conditionsList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.conditionsList_AddItem);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(123, 485);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(42, 485);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 12;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.Controls.Add(this.orBox);
            this.impactGroupBox2.Controls.Add(this.variableList);
            this.impactGroupBox2.Controls.Add(this.radioButton2);
            this.impactGroupBox2.Controls.Add(this.radioButton1);
            this.impactGroupBox2.Controls.Add(this.variableCondList);
            this.impactGroupBox2.Controls.Add(this.numberBox);
            this.impactGroupBox2.Enabled = false;
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Location = new System.Drawing.Point(12, 363);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(186, 116);
            this.impactGroupBox2.TabIndex = 11;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Conditions";
            // 
            // orBox
            // 
            this.orBox.AutoSize = true;
            this.orBox.BackColor = System.Drawing.Color.Transparent;
            this.orBox.Location = new System.Drawing.Point(7, 30);
            this.orBox.Name = "orBox";
            this.orBox.Size = new System.Drawing.Size(37, 17);
            this.orBox.TabIndex = 12;
            this.orBox.Text = "Or";
            this.orBox.UseVisualStyleBackColor = false;
            this.orBox.CheckedChanged += new System.EventHandler(this.orBox_CheckedChanged);
            // 
            // variableList
            // 
            this.variableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableList.Enabled = false;
            this.variableList.FormattingEnabled = true;
            this.variableList.Location = new System.Drawing.Point(30, 84);
            this.variableList.Name = "variableList";
            this.variableList.Size = new System.Drawing.Size(149, 21);
            this.variableList.TabIndex = 11;
            this.variableList.SelectedIndexChanged += new System.EventHandler(this.varaibleList_SelectedIndexChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Location = new System.Drawing.Point(7, 87);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 57);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // variableCondList
            // 
            this.variableCondList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.variableCondList.FormattingEnabled = true;
            this.variableCondList.Items.AddRange(new object[] {
            "(=) Equals",
            "(!=) Does Not Equal",
            "(<) Less Than",
            "(>) Greater Than",
            "(<=) Less Than Or Equals",
            "(>=) Greater Than Or Equals"});
            this.variableCondList.Location = new System.Drawing.Point(61, 28);
            this.variableCondList.Name = "variableCondList";
            this.variableCondList.Size = new System.Drawing.Size(118, 21);
            this.variableCondList.TabIndex = 7;
            this.variableCondList.SelectionChangeCommitted += new System.EventHandler(this.variableCondList_SelectedIndexChanged);
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(30, 55);
            this.numberBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numberBox.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(149, 20);
            this.numberBox.TabIndex = 5;
            this.numberBox.ValueChanged += new System.EventHandler(this.numberBox_ValueChanged);
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.Controls.Add(this.addRemoveList);
            this.impactGroupBox1.Enabled = false;
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 138);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(186, 219);
            this.impactGroupBox1.TabIndex = 10;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Local Variables";
            // 
            // addRemoveList
            // 
            this.addRemoveList.AllowAdd = true;
            this.addRemoveList.AllowCategories = true;
            this.addRemoveList.AllowRemove = true;
            this.addRemoveList.DisplayToolbar = true;
            this.addRemoveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addRemoveList.EnableUpDown = false;
            this.addRemoveList.ImageList = null;
            this.addRemoveList.Location = new System.Drawing.Point(4, 25);
            this.addRemoveList.Master = false;
            this.addRemoveList.MultipleSelection = false;
            this.addRemoveList.Name = "addRemoveList";
            this.addRemoveList.SelectedIndex = -1;
            this.addRemoveList.ShowWarning = true;
            this.addRemoveList.Size = new System.Drawing.Size(178, 189);
            this.addRemoveList.TabIndex = 2;
            this.addRemoveList.RemoveItem += new EGMGame.Controls.AddRemoveList.RemoveItemEvent(this.addRemoveList_RemoveItem);
            this.addRemoveList.SelectItem += new EGMGame.Controls.AddRemoveList.SelectItemEvent(this.addRemoveList_SelectItem);
            this.addRemoveList.AddItem += new EGMGame.Controls.AddRemoveList.AddItemEvent(this.addRemoveList_AddItem);
            // 
            // LocalVariablesDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(208, 513);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalVariablesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Variable Conditions";
            this.impactGroupBox3.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberBox)).EndInit();
            this.impactGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private AddRemoveList conditionsList;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private System.Windows.Forms.CheckBox orBox;
        private EGMGame.Controls.Game.VariableComboBox variableList;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox variableCondList;
        private CustomUpDown numberBox;
        private EGMGame.Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private AddRemoveList addRemoveList;


    }
}