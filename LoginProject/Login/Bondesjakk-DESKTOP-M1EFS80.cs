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
    public partial class Bondesjakk : Form
    {
        public Bondesjakk()
        {
            InitializeComponent();
            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            lbl_XWins.Text = ("X: " + Values.XWins.ToString());
            lbl_OWins.Text = ("O: " + Values.OWins.ToString());
            lbl_Draw.Text = ("Uavgjort" + Values.draw.ToString());
        }

        private void N_Click(object sender, EventArgs e)
        {
            Values.turncounter++;
            Button b = (Button)sender;
            if (Values.tur)
                b.Text = "X";
            else if (!Values.tur)
                b.Text = "o";
            b.Enabled = false;
            SkjekkEtterVinner();
            if (Values.turncounter == 9)
                uavgjort();
            Values.tur = !Values.tur;
        }
        private void SkjekkEtterVinner()
        {//Vanrett
            if (O1.Text == O2.Text && O2.Text == O3.Text && O1.Enabled == false)
                Values.DetErEnVinner = true;
            else if (M1.Text == M2.Text && M2.Text == M3.Text && M1.Enabled == false)
                Values.DetErEnVinner = true;
            else if (N1.Text == N2.Text && N2.Text == N3.Text && N1.Enabled == false)
                Values.DetErEnVinner = true;
            //Lodrett
            else if (O1.Text == M1.Text && M1.Text == N1.Text && O1.Enabled == false)
                Values.DetErEnVinner = true;
            else if (O2.Text == M2.Text && M2.Text == N2.Text && O2.Enabled == false)
                Values.DetErEnVinner = true;
            else if (O3.Text == M3.Text && M3.Text == N3.Text && O3.Enabled == false)
                Values.DetErEnVinner = true;
            //Diagonalt
            else if (O1.Text == M2.Text && M2.Text == N3.Text && O1.Enabled == false)
                Values.DetErEnVinner = true;
            else if (O3.Text == M2.Text && M2.Text == N1.Text && O3.Enabled == false)
                Values.DetErEnVinner = true;
            
            if (Values.tur)
                Values.vinner= "X";
            else if (!Values.tur)
                Values.vinner = "O";
            //Slutter spillet og sier grattis, du vant
            if (Values.DetErEnVinner)
            {
                if(Values.tur)
                {
                    Values.XWins++;
                    lbl_XWins.Text = ("X: " + Values.XWins);
                }
                else if (!Values.tur)
                {
                    Values.OWins++;
                    lbl_OWins.Text = ("O: " + Values.OWins);
                }

                foreach (Control c in Controls)
                {
                    if(c.GetType() == typeof(Button))
                    c.Enabled = false;
                }
                Values.turncounter = 0;
                Values.DetErEnVinner = false;
                MessageBox.Show(Values.vinner + " Vinner!");
            }
        }
        private void SoftResetGame()
        {
            Values.tur = true;
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Enabled = true;
                    c.Text = "";
                }
            }
            Values.turncounter = 0;
            Values.DetErEnVinner = false;
        }
        private void NewGame_Click(object sender, EventArgs e)
        {
            SoftResetGame();
        }
        private void uavgjort()
        {
            Values.draw++;
            lbl_Draw.Text = ("Uavgjort: " + Values.draw);
            MessageBox.Show("Det ble desverre uavgjort!");
        }

        private void Avslutt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Check when form is closed. Then it should not load user values, it will only do so after the log out button has been pressed
        private void Bondesjakk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Values.LoadValues = false;
        }
    }
}
