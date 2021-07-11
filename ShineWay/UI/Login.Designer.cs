
namespace ShineWay.UI
{
    partial class form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Login));
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_loginBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_showPassword = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_forgotPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_loginBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_userName
            // 
            this.txt_userName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txt_userName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_userName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_userName.Location = new System.Drawing.Point(231, 332);
            this.txt_userName.Margin = new System.Windows.Forms.Padding(0);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(324, 29);
            this.txt_userName.TabIndex = 0;
            this.txt_userName.TextChanged += new System.EventHandler(this.txt_userName_TextChanged);
            this.txt_userName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_userName_KeyDown);
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_password.Location = new System.Drawing.Point(234, 434);
            this.txt_password.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(284, 29);
            this.txt_password.TabIndex = 1;
            this.txt_password.UseSystemPasswordChar = true;
            this.txt_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_password_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(219, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(219, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // pb_loginBtn
            // 
            this.pb_loginBtn.Image = global::ShineWay.Properties.Resources.loginbtn;
            this.pb_loginBtn.Location = new System.Drawing.Point(291, 504);
            this.pb_loginBtn.Name = "pb_loginBtn";
            this.pb_loginBtn.Size = new System.Drawing.Size(190, 47);
            this.pb_loginBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_loginBtn.TabIndex = 4;
            this.pb_loginBtn.TabStop = false;
            this.pb_loginBtn.Click += new System.EventHandler(this.pb_loginBtn_Click);
            this.pb_loginBtn.MouseLeave += new System.EventHandler(this.pb_loginBtn_MouseLeave);
            this.pb_loginBtn.MouseHover += new System.EventHandler(this.pb_loginBtn_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(291, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btn_Close.Location = new System.Drawing.Point(715, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(63, 43);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "X";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            this.btn_Close.MouseHover += new System.EventHandler(this.btn_Close_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(279, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 34);
            this.label3.TabIndex = 7;
            this.label3.Text = "Welcome Back!";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(219, 323);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(353, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(217, 425);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(353, 47);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // btn_showPassword
            // 
            this.btn_showPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btn_showPassword.FlatAppearance.BorderSize = 0;
            this.btn_showPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btn_showPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btn_showPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showPassword.Image = global::ShineWay.Properties.Resources.eye;
            this.btn_showPassword.Location = new System.Drawing.Point(524, 431);
            this.btn_showPassword.Name = "btn_showPassword";
            this.btn_showPassword.Size = new System.Drawing.Size(31, 32);
            this.btn_showPassword.TabIndex = 10;
            this.btn_showPassword.TabStop = false;
            this.btn_showPassword.UseVisualStyleBackColor = false;
            this.btn_showPassword.Click += new System.EventHandler(this.btn_showPassword_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(12, 570);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "©2021 Runtime Terror®";
            // 
            // label_forgotPassword
            // 
            this.label_forgotPassword.AutoSize = true;
            this.label_forgotPassword.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_forgotPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_forgotPassword.Location = new System.Drawing.Point(328, 475);
            this.label_forgotPassword.Name = "label_forgotPassword";
            this.label_forgotPassword.Size = new System.Drawing.Size(118, 16);
            this.label_forgotPassword.TabIndex = 11;
            this.label_forgotPassword.Text = "forgot password?";
            this.label_forgotPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_forgotPassword_MouseClick);
            this.label_forgotPassword.MouseLeave += new System.EventHandler(this.label_forgotPassword_MouseLeave);
            this.label_forgotPassword.MouseHover += new System.EventHandler(this.label_forgotPassword_MouseHover);
            // 
            // form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 596);
            this.Controls.Add(this.label_forgotPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_showPassword);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_loginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pb_loginBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pb_loginBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btn_showPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_forgotPassword;
    }
}