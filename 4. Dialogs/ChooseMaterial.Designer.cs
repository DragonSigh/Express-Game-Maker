using EGMGame.Docking.Explorers;
namespace EGMGame.Dialogs
{
    partial class ChooseMaterialDialog
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Folder 2", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Example", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseMaterialDialog));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.explorerList = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.materialPreview = new EGMGame.Controls.MaterialViewer();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.explorerList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.materialPreview);
            this.splitContainer1.Size = new System.Drawing.Size(455, 400);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 2;
            // 
            // explorerList
            // 
            this.explorerList.AllowDrop = true;
            this.explorerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerList.ImageIndex = 0;
            this.explorerList.ImageList = this.imageList;
            this.explorerList.Location = new System.Drawing.Point(0, 0);
            this.explorerList.Name = "explorerList";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Node3";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Folder 2";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Example";
            this.explorerList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.explorerList.SelectedImageIndex = 0;
            this.explorerList.Size = new System.Drawing.Size(241, 396);
            this.explorerList.TabIndex = 1;
            this.explorerList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.explorerList_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "folder-open.png");
            this.imageList.Images.SetKeyName(2, "document.png");
            this.imageList.Images.SetKeyName(3, "document-image.png");
            this.imageList.Images.SetKeyName(4, "document-text.png");
            this.imageList.Images.SetKeyName(5, "folder-zipper.png");
            this.imageList.Images.SetKeyName(6, "document_gear.png");
            this.imageList.Images.SetKeyName(7, "document-music.png");
            this.imageList.Images.SetKeyName(8, "document-film.png");
            this.imageList.Images.SetKeyName(9, "document-c-sharp2.png");
            this.imageList.Images.SetKeyName(10, "document-xml.png");
            this.imageList.Images.SetKeyName(11, "document-pdf-text.png");
            this.imageList.Images.SetKeyName(12, "application-sidebar.png");
            this.imageList.Images.SetKeyName(13, "document-code.png");
            this.imageList.Images.SetKeyName(14, "document-table.png");
            this.imageList.Images.SetKeyName(15, "document_edit.png");
            this.imageList.Images.SetKeyName(16, "exclamation.png");
            // 
            // materialPreview
            // 
            this.materialPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialPreview.Location = new System.Drawing.Point(0, 0);
            this.materialPreview.Name = "materialPreview";
            this.materialPreview.SelectedMaterial = null;
            this.materialPreview.Size = new System.Drawing.Size(202, 396);
            this.materialPreview.TabIndex = 1;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(390, 418);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(309, 418);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 15;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // ChooseMaterialDialog
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(478, 446);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChooseMaterialDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Materials";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseMaterialDialog_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MaterialViewer materialPreview;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView explorerList;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
    }
}