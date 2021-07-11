
namespace ShineWay.Messages
{
    partial class CustomMessage
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
            this.label_messageTitle = new System.Windows.Forms.Label();
            this.btn_btn2 = new System.Windows.Forms.Button();
            this.label_message = new System.Windows.Forms.Label();
            this.pb_icon = new System.Windows.Forms.PictureBox();
            this.btn_btn1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // label_messageTitle
            // 
            this.label_messageTitle.AutoSize = true;
            this.label_messageTitle.Font = new System.Drawing.Font("Century Gothic", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label_messageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_messageTitle.Location = new System.Drawing.Point(12, 9);
            this.label_messageTitle.Name = "label_messageTitle";
            this.label_messageTitle.Size = new System.Drawing.Size(84, 19);
            this.label_messageTitle.TabIndex = 0;
            this.label_messageTitle.Text = "Message";
            // 
            // btn_btn2
            // 
            this.btn_btn2.BackColor = System.Drawing.Color.Red;
            this.btn_btn2.FlatAppearance.BorderSize = 0;
            this.btn_btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_btn2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_btn2.ForeColor = System.Drawing.Color.White;
            this.btn_btn2.Location = new System.Drawing.Point(308, 109);
            this.btn_btn2.Name = "btn_btn2";
            this.btn_btn2.Size = new System.Drawing.Size(94, 42);
            this.btn_btn2.TabIndex = 1;
            this.btn_btn2.Text = "No";
            this.btn_btn2.UseVisualStyleBackColor = false;
            this.btn_btn2.Click += new System.EventHandler(this.btn_btn2_Click);
            // 
            // label_message
            // 
            this.label_message.AutoEllipsis = true;
            this.label_message.AutoSize = true;
            this.label_message.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_message.Location = new System.Drawing.Point(138, 40);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(357, 23);
            this.label_message.TabIndex = 2;
            this.label_message.Text = "Username or Passsword is incorrect!";
            this.label_message.Click += new System.EventHandler(this.label_message_Click);
            // 
            // pb_icon
            // 
            this.pb_icon.Image = global::ShineWay.Properties.Resources.question;
            this.pb_icon.Location = new System.Drawing.Point(12, 31);
            this.pb_icon.Name = "pb_icon";
            this.pb_icon.Size = new System.Drawing.Size(120, 120);
            this.pb_icon.TabIndex = 3;
            this.pb_icon.TabStop = false;
            // 
            // btn_btn1
            // 
            this.btn_btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_btn1.FlatAppearance.BorderSize = 0;
            this.btn_btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_btn1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_btn1.ForeColor = System.Drawing.Color.White;
            this.btn_btn1.Location = new System.Drawing.Point(208, 109);
            this.btn_btn1.Name = "btn_btn1";
            this.btn_btn1.Size = new System.Drawing.Size(94, 42);
            this.btn_btn1.TabIndex = 4;
            this.btn_btn1.Text = "Yes";
            this.btn_btn1.UseVisualStyleBackColor = false;
            this.btn_btn1.Click += new System.EventHandler(this.btn_btn1_Click);
            // 
            // CustomMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(430, 170);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.btn_btn1);
            this.Controls.Add(this.pb_icon);
            this.Controls.Add(this.btn_btn2);
            this.Controls.Add(this.label_messageTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomMessage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessage";
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_messageTitle;
        private System.Windows.Forms.Button btn_btn2;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.PictureBox pb_icon;
        private System.Windows.Forms.Button btn_btn1;
    }
}