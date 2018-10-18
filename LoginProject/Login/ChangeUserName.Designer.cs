namespace Login
{
    partial class ChangeUserName
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtbResetUname = new System.Windows.Forms.TextBox();
            this.btn_resetUname = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl1.Location = new System.Drawing.Point(116, 77);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(343, 20);
            this.lbl1.TabIndex = 8;
            this.lbl1.Text = "Hvilke bruker prøver du å endre brukernavn for?";
            // 
            // txtbResetUname
            // 
            this.txtbResetUname.Location = new System.Drawing.Point(119, 112);
            this.txtbResetUname.Name = "txtbResetUname";
            this.txtbResetUname.Size = new System.Drawing.Size(188, 20);
            this.txtbResetUname.TabIndex = 7;
            // 
            // btn_resetUname
            // 
            this.btn_resetUname.Location = new System.Drawing.Point(120, 165);
            this.btn_resetUname.Name = "btn_resetUname";
            this.btn_resetUname.Size = new System.Drawing.Size(75, 23);
            this.btn_resetUname.TabIndex = 6;
            this.btn_resetUname.Text = "OK";
            this.btn_resetUname.UseVisualStyleBackColor = true;
            this.btn_resetUname.Click += new System.EventHandler(this.UnameReset_Click);
            // 
            // ChangeUserName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 237);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtbResetUname);
            this.Controls.Add(this.btn_resetUname);
            this.Name = "ChangeUserName";
            this.Text = "ChangeUserName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtbResetUname;
        private System.Windows.Forms.Button btn_resetUname;
    }
}