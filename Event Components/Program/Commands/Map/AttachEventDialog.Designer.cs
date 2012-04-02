namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs
{
    partial class AttachCameraToEventDialog
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
            this.box = new EGMGame.Controls.ImpactUI.ImpactGroupBox();
            this.cbEvents = new EGMGame.Controls.Game.MapEventComboBox(this.components);
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbEvent = new System.Windows.Forms.RadioButton();
            this.box.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(125, 104);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 27;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(44, 104);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 26;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // box
            // 
            this.box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(126)))), ((int)(((byte)(133)))));
            this.box.CanCollapse = false;
            this.box.Controls.Add(this.rbEvent);
            this.box.Controls.Add(this.rbNone);
            this.box.Controls.Add(this.cbEvents);
            this.box.Gradient1Color = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.box.Gradient2Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(191)))), ((int)(((byte)(240)))));
            this.box.Gradient3Color = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(167)))), ((int)(((byte)(204)))));
            this.box.Gradient4Color = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(135)))), ((int)(((byte)(172)))));
            this.box.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.box.Image = null;
            this.box.IsCollapsed = false;
            this.box.Location = new System.Drawing.Point(12, 12);
            this.box.Name = "box";
            this.box.Padding = new System.Windows.Forms.Padding(4, 12, 4, 5);
            this.box.Size = new System.Drawing.Size(189, 86);
            this.box.TabIndex = 0;
            this.box.TabStop = false;
            this.box.Text = "Event";
            // 
            // cbEvents
            // 
            this.cbEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvents.Enabled = false;
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(32, 57);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.ShowPlayer = true;
            this.cbEvents.ShowTarget = true;
            this.cbEvents.ShowTargets = false;
            this.cbEvents.Size = new System.Drawing.Size(150, 21);
            this.cbEvents.TabIndex = 0;
            this.cbEvents.ThisEvent = false;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Location = new System.Drawing.Point(7, 28);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 1;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // rbEvent
            // 
            this.rbEvent.AutoSize = true;
            this.rbEvent.Location = new System.Drawing.Point(7, 58);
            this.rbEvent.Name = "rbEvent";
            this.rbEvent.Size = new System.Drawing.Size(14, 13);
            this.rbEvent.TabIndex = 2;
            this.rbEvent.UseVisualStyleBackColor = true;
            this.rbEvent.CheckedChanged += new System.EventHandler(this.rbEvent_CheckedChanged);
            // 
            // AttachCameraToEventDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(212, 139);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttachCameraToEventDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attach Camera To Event";
            this.box.ResumeLayout(false);
            this.box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private ImpactUI.ImpactGroupBox box;
        private Game.MapEventComboBox cbEvents;
        private System.Windows.Forms.RadioButton rbEvent;
        private System.Windows.Forms.RadioButton rbNone;
    }
}