namespace AfishA
{
    partial class change
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(change));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(399, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "ПОМЕНЯТЬ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(399, 142);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 80);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(380, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "ВВЕДИТЕ НОВЫЙ ПАРОЛЬ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.Location = new System.Drawing.Point(12, 142);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(166, 80);
            this.textBox2.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PeachPuff;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "ПОМЕНЯТЬ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(9, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "ВВЕДИТЕ НОВЫЙ ЛОГИН";
            // 
            // change
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(577, 325);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "change";
            this.Text = "ИЗМЕНЕНИЕ";
            this.Load += new System.EventHandler(this.change_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
    }
}