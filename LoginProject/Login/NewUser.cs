using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Login
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }
        int NewUserNumber = 1;
        bool DontAddComma = false;
        private void btn_NewUser_Click(object sender, EventArgs e)
        {
            {
                Data1 UserFiles = new Data1();
                UserFiles.readFile();
                if ((txtbUserame.Text == "") || (txtbPW.Text == ""))
                {
                    MessageBox.Show("Vennligst skriv inn brukernavn og passord.");
                    return;
                }
                else if (txtbUserame.Text == txtbPW.Text)
                {
                    MessageBox.Show("Kan ikke ha samme brukernavn som passord");
                    return;
                }
                for (int i = 0; UserFiles.UserFileStringArray.Length > i; i = i)
                {
                    if(UserFiles.UserFileStringArray[i] == txtbUserame.Text)
                    {
                        MessageBox.Show("En bruker med dette brukernavnet finnes allerede, vennligst vel et annet brukernavn");
                        return;
                    }
                    i = i + 2;
                }
                FileStream fs = new FileStream("AllUsersAndPasswords.txt", FileMode.Append, FileAccess.Write);
                byte[] LiterallyJustAComma = new byte[1];
                LiterallyJustAComma = Encoding.ASCII.GetBytes(",");
                byte[] Uname = new byte[txtbUserame.Text.Length];
                byte[] Password = new byte[txtbPW.Text.Length];
                Uname = Encoding.ASCII.GetBytes(txtbUserame.Text);
                Password = Encoding.ASCII.GetBytes(txtbPW.Text);
                if (UserFiles.StringwholeFile != "")
                {
                    fs.Write(LiterallyJustAComma, 0, LiterallyJustAComma.Length);
                }
                fs.Write(Uname, 0, Uname.Length);
                fs.Write(LiterallyJustAComma, 0, LiterallyJustAComma.Length);
                fs.Write(Password, 0, Password.Length);
                fs.Flush();
                fs.Close();
                MessageBox.Show("Din nye bruker " + txtbUserame.Text + " er opprettet");
                Directory.CreateDirectory("Brukere/" + txtbUserame.Text);
                this.Close();
            }
        }
    }
}
