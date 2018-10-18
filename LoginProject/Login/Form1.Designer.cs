namespace Login
{
    partial class Form1
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
            this.txtbBrukernavn = new System.Windows.Forms.TextBox();
            this.txtbPassord = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slettAltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oppsettToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nyBrukerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endreBrukernavnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endrePassordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbBrukernavn
            // 
            this.txtbBrukernavn.Location = new System.Drawing.Point(69, 138);
            this.txtbBrukernavn.Name = "txtbBrukernavn";
            this.txtbBrukernavn.Size = new System.Drawing.Size(163, 20);
            this.txtbBrukernavn.TabIndex = 1;
            this.txtbBrukernavn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_press);
            // 
            // txtbPassord
            // 
            this.txtbPassord.Location = new System.Drawing.Point(69, 204);
            this.txtbPassord.Name = "txtbPassord";
            this.txtbPassord.Size = new System.Drawing.Size(163, 20);
            this.txtbPassord.TabIndex = 2;
            this.txtbPassord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_press);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(66, 107);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(125, 13);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Skriv inn ditt brukernavn:";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(113, 262);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Log in";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_LogIn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filToolStripMenuItem,
            this.oppsettToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(385, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filToolStripMenuItem
            // 
            this.filToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.slettAltToolStripMenuItem});
            this.filToolStripMenuItem.Name = "filToolStripMenuItem";
            this.filToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.filToolStripMenuItem.Text = "Fil";
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.statusToolStripMenuItem.Text = "Status";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.Status_Click);
            // 
            // slettAltToolStripMenuItem
            // 
            this.slettAltToolStripMenuItem.Name = "slettAltToolStripMenuItem";
            this.slettAltToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.slettAltToolStripMenuItem.Text = "Slett alt";
            this.slettAltToolStripMenuItem.Click += new System.EventHandler(this.DeleteUsers_Click);
            // 
            // oppsettToolStripMenuItem
            // 
            this.oppsettToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nyBrukerToolStripMenuItem,
            this.endreBrukernavnToolStripMenuItem,
            this.endrePassordToolStripMenuItem});
            this.oppsettToolStripMenuItem.Name = "oppsettToolStripMenuItem";
            this.oppsettToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.oppsettToolStripMenuItem.Text = "Oppsett";
            // 
            // nyBrukerToolStripMenuItem
            // 
            this.nyBrukerToolStripMenuItem.Name = "nyBrukerToolStripMenuItem";
            this.nyBrukerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.nyBrukerToolStripMenuItem.Text = "Ny Bruker";
            this.nyBrukerToolStripMenuItem.Click += new System.EventHandler(this.nyBrukerToolStripMenuItem_Click);
            // 
            // endreBrukernavnToolStripMenuItem
            // 
            this.endreBrukernavnToolStripMenuItem.Name = "endreBrukernavnToolStripMenuItem";
            this.endreBrukernavnToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.endreBrukernavnToolStripMenuItem.Text = "Endre Brukernavn";
            this.endreBrukernavnToolStripMenuItem.Click += new System.EventHandler(this.endreBrukernavnToolStripMenuItem_Click);
            // 
            // endrePassordToolStripMenuItem
            // 
            this.endrePassordToolStripMenuItem.Name = "endrePassordToolStripMenuItem";
            this.endrePassordToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.endrePassordToolStripMenuItem.Text = "Endre Passord";
            this.endrePassordToolStripMenuItem.Click += new System.EventHandler(this.endrePassordToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 330);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtbPassord);
            this.Controls.Add(this.txtbBrukernavn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Logg inn";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtbBrukernavn;
        private System.Windows.Forms.TextBox txtbPassord;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oppsettToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endrePassordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endreBrukernavnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nyBrukerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slettAltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
    }
}

