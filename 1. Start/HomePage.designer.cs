namespace EGMGame.Docking.Homepage
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.flowPanel1 = new EGMGame.Controls.FlowPanel();
            this.menuContainer2 = new EGMGame.Docking.Homepage.MenuContainer();
            this.startList = new EGMGame.Docking.Homepage.MenuList();
            this.menuContainer1 = new EGMGame.Docking.Homepage.MenuContainer();
            this.userList = new EGMGame.Docking.Homepage.MenuList();
            this.menuContainer3 = new EGMGame.Docking.Homepage.MenuContainer();
            this.newsMenuList1 = new EGMGame.Docking.Homepage.NewsMenuList();
            this.dockContextMenu1 = new EGMGame.Controls.UI.DockContextMenu();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowPanel1.SuspendLayout();
            this.menuContainer2.SuspendLayout();
            this.menuContainer1.SuspendLayout();
            this.menuContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::EGMGame.Properties.Resources.Express_Your_Creativity;
            this.pictureBox3.Location = new System.Drawing.Point(528, 55);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(181, 72);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::EGMGame.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::EGMGame.Properties.Resources.HomepageBackTest;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(735, 588);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // flowPanel1
            // 
            this.flowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowPanel1.Controls.Add(this.menuContainer2);
            this.flowPanel1.Controls.Add(this.menuContainer1);
            this.flowPanel1.Controls.Add(this.menuContainer3);
            this.flowPanel1.Location = new System.Drawing.Point(12, 151);
            this.flowPanel1.Name = "flowPanel1";
            this.flowPanel1.Size = new System.Drawing.Size(711, 425);
            this.flowPanel1.SpacingHorizantal = 15;
            this.flowPanel1.SpacingVertical = 10;
            this.flowPanel1.TabIndex = 1;
            // 
            // menuContainer2
            // 
            this.menuContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuContainer2.BackColor = System.Drawing.Color.Transparent;
            this.menuContainer2.Controls.Add(this.startList);
            this.menuContainer2.Font = new System.Drawing.Font("Tahoma", 13F);
            this.menuContainer2.ForeColor = System.Drawing.Color.White;
            this.menuContainer2.Icon = global::EGMGame.Properties.Resources.star;
            this.menuContainer2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(106)))), ((int)(((byte)(184)))));
            this.menuContainer2.LinkFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuContainer2.LinkText = "More Resources...";
            this.menuContainer2.LinkURL = "http://google.co.uk";
            this.menuContainer2.Location = new System.Drawing.Point(15, 10);
            this.menuContainer2.Name = "menuContainer2";
            this.menuContainer2.Padding = new System.Windows.Forms.Padding(14, 18, 14, 37);
            this.menuContainer2.Size = new System.Drawing.Size(222, 405);
            this.menuContainer2.TabIndex = 8;
            this.menuContainer2.TabStop = false;
            this.menuContainer2.Text = "Getting Started";
            // 
            // startList
            // 
            this.startList.AutoScroll = true;
            this.startList.ButtonFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startList.CategoryFont = new System.Drawing.Font("Tahoma", 12F);
            this.startList.DetailColor = System.Drawing.Color.SteelBlue;
            this.startList.DetailedFont = new System.Drawing.Font("Tahoma", 11F);
            this.startList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.startList.Location = new System.Drawing.Point(14, 39);
            this.startList.Name = "startList";
            this.startList.Size = new System.Drawing.Size(194, 329);
            this.startList.SubTextColor = System.Drawing.Color.Gray;
            this.startList.SubTextFont = new System.Drawing.Font("Tahoma", 9F);
            this.startList.TabIndex = 0;
            this.startList.Text = "menuList1";
            // 
            // menuContainer1
            // 
            this.menuContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuContainer1.BackColor = System.Drawing.Color.Transparent;
            this.menuContainer1.Controls.Add(this.userList);
            this.menuContainer1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.menuContainer1.ForeColor = System.Drawing.Color.White;
            this.menuContainer1.Icon = global::EGMGame.Properties.Resources.door_open;
            this.menuContainer1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(106)))), ((int)(((byte)(184)))));
            this.menuContainer1.LinkFont = new System.Drawing.Font("Verdana", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.menuContainer1.LinkText = "";
            this.menuContainer1.LinkURL = "";
            this.menuContainer1.Location = new System.Drawing.Point(252, 10);
            this.menuContainer1.Name = "menuContainer1";
            this.menuContainer1.Padding = new System.Windows.Forms.Padding(14, 18, 14, 20);
            this.menuContainer1.Size = new System.Drawing.Size(222, 405);
            this.menuContainer1.TabIndex = 7;
            this.menuContainer1.TabStop = false;
            this.menuContainer1.Text = "Returning User";
            // 
            // userList
            // 
            this.userList.AutoScroll = true;
            this.userList.ButtonFont = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userList.CategoryFont = new System.Drawing.Font("Tahoma", 12F);
            this.userList.DetailColor = System.Drawing.Color.SteelBlue;
            this.userList.DetailedFont = new System.Drawing.Font("Tahoma", 11F);
            this.userList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.userList.Location = new System.Drawing.Point(14, 39);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(194, 346);
            this.userList.SubTextColor = System.Drawing.Color.Gray;
            this.userList.SubTextFont = new System.Drawing.Font("Tahoma", 9F);
            this.userList.TabIndex = 0;
            this.userList.Text = "menuList1";
            // 
            // menuContainer3
            // 
            this.menuContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuContainer3.BackColor = System.Drawing.Color.Transparent;
            this.menuContainer3.Controls.Add(this.newsMenuList1);
            this.menuContainer3.Font = new System.Drawing.Font("Tahoma", 13F);
            this.menuContainer3.ForeColor = System.Drawing.Color.White;
            this.menuContainer3.Icon = global::EGMGame.Properties.Resources.newspaper;
            this.menuContainer3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(106)))), ((int)(((byte)(184)))));
            this.menuContainer3.LinkFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuContainer3.LinkText = "Read More...";
            this.menuContainer3.LinkURL = "http://google.co.uk";
            this.menuContainer3.Location = new System.Drawing.Point(489, 10);
            this.menuContainer3.Name = "menuContainer3";
            this.menuContainer3.Padding = new System.Windows.Forms.Padding(14, 18, 14, 37);
            this.menuContainer3.Size = new System.Drawing.Size(222, 405);
            this.menuContainer3.TabIndex = 6;
            this.menuContainer3.TabStop = false;
            this.menuContainer3.Text = "News";
            // 
            // newsMenuList1
            // 
            this.newsMenuList1.AutoScroll = true;
            this.newsMenuList1.ButtonFont = new System.Drawing.Font("Tahoma", 15F);
            this.newsMenuList1.CategoryFont = new System.Drawing.Font("Tahoma", 12F);
            this.newsMenuList1.DetailColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(187)))), ((int)(((byte)(212)))));
            this.newsMenuList1.DetailedFont = new System.Drawing.Font("Tahoma", 10F);
            this.newsMenuList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsMenuList1.ErrorFont = new System.Drawing.Font("Verdana", 8F);
            this.newsMenuList1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(103)))), ((int)(((byte)(103)))));
            this.newsMenuList1.HasFeed = false;
            this.newsMenuList1.Location = new System.Drawing.Point(14, 39);
            this.newsMenuList1.Name = "newsMenuList1";
            this.newsMenuList1.Size = new System.Drawing.Size(194, 329);
            this.newsMenuList1.SubTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(176)))), ((int)(((byte)(179)))));
            this.newsMenuList1.SubTextFont = new System.Drawing.Font("Tahoma", 8F);
            this.newsMenuList1.TabIndex = 0;
            this.newsMenuList1.Text = "newsMenuList1";
            // 
            // dockContextMenu1
            // 
            this.dockContextMenu1.Name = "contextMenuStrip1";
            this.dockContextMenu1.Size = new System.Drawing.Size(167, 48);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EGMGame.Properties.Resources.HomepageBackTest;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(735, 588);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.flowPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "Homepage";
            this.Text = "Homepage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowPanel1.ResumeLayout(false);
            this.menuContainer2.ResumeLayout(false);
            this.menuContainer1.ResumeLayout(false);
            this.menuContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private EGMGame.Controls.FlowPanel flowPanel1;
        private MenuContainer menuContainer2;
        private MenuContainer menuContainer1;
        private MenuContainer menuContainer3;
        private MenuList startList;
        private MenuList userList;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private NewsMenuList newsMenuList1;
        private Controls.UI.DockContextMenu dockContextMenu1;
    }
}