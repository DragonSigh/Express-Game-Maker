//-----------------------------------------------------------------------------
// MainForm.Designer.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

namespace EGMGame
{
    partial class FontGenDialog
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
            this.FontName = new System.Windows.Forms.ComboBox();
            this.FontStyle = new System.Windows.Forms.ComboBox();
            this.FontSize = new System.Windows.Forms.ComboBox();
            this.Antialias = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Sample = new System.Windows.Forms.Label();
            this.MaxChar = new System.Windows.Forms.TextBox();
            this.MinChar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.impactGroupBox1 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox2 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.impactGroupBox3 = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.Export = new System.Windows.Forms.Button();
            this.btnCustomFont = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.impactGroupBox1.SuspendLayout();
            this.impactGroupBox2.SuspendLayout();
            this.impactGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FontName
            // 
            this.FontName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.FontName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FontName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.FontName.FormattingEnabled = true;
            this.FontName.Location = new System.Drawing.Point(4, 25);
            this.FontName.Name = "FontName";
            this.FontName.Size = new System.Drawing.Size(189, 144);
            this.FontName.TabIndex = 1;
            this.FontName.SelectedIndexChanged += new System.EventHandler(this.FontName_SelectedIndexChanged);
            // 
            // FontStyle
            // 
            this.FontStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.FontStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FontStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.FontStyle.FormattingEnabled = true;
            this.FontStyle.Items.AddRange(new object[] {
            "Regular",
            "Italic",
            "Bold",
            "Bold, Italic"});
            this.FontStyle.Location = new System.Drawing.Point(4, 25);
            this.FontStyle.Name = "FontStyle";
            this.FontStyle.Size = new System.Drawing.Size(66, 173);
            this.FontStyle.TabIndex = 3;
            this.FontStyle.Text = "Regular";
            this.FontStyle.SelectedIndexChanged += new System.EventHandler(this.FontStyle_SelectedIndexChanged);
            // 
            // FontSize
            // 
            this.FontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.FontSize.FormattingEnabled = true;
            this.FontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "23",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.FontSize.Location = new System.Drawing.Point(4, 25);
            this.FontSize.Name = "FontSize";
            this.FontSize.Size = new System.Drawing.Size(63, 173);
            this.FontSize.TabIndex = 5;
            this.FontSize.Text = "23";
            this.FontSize.SelectedIndexChanged += new System.EventHandler(this.FontSize_SelectedIndexChanged);
            this.FontSize.TextUpdate += new System.EventHandler(this.FontSize_TextUpdate);
            // 
            // Antialias
            // 
            this.Antialias.AutoSize = true;
            this.Antialias.Checked = true;
            this.Antialias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Antialias.Location = new System.Drawing.Point(182, 243);
            this.Antialias.Name = "Antialias";
            this.Antialias.Size = new System.Drawing.Size(77, 17);
            this.Antialias.TabIndex = 10;
            this.Antialias.Text = "&Antialiased";
            this.Antialias.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "M&in char:";
            // 
            // Sample
            // 
            this.Sample.AutoEllipsis = true;
            this.Sample.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sample.Location = new System.Drawing.Point(12, 269);
            this.Sample.Name = "Sample";
            this.Sample.Size = new System.Drawing.Size(354, 172);
            this.Sample.TabIndex = 12;
            this.Sample.Text = "The quick brown fox jumped over the lazy dog.";
            this.Sample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaxChar
            // 
            this.MaxChar.Location = new System.Drawing.Point(97, 240);
            this.MaxChar.Name = "MaxChar";
            this.MaxChar.Size = new System.Drawing.Size(63, 20);
            this.MaxChar.TabIndex = 9;
            this.MaxChar.Text = "0x7F";
            // 
            // MinChar
            // 
            this.MinChar.Location = new System.Drawing.Point(15, 240);
            this.MinChar.Name = "MinChar";
            this.MinChar.Size = new System.Drawing.Size(63, 20);
            this.MinChar.TabIndex = 7;
            this.MinChar.Text = "0x20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ma&x char:";
            // 
            // impactGroupBox1
            // 
            this.impactGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox1.CanCollapse = false;
            this.impactGroupBox1.Controls.Add(this.FontName);
            this.impactGroupBox1.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox1.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox1.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox1.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox1.Image = null;
            this.impactGroupBox1.IsCollapsed = false;
            this.impactGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.impactGroupBox1.Name = "impactGroupBox1";
            this.impactGroupBox1.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox1.Size = new System.Drawing.Size(197, 174);
            this.impactGroupBox1.TabIndex = 16;
            this.impactGroupBox1.TabStop = false;
            this.impactGroupBox1.Text = "Font";
            // 
            // impactGroupBox2
            // 
            this.impactGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox2.CanCollapse = false;
            this.impactGroupBox2.Controls.Add(this.FontStyle);
            this.impactGroupBox2.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox2.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox2.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox2.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox2.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox2.Image = null;
            this.impactGroupBox2.IsCollapsed = false;
            this.impactGroupBox2.Location = new System.Drawing.Point(215, 12);
            this.impactGroupBox2.Name = "impactGroupBox2";
            this.impactGroupBox2.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox2.Size = new System.Drawing.Size(74, 203);
            this.impactGroupBox2.TabIndex = 17;
            this.impactGroupBox2.TabStop = false;
            this.impactGroupBox2.Text = "Font Style";
            // 
            // impactGroupBox3
            // 
            this.impactGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.impactGroupBox3.CanCollapse = false;
            this.impactGroupBox3.Controls.Add(this.FontSize);
            this.impactGroupBox3.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.impactGroupBox3.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.impactGroupBox3.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.impactGroupBox3.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.impactGroupBox3.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.impactGroupBox3.Image = null;
            this.impactGroupBox3.IsCollapsed = false;
            this.impactGroupBox3.Location = new System.Drawing.Point(295, 12);
            this.impactGroupBox3.Name = "impactGroupBox3";
            this.impactGroupBox3.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.impactGroupBox3.Size = new System.Drawing.Size(71, 203);
            this.impactGroupBox3.TabIndex = 18;
            this.impactGroupBox3.TabStop = false;
            this.impactGroupBox3.Text = "Size";
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(295, 237);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 11;
            this.Export.Text = "&Create";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // btnCustomFont
            // 
            this.btnCustomFont.Location = new System.Drawing.Point(12, 192);
            this.btnCustomFont.Name = "btnCustomFont";
            this.btnCustomFont.Size = new System.Drawing.Size(197, 23);
            this.btnCustomFont.TabIndex = 19;
            this.btnCustomFont.Text = "&Custom Font";
            this.btnCustomFont.UseVisualStyleBackColor = true;
            this.btnCustomFont.Click += new System.EventHandler(this.btnCustomFont_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openDialog";
            this.openDialog.Filter = "True Type Font|*.ttf";
            // 
            // FontGenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 450);
            this.Controls.Add(this.btnCustomFont);
            this.Controls.Add(this.impactGroupBox3);
            this.Controls.Add(this.impactGroupBox2);
            this.Controls.Add(this.impactGroupBox1);
            this.Controls.Add(this.MinChar);
            this.Controls.Add(this.MaxChar);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Sample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Antialias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FontGenDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Font";
            this.impactGroupBox1.ResumeLayout(false);
            this.impactGroupBox2.ResumeLayout(false);
            this.impactGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FontName;
        private System.Windows.Forms.ComboBox FontStyle;
        private System.Windows.Forms.ComboBox FontSize;
        private System.Windows.Forms.CheckBox Antialias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Sample;
        private System.Windows.Forms.TextBox MaxChar;
        private System.Windows.Forms.TextBox MinChar;
        private System.Windows.Forms.Label label4;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox1;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox2;
        private Controls.ImpactUI.ImpactGroupBox impactGroupBox3;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button btnCustomFont;
        private System.Windows.Forms.OpenFileDialog openDialog;
    }
}

