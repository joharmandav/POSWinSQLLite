namespace supershop.User_mgt
{
    partial class Manage_user
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manage_user));
            this.btnCreateLink = new System.Windows.Forms.Button();
            this.flowLayoutPanelUserList = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtsearchUser = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lnkWorkingHours = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateLink
            // 
            this.btnCreateLink.BackColor = System.Drawing.SystemColors.Control;
            this.btnCreateLink.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCreateLink.FlatAppearance.BorderSize = 0;
            this.btnCreateLink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCreateLink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.btnCreateLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateLink.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateLink.Image")));
            this.btnCreateLink.Location = new System.Drawing.Point(770, 3);
            this.btnCreateLink.Name = "btnCreateLink";
            this.btnCreateLink.Size = new System.Drawing.Size(146, 34);
            this.btnCreateLink.TabIndex = 29;
            this.btnCreateLink.Text = " Create New User";
            this.btnCreateLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateLink.UseVisualStyleBackColor = false;
            this.btnCreateLink.Click += new System.EventHandler(this.btnCreateLink_Click);
            // 
            // flowLayoutPanelUserList
            // 
            this.flowLayoutPanelUserList.AutoScroll = true;
            this.flowLayoutPanelUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelUserList.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelUserList.Name = "flowLayoutPanelUserList";
            this.flowLayoutPanelUserList.Size = new System.Drawing.Size(1054, 523);
            this.flowLayoutPanelUserList.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lnkWorkingHours);
            this.splitContainer1.Panel1.Controls.Add(this.txtsearchUser);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateLink);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanelUserList);
            this.splitContainer1.Size = new System.Drawing.Size(1054, 567);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 146;
            // 
            // txtsearchUser
            // 
            this.txtsearchUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsearchUser.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchUser.Location = new System.Drawing.Point(6, 9);
            this.txtsearchUser.Name = "txtsearchUser";
            this.txtsearchUser.Size = new System.Drawing.Size(746, 23);
            this.txtsearchUser.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtsearchUser, "Search by UserID Or Name OR Contact OR Position");
            this.txtsearchUser.TextChanged += new System.EventHandler(this.txtsearchUser_TextChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 9;
            this.toolTip1.ReshowDelay = 9;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // lnkWorkingHours
            // 
            this.lnkWorkingHours.AutoSize = true;
            this.lnkWorkingHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lnkWorkingHours.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkWorkingHours.Location = new System.Drawing.Point(941, 12);
            this.lnkWorkingHours.Name = "lnkWorkingHours";
            this.lnkWorkingHours.Size = new System.Drawing.Size(78, 16);
            this.lnkWorkingHours.TabIndex = 147;
            this.lnkWorkingHours.TabStop = true;
            this.lnkWorkingHours.Text = "Work Sheet";
            this.lnkWorkingHours.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWorkingHours_LinkClicked);
            // 
            // Manage_user
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1054, 567);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Manage_user";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage user";
            this.Load += new System.EventHandler(this.Manage_user_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Manage_user_MouseDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateLink;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUserList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtsearchUser;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnkWorkingHours;
    }
}