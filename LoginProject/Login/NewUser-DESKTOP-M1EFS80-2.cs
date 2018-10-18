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
            //Function to check if the user already exists
            //Make ByteArrays and convert what needs to be converted
            FileStream fs1 = new FileStream("AllUsersAndPasswords.txt", FileMode.OpenOrCreate, FileAccess.Read);
            byte[] buffer = new byte[fs1.Length];
            fs1.Read(buffer, 0, buffer.Length);
            fs1.Flush();
            fs1.Close();
            //Done, i now have the file into a byte array. 
            //Converting byte array to string array with user,pass and , as dilimiter
            string bufferstring = Encoding.ASCII.GetString(buffer);
            string[] AllUsersInArray = bufferstring.Split(',');
            for (int i = 0; AllUsersInArray.Length > i; i = i + 2)
            {
                if(txtbUserame.Text == "" || txtbPW.Text == "")
                {
                    MessageBox.Show("Vennligst skriv inn brukernavn og passord");
                    return;
                }
                if (AllUsersInArray[i] == txtbUserame.Text)
                {
                    MessageBox.Show("Brukeren finnes allerede, vennligst velg et annet brukernavn");
                    return;
                }
            }
            {
                //Need to make sure the "AllUnamesAndPass" file is formatted properly. This checks if the file is empty, if it is empty, i do not want to start with 
                //a comma in the file. we want "user1,Pass1,User2,Pass2" and so on. This makes sure it will never be ",user1,pass1,user2,pass2" *Check the commas*
                if (new FileInfo("AllUsersAndPasswords.txt").Length == 0)
                    DontAddComma = true;


                //Make ByteArrays and convert what needs to be converted
                string literallyJustAComma = ",";
                byte[] CommaForDelimiter = new byte[literallyJustAComma.Length];
                CommaForDelimiter = Encoding.ASCII.GetBytes(literallyJustAComma);
                byte[] Username = new byte[txtbUserame.Text.Length];
                Username = Encoding.ASCII.GetBytes(txtbUserame.Text);
                byte[] Password = new byte[txtbPW.Text.Length];
                Password = Encoding.ASCII.GetBytes(txtbPW.Text);
                //Done

                //Write new user accounts to "all users and passwords" file
                FileStream fs = new FileStream("AllUsersAndPasswords.txt", FileMode.Append, FileAccess.Write);
                if(!DontAddComma)//Only adds comma if boolean is false. This is so that the formatting of the file will always be correct. See top of file.*Check the comma*
                {
                    fs.Write(CommaForDelimiter, 0, literallyJustAComma.Length);
                }
                fs.Write(Username, 0, txtbUserame.Text.Length);
                fs.Write(CommaForDelimiter, 0, literallyJustAComma.Length);
                fs.Write(Password, 0, txtbPW.Text.Length);
                fs.Flush();
                fs.Close();
                //Done
                DontAddComma = false;//This boolean is enabled at the top of this block if certain conditions are true. We always want it to initially be false.
                //Creates the user file and closes the FileStream
                File.Create("Brukere/" + txtbUserame.Text + ".txt").Close();
                //Adds the UserName to own private file
                FileStream AddUser = new FileStream("Brukere/" + txtbUserame.Text + ".txt", FileMode.Append, FileAccess.Write);
                byte[] username = new byte[txtbUserame.Text.Length];
                username = Encoding.ASCII.GetBytes(txtbUserame.Text);
                AddUser.Write(username, 0, txtbUserame.Text.Length);
                AddUser.Flush();
                AddUser.Close();
                MessageBox.Show("Din nye bruker " + txtbUserame.Text + " er opprettet!");
                this.Close();
            }
        }
    }
}
