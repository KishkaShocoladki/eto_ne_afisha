﻿namespace AfishA
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("посмотреть всех пользователей");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("посмотреть все отзывы");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("посмотреть все забронированные мероприятия");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("посмотреть все мероприятия");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("посмотреть всех участников");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("посмотреть все площадки");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("че то посмотреть", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("добавление");
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(397, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "ПОСМОТРЕТЬ ЗАБРОНИРОВАННЫЕ МЕРОПРИЯТИЯ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Info;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(423, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "ПОСМОТРЕТЬ СВОИ ОТЗЫВЫ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Info;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(436, 137);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "ДОБАВЛЕНИЕ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Info;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(414, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 52);
            this.button4.TabIndex = 3;
            this.button4.Text = "ПОСМОТРЕТЬ ВСЕХ УЧАСТНИКОВ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button5_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Info;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.Location = new System.Drawing.Point(414, 166);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "ПОСМОТРЕТЬ ВСЕ МЕРОПРИЯТИЯ";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Info;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(414, 280);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 49);
            this.button6.TabIndex = 5;
            this.button6.Text = "ПОСМОТРЕТЬ ВСЕ ПЛОЩАДКИ";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Info;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.Location = new System.Drawing.Point(25, 272);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(157, 57);
            this.button7.TabIndex = 6;
            this.button7.Text = "ПОСМОТРЕТЬ ВСЕ ЗАБРОНИРОВАННЫЕ МЕРОПРИЯТИЯ";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Info;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button8.Location = new System.Drawing.Point(25, 224);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(141, 42);
            this.button8.TabIndex = 7;
            this.button8.Text = "ПОСМОТРЕТЬ ВСЕ ОТЗЫВЫ";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.Info;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button9.Location = new System.Drawing.Point(25, 174);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(157, 44);
            this.button9.TabIndex = 8;
            this.button9.Text = "ПОСМОТРЕТЬ ВСЕХ ПОЛЬЗОВАТЕЛЕЙ";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.Info;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button11.Location = new System.Drawing.Point(25, 41);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(141, 56);
            this.button11.TabIndex = 10;
            this.button11.Text = "СМЕНИТЬ ИМЯ ПОЛЬЗОВАТЕЛЯ ИЛИ ПАРОЛЬ";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "ИМЯ ПОЛЬЗОВАТЕЛЯ";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.Info;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button.Location = new System.Drawing.Point(25, 103);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(120, 41);
            this.button.TabIndex = 12;
            this.button.Text = "ПРОСМОТРЕТЬ ОШИБКИ";
            this.button.UseVisualStyleBackColor = false;
            this.button.Visible = false;
            this.button.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // panel11
            // 
            this.panel11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel11.BackgroundImage")));
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel11.Controls.Add(this.button3);
            this.panel11.Controls.Add(this.button);
            this.panel11.Controls.Add(this.button1);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.button2);
            this.panel11.Controls.Add(this.button11);
            this.panel11.Controls.Add(this.button4);
            this.panel11.Controls.Add(this.button9);
            this.panel11.Controls.Add(this.button5);
            this.panel11.Controls.Add(this.button8);
            this.panel11.Controls.Add(this.button6);
            this.panel11.Controls.Add(this.button7);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(527, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(588, 349);
            this.panel11.TabIndex = 13;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "посмотреть всех пользователей";
            treeNode2.Name = "Узел4";
            treeNode2.Text = "посмотреть все отзывы";
            treeNode3.Name = "Узел5";
            treeNode3.Text = "посмотреть все забронированные мероприятия";
            treeNode4.Name = "Узел7";
            treeNode4.Text = "посмотреть все мероприятия";
            treeNode5.Name = "Узел8";
            treeNode5.Text = "посмотреть всех участников";
            treeNode6.Name = "Узел9";
            treeNode6.Text = "посмотреть все площадки";
            treeNode7.Name = "Узел0";
            treeNode7.Text = "че то посмотреть";
            treeNode8.Name = "Узел10";
            treeNode8.Text = "добавление";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(215, 349);
            this.treeView1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(221, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 349);
            this.panel1.TabIndex = 14;
            // 
            // user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1115, 349);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel11);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "user";
            this.Text = "user";
            this.Load += new System.EventHandler(this.user_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
    }
}