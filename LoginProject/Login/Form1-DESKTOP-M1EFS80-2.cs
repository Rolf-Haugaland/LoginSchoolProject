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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartupMessage();
            onetimestuff();
        }

        string[] UnameLine = { };

        int userline2 = 0;
        //bondesjakk
        public static bool user1tur = true;
        public static bool user2tur = true;
        public static bool user3tur = true;


        public static string CurrentUserLoggedIn = "";

        public static string user1notepad = "";
        public static string user2notepad = "";
        public static string user3notepad = "";

        //String som er brukernavnene og passordene til 
        public static string user1 = "";
        public static string pass1 = "";

        public static string user2 = "";
        public static string pass2 = "";

        public static string user3 = "";
        public static string pass3 = "";

        //Boolean to determine who is logged in. If it is true, then that user is logged in.
        public static bool User1LoggedIn = false;
        public static bool User2LoggedIn = false;
        public static bool User3LoggedIn = false;

        //Used to check if login is sucsessful
        public static bool UserNameCorrect = false;
        public static bool PasswordCorrect = false;

        bool restartrequired = false;

        private void onetimestuff()
        {
            if(!Directory.Exists("Brukere"))
            {
                Directory.CreateDirectory("Brukere");
            }
            if(!File.Exists("AllUsersAndPasswords.txt"))
                File.Create("AllUsersAndPasswords.txt").Close();
            if (!File.Exists("CurrentLoggedInFile.txt"))
                File.Create("CurrentLoggedInFile.txt").Close();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            if(txtbBrukernavn.Text == "" || txtbPassord.Text == "")
            {
                MessageBox.Show("Vennligst skriv inn brukernavn og passord");
                return;
            }
            bool stopwhilestatement = false;
            string AttemptedLogin = txtbBrukernavn.Text;
            string wholefilestring = "";
            string wholefile = File.ReadAllText("AllUsersAndPasswords.txt");
            FileStream fs1 = new FileStream("AllUsersAndPasswords.txt", FileMode.OpenOrCreate, FileAccess.Read);
            byte[] buffer1 = new byte[fs1.Length];
            int wholefileLength = fs1.Read(buffer1, 0, buffer1.Length);
            wholefilestring = Encoding.ASCII.GetString(buffer1, 0, wholefileLength);
            fs1.Flush();
            fs1.Close();
            int i = 0;
            while (!stopwhilestatement)
            {
                string[] CheckUsersOnly = wholefilestring.Split(',');
                if (CheckUsersOnly.Length > i)//hvis jeg ikke har denne, vil den si CheckUsersOnly(10) for eksempel, og det er ikke 10 "array biter" innider, og den får en error.
                {
                    if (CheckUsersOnly[i] == txtbBrukernavn.Text)
                    {
                        userline2 = i;
                        stopwhilestatement = true;
                        i = 0;
                    }
                }
                else if (CheckUsersOnly.Length < i)
                    stopwhilestatement = true;
                i = i + 2;
            }
            i = 0;

            UnameLine = wholefile.Split(',');
            if(UnameLine[userline2] == txtbBrukernavn.Text && UnameLine[userline2 + 1] == txtbPassord.Text)
            {
                string[] userline1 = UnameLine[userline2].Split(',');
                string useronly = userline1[0];
                MessageBox.Show("Du er nå logget inn, " + useronly);

                byte[] buffer = Encoding.ASCII.GetBytes(useronly);
                FileStream fs = new FileStream("CurrentLoggedInFile.txt", FileMode.Create,FileAccess.Write);
                fs.Write(buffer, 0, buffer.Length);

                fs.Flush();
                fs.Close();
            }
            else if (UnameLine[userline2] != txtbBrukernavn.Text || UnameLine[userline2 + 1] != txtbPassord.Text)
            {
                MessageBox.Show("Feil passord og/eller brukernavn");
            }
        }

        private void endrePassordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Form1.user1) && string.IsNullOrWhiteSpace(Form1.user2) && string.IsNullOrWhiteSpace(Form1.user3))
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
            //Legg til metode som skjekker om det ikke finnes noen brukere enda, hvis det ikke er noen brukere skal en msg box si "det finnes ingen brukere enda, vennligst lag noen"
                ChangeUserName ChangeUname = new ChangeUserName();
                DialogResult open = ChangeUname.ShowDialog();
        }

        private void nyBrukerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser CreateNewUser = new NewUser();
            DialogResult MakeNewUser = CreateNewUser.ShowDialog();
        }
        private void StartupMessage()
        {
            MessageBox.Show("Heisann og velkommen til mitt testprogram for brukerbehandling og brukeroppsett! All administrasjon for brukere foregår under *Opsett*. " +
                "Husk å ikke glemme passordet, du trenger jo selvfølgelig det gamle passordet for å endre brukernavn eller passord.");
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {

        }

        private void Enter_press(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Login.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(restartrequired)
            {
                Application.Exit();
            }
        }

        private void DeleteUsers_Click(object sender, EventArgs e)
        {
            DialogResult DeleteAreYouSure = MessageBox.Show("Dette vil slette alle brukere og all brukerdata som er lagret. Hvis du har spilt spill vil det lagrede spillet ditt" +
                " forsvinne med brukeren. Er du sikker?", "Slett alt, er du sikker?", MessageBoxButtons.YesNoCancel);
            if(DeleteAreYouSure == DialogResult.Yes)
            {
                DirectoryInfo Brukere = new DirectoryInfo("Brukere");
                foreach (FileInfo file in Brukere.GetFiles())
                    file.Delete();
                File.WriteAllText("AllUsersAndPasswords.txt", String.Empty);
                File.WriteAllText("CurrentLoggedInFile.txt", String.Empty);
            }
            else if (DeleteAreYouSure == DialogResult.No || DeleteAreYouSure == DialogResult.Cancel)
                MessageBox.Show("Greit! Ingen data ble slettet!", "Ingen bekymringer");
        }
    }
}
