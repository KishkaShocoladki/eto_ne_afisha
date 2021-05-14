namespace AfishA
{
    partial class user
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("профиль");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("пользователи");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("отзывы");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("брон. мероприятия");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("мероприятия");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("участники");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("площадки");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("добавление");
            this.panel11 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.AutoScroll = true;
            this.panel11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel11.BackgroundImage")));
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(584, 349);
            this.panel11.TabIndex = 13;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.LemonChiffon;
            this.treeView1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(581, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Узел0";
            treeNode1.Text = "профиль";
            treeNode2.Name = "Узел0";
            treeNode2.Text = "пользователи";
            treeNode3.Name = "Узел1";
            treeNode3.Text = "отзывы";
            treeNode4.Name = "Узел2";
            treeNode4.Text = "брон. мероприятия";
            treeNode5.Name = "Узел3";
            treeNode5.Text = "мероприятия";
            treeNode6.Name = "Узел4";
            treeNode6.Text = "участники";
            treeNode7.Name = "Узел5";
            treeNode7.Text = "площадки";
            treeNode8.Name = "Узел6";
            treeNode8.Text = "добавление";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(178, 349);
            this.treeView1.TabIndex = 13;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(750, 349);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel11);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(766, 387);
            this.Name = "user";
            this.Text = "user";
            this.Load += new System.EventHandler(this.user_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TreeView treeView1;
    }
}