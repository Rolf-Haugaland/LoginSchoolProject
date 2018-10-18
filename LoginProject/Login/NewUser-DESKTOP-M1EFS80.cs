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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }
        private void btn_NewUser_Click(object sender, EventArgs e)
        {
            if ((txtbUserame.Text == "") || (txtbPW.Text == ""))
                MessageBox.Show("Vennligst skriv inn brukernavn og passord.");
            else if (txtbUserame.Text == (Values.user1 ?? Values.user2 ?? Values.user3))
                MessageBox.Show("Noen andre har allerede dette brukernavnet. Vennligst velg et annet brukernavn");
            else if ((txtbUserame.TextLength == 1) || (txtbPW.TextLength == 1))
                MessageBox.Show("Kan ikke ha for kort brukernavn eller passord");
            else if (Values.NewUserNumber == 1)
            {
                Values.user1 = txtbUserame.Text;
                Values.pass1 = txtbPW.Text;
                Values.NewUserNumber++;
                MessageBox.Show("Bruker nummer 1 er laget med brukernavn " + Values.user1);
                this.Close();
            }
            else if (Values.NewUserNumber == 2)
            {
                Values.user2 = txtbUserame.Text;
                Values.pass2 = txtbPW.Text;
                Values.NewUserNumber++;
                MessageBox.Show("Bruker nummer 2 er laget med brukernavn " + Values.user2);
                this.Close();
            }
            else if (Values.NewUserNumber == 3)
            {
                Values.user3 = txtbUserame.Text;
                Values.pass3 = txtbPW.Text;
                Values.NewUserNumber++;
                MessageBox.Show("Bruker nummer 3 er laget med brukernavn " + Values.user3);
                this.Close();
            }
        }
    }
}
