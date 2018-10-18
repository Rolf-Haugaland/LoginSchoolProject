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
    public partial class ChangeUserName : Form
    {
        public ChangeUserName()
        {
            InitializeComponent();
        }

        bool StopForLoop = false;
        bool UserFound = false;

        int whichuser = 0;

        int a = 0;

        private void UnameReset_Click(object sender, EventArgs e)
        {
            //Defining variables and putting file values into strings and such
            FileStream fs = new FileStream("AllUsersAndPasswords.txt", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Flush();
            fs.Close();
            string Sbuffer = Encoding.ASCII.GetString(buffer);
            string[] AllUsersArray = Sbuffer.Split(',');
            //End
            if (UserFound)//This is set to true in the while statement underneath. 
            {
                AllUsersArray[whichuser] = txtbResetUname.Text;
                string test = string.Join(",", AllUsersArray);
                File.WriteAllText("AllUsersAndPasswords.txt", test);
                MessageBox.Show("Ditt nye brukernavn " + AllUsersArray[whichuser] + " er nå satt!");
                this.Close();
            }
            while(AllUsersArray.Length > a && !StopForLoop)
            {
                if (AllUsersArray[a] == txtbResetUname.Text)
                {
                    whichuser = a;
                    StopForLoop = true;
                    UserFound = true;
                }
                a = a + 2;
            }
            StopForLoop = false;
            if(UserFound)
            {
                lbl1.Text = "Greit! Vennligst skriv inn ditt nyte ønskede brukernavn";
            }
        }
    }
}
