using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
            ResetPassword6();
        }
        bool PWChangeUser1 = false;
        bool PWChangeUser2 = false;
        bool PWChangeUser3 = false;

        bool CorrectPWUser1 = false;
        bool CorrectPWUser2 = false;
        bool CorrectPWUser3 = false;

        string pass;
        string user;

        bool PWChangeOnGoing = false;
        public void ResetPassword6()
        {
            btn_user1.Text = user;

        }

        private void PWReset_Click(object sender, EventArgs e)
        {
            if (CorrectPWUser1)
            {
                pass = txtbResetPW.Text;
                MessageBox.Show("Nytt passord for " + user + " er satt!");
                this.Close();
            }
            if ((PWChangeUser1) && (txtbResetPW.Text == pass))
            {
                lbl1.Text = "Korrekt passord! Vennligst skriv inn ett nytt passord for " + user;
                PWChangeUser1 = false;
                CorrectPWUser1 = true;
            }
        }
        private void User1_Click(object sender, EventArgs e)
        {
            txtbResetPW.Visible = true;
            if (PWChangeOnGoing)
            {
                MessageBox.Show("Du heller allerede på med ett passordbytte, en om gangen!");
            }
            else if (!PWChangeOnGoing)
            {
                lbl1.Text = "Greit! Vennligst skriv inn det gamle passordet for denne brukeren.";
                PWChangeUser1 = true;
                PWChangeOnGoing = true;
            }
        }
    }
}
