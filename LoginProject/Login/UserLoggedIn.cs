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
    public partial class UserLoggedIn : Form
    {
        public UserLoggedIn()
        {
            InitializeComponent();
        }


        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Form1 showform1 = new Form1();
            showform1.Show();
            this.Close();
        }

        private void btn_PlayBondesjakk_Click(object sender, EventArgs e)
        {
            Bondesjakk SpillBondesjakk = new Bondesjakk();
            SpillBondesjakk.Show();
        }

        private void PlayHangman_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hangman SpillHangman = new Hangman();
            SpillHangman.Show();
        }

        public void show()
        {
            this.Show();
        }
    }
}
