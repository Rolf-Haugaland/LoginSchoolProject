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
            setcurrentuser();
        }
        bool tur;
        string user;
        private void setcurrentuser()
        {
            user = Form1.CurrentUserLoggedIn;
        }

        private void N_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (tur)
                b.Text = "X";
            else if (!tur)
                b.Text = "O";
            b.Enabled = false;
        }

        private void SjekkEtterVinner()
        {

        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.user1tur = tur;//Check user1 button
        }
    }
}
