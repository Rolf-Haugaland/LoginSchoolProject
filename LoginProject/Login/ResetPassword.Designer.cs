namespace Login
{
    partial class ResetPassword
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
            this.btn_resetPW = new System.Windows.Forms.Button();
            this.txtbResetPW = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btn_user1 = new System.Windows.Forms.Button();
            this.btn_user2 = new System.Windows.Forms.Button();
            this.btn_user3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_resetPW
            // 
            this.btn_resetPW.Location = new System.Drawing.Point(203, 217);
            this.btn_resetPW.Name = "btn_resetPW";
            this.btn_resetPW.Size = new System.Drawing.Size(75, 23);
            this.btn_resetPW.TabIndex = 0;
            this.btn_resetPW.Text = "OK";
            this.btn_resetPW.UseVisualStyleBackColor = true;
            this.btn_resetPW.Click += new System.EventHandler(this.PWReset_Click);
            // 
            // txtbResetPW
            // 
            this.txtbResetPW.Location = new System.Drawing.Point(203, 154);
            this.txtbResetPW.Name = "txtbResetPW";
            this.txtbResetPW.Size = new System.Drawing.Size(100, 20);
            this.txtbResetPW.TabIndex = 1;
            this.txtbResetPW.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(200, 85);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(227, 13);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Hvilke bruker prøver du å endre passorder for?";
            // 
            // btn_user1
            // 
            this.btn_user1.Location = new System.Drawing.Point(203, 116);
            this.btn_user1.Name = "btn_user1";
            this.btn_user1.Size = new System.Drawing.Size(100, 23);
            this.btn_user1.TabIndex = 3;
            this.btn_user1.Text = "button1";
            this.btn_user1.UseVisualStyleBackColor = true;
            this.btn_user1.Click += new System.EventHandler(this.User1_Click);
            // 
            // btn_user2
            // 
            this.btn_user2.Location = new System.Drawing.Point(309, 116);
            this.btn_user2.Name = "btn_user2";
            this.btn_user2.Size = new System.Drawing.Size(100, 23);
            this.btn_user2.TabIndex = 4;
            this.btn_user2.Text = "button2";
            this.btn_user2.UseVisualStyleBackColor = true;
            // 
            // btn_user3
            // 
            this.btn_user3.Location = new System.Drawing.Point(415, 116);
            this.btn_user3.Name = "btn_user3";
            this.btn_user3.Size = new System.Drawing.Size(100, 23);
            this.btn_user3.TabIndex = 5;
            this.btn_user3.Text = "button3";
            this.btn_user3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_user3);
            this.Controls.Add(this.btn_user2);
            this.Controls.Add(this.btn_user1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtbResetPW);
            this.Controls.Add(this.btn_resetPW);
            this.Name = "ResetPassword";
            this.Text = "ResetPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_resetPW;
        private System.Windows.Forms.TextBox txtbResetPW;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btn_user1;
        private System.Windows.Forms.Button btn_user2;
        private System.Windows.Forms.Button btn_user3;
        private System.Windows.Forms.Button button1;
    }
}