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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            onetimestuff();
            StartupMessage();
        }
        int whichuser = 0;
        int userline = 0;
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

        public static string StringCurrentUser = "";

        bool StopWhile = false;


        private void onetimestuff()
        {
            if(!Directory.Exists("Brukere"))
                Directory.CreateDirectory("Brukere");
            if(!File.Exists("AllUsersAndPasswords.txt"))
                File.Create("AllUsersAndPasswords.txt").Close();
            if (!File.Exists("CurrentUserLoggedIn.txt"))
                File.Create("CurrentUserLoggedIn.txt").Close();
            if (!File.Exists("RecentGames.txt"))
                File.Create("RecentGames.txt").Close();
        }

        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            Data1 ReadFile = new Data1();
            ReadFile.readFile();
            StopWhile = false;//This is fine because this only happends when the button is pressed, and the while statement does not run here.
            int i = 0;
            while (i < ReadFile.UserFileStringArray.Length && !StopWhile)
            {
                if(ReadFile.UserFileStringArray[i] == txtbBrukernavn.Text)
                {
                    ReadFile.UserLine = i;
                    StopWhile = true;
                }
                i = i + 2;
            }
            if(txtbBrukernavn.Text == "" || txtbPassord.Text == "")
            {
                MessageBox.Show("Vennligst skriv inn Brukernavn og Passord");
                return;
            }

            if (ReadFile.UserFileStringArray[ReadFile.UserLine] != txtbBrukernavn.Text || ReadFile.UserFileStringArray[ReadFile.UserLine + 1] != txtbPassord.Text)
            {
                MessageBox.Show("Feil brukernavn og/eller passord");
            }

            else if (ReadFile.UserFileStringArray[ReadFile.UserLine] == txtbBrukernavn.Text && ReadFile.UserFileStringArray[ReadFile.UserLine + 1] == txtbPassord.Text)
            {
                MessageBox.Show("Du er nå logget inn, " + ReadFile.UserFileStringArray[ReadFile.UserLine]);
                File.WriteAllText("CurrentUserLoggedIn.txt", txtbBrukernavn.Text);
                StringCurrentUser = txtbBrukernavn.Text;
                UserLoggedIn open = new UserLoggedIn();
                this.Hide();
                open.ShowDialog();
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
            if (string.IsNullOrWhiteSpace(Form1.user1) && string.IsNullOrWhiteSpace(Form1.user2) && string.IsNullOrWhiteSpace(Form1.user3))
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
            if(Data1.AlreadyBeenRun == 0)
            MessageBox.Show("Heisann og velkommen til mitt testprogram for brukerbehandling og brukeroppsett! All administrasjon for brukere foregår under *Opsett*. " +
                "Husk å ikke glemme passordet, du trenger jo selvfølgelig det gamle passordet for å endre brukernavn eller passord.");
            Data1.AlreadyBeenRun++;
        }

        private void Enter_press(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Login.PerformClick();
        }
        private void DeleteUsers_Click(object sender, EventArgs e)
        {

        }

        private void Status_Click(object sender, EventArgs e)
        {
            //im gna start documenting everything fucking properly from now on
            //Read "AllUsersAndPasswords.txt", display how many users are currently registered
            int NumberOfUsers = 0;
            FileStream fs = new FileStream("AllUsersAndPasswords.txt", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[10240];//10 KB incase there are registered alot of users. 
            int bufferlength = fs.Read(buffer, 0, buffer.Length);
            string AllUsersAndPasswordsString = Encoding.ASCII.GetString(buffer, 0, bufferlength);
            string[] AllUsersAndPasswordsArray = AllUsersAndPasswordsString.Split(',');
            for (int i = 0; AllUsersAndPasswordsArray.Length > i; i = i)
            {
                i = i + 2;
                NumberOfUsers++;
            }
            fs.Flush();
            fs.Close();
            int files = Directory.GetFiles("Brukere/","*.*",SearchOption.AllDirectories).Length;
            MessageBox.Show("Det er for øyeblikket registrert " + NumberOfUsers.ToString() + " Brukere, og det er totalt " + files.ToString() + " Lagringspunkter.");
        }
    }
}
