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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartupMessage();
        }

        private void BrukerLogin()
        {
            if ((Values.user1 ?? Values.pass1 ?? Values.user2 ?? Values.pass2 ?? Values.user3 ?? Values.pass3) == string.Empty)
                MessageBox.Show("Det ser ikke ut til at du har laget noen brukere enda, se Opsett>Ny Bruker");
            else if ((Values.user1 == txtbBrukernavn.Text) && (Values.pass1 == txtbPassord.Text) && (txtbBrukernavn.Text != "") && (txtbPassord.Text != ""))
            {
                Values.User1LoggedIn = true;
                MessageBox.Show("Velkommen, " + Values.user1);
            }
            else if ((Values.user2 == txtbBrukernavn.Text) && (Values.pass2 == txtbPassord.Text) && (!(txtbBrukernavn.Text == "")) && (txtbPassord.Text != ""))
            {
                Values.User2LoggedIn = true;
                MessageBox.Show("Velkommen, " + Values.user2);
            }
            else if ((Values.user3 == txtbBrukernavn.Text) && (Values.pass3 == txtbPassord.Text) && (!(txtbBrukernavn.Text == "")) && (txtbPassord.Text != ""))
            {
                Values.User3LoggedIn = true;
                MessageBox.Show("Velkommen, " + Values.user3);
            }
            else if ((txtbBrukernavn.Text == "") || (txtbPassord.Text == ""))
                MessageBox.Show("Vennligst skriv inn brukernavn og passord");
            else 
                MessageBox.Show("Feil brukernavn eller passord.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrukerLogin();
            if(Values.User1LoggedIn || Values.User2LoggedIn || Values.User3LoggedIn)
            {
                this.Hide();
                UserLoggedIn UserWindow = new UserLoggedIn();
                UserWindow.Show();
            }
        }

        private void endrePassordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Values.user1) && string.IsNullOrWhiteSpace(Values.user2) && string.IsNullOrWhiteSpace(Values.user3))
            {
                MessageBox.Show("Det ser ikke ut til at du har laget noen brukere enda. Trykk på Opsett>Ny Bruker for å lage en ny bruker");
            }
            else
            {
                ResetPassword Reset1 = new ResetPassword();
                DialogResult test = Reset1.ShowDialog();
            }
        }



        private void endreBrukernavnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Values.user1) && string.IsNullOrWhiteSpace(Values.user2) && string.IsNullOrWhiteSpace(Values.user3))
            {
                MessageBox.Show("Det ser ikke ut til at du har laget noen brukere enda. Trykk på Opsett>Ny Bruker for å lage en ny bruker");
            }
            else
            {
                ChangeUserName ChangeUname = new ChangeUserName();
                DialogResult open = ChangeUname.ShowDialog();
            }
        }

        private void nyBrukerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser CreateNewUser = new NewUser();
            DialogResult MakeNewUser = CreateNewUser.ShowDialog();
        }
        private void StartupMessage()
        {
            if(Values.FirstStart)
            {
                MessageBox.Show("Heisann! Vennligst les 'Om>Om' for VIKTIG informasjon. Denne applikasjonen er enda under utvikling og testing, og derfor kreves det " +
                    "at brukeren selv vet hvordan man skal bruke programmet!");
                Values.FirstStart = false;
            }

        }
        public void CloseThis()
        {
            this.Close();
        }

        private void Avslutt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
