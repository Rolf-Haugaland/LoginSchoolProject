namespace Login
{
    partial class LastInnSpill
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
            this.lblWhichGame = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtb1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblWhichGame
            // 
            this.lblWhichGame.AutoSize = true;
            this.lblWhichGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblWhichGame.Location = new System.Drawing.Point(80, 69);
            this.lblWhichGame.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblWhichGame.MinimumSize = new System.Drawing.Size(400, 0);
            this.lblWhichGame.Name = "lblWhichGame";
            this.lblWhichGame.Size = new System.Drawing.Size(400, 25);
            this.lblWhichGame.TabIndex = 0;
            this.lblWhichGame.Text = "Hvilke spill vil du laste inn?";
            this.lblWhichGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(243, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Ok_Click);
            // 
            // txtb1
            // 
            this.txtb1.Location = new System.Drawing.Point(230, 161);
            this.txtb1.Name = "txtb1";
            this.txtb1.Size = new System.Drawing.Size(100, 20);
            this.txtb1.TabIndex = 2;
            // 
            // LastInnSpill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 281);
            this.Controls.Add(this.txtb1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblWhichGame);
            this.Name = "LastInnSpill";
            this.Text = "LastInnSpill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWhichGame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtb1;
    }
}