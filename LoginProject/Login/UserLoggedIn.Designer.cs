namespace Login
{
    partial class UserLoggedIn
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
            this.lbl_WelcomeUname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.btn_PlayBondesjakk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_WelcomeUname
            // 
            this.lbl_WelcomeUname.AutoSize = true;
            this.lbl_WelcomeUname.Location = new System.Drawing.Point(352, 9);
            this.lbl_WelcomeUname.Name = "lbl_WelcomeUname";
            this.lbl_WelcomeUname.Size = new System.Drawing.Size(72, 13);
            this.lbl_WelcomeUname.TabIndex = 0;
            this.lbl_WelcomeUname.Text = "Velkommen X";
            this.lbl_WelcomeUname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Her er noen ting du kan gjøre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.Location = new System.Drawing.Point(713, 415);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(75, 23);
            this.btn_LogOut.TabIndex = 2;
            this.btn_LogOut.Text = "Logg ut";
            this.btn_LogOut.UseVisualStyleBackColor = true;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // btn_PlayBondesjakk
            // 
            this.btn_PlayBondesjakk.Location = new System.Drawing.Point(122, 174);
            this.btn_PlayBondesjakk.Name = "btn_PlayBondesjakk";
            this.btn_PlayBondesjakk.Size = new System.Drawing.Size(75, 23);
            this.btn_PlayBondesjakk.TabIndex = 3;
            this.btn_PlayBondesjakk.Text = "Bondesjakk";
            this.btn_PlayBondesjakk.UseVisualStyleBackColor = true;
            this.btn_PlayBondesjakk.Click += new System.EventHandler(this.btn_PlayBondesjakk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Hangman!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PlayHangman_Click);
            // 
            // UserLoggedIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_PlayBondesjakk);
            this.Controls.Add(this.btn_LogOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_WelcomeUname);
            this.Name = "UserLoggedIn";
            this.Text = "UserLoggedIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_WelcomeUname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.Button btn_PlayBondesjakk;
        private System.Windows.Forms.Button button1;
    }
}