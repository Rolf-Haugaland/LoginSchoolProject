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
    public partial class LastInnSpill : Form
    {
        public LastInnSpill()
        {
            InitializeComponent();
            Changelbl();
        }

        string AllRecentGames = "";

        int Replaceint = 0;

        //Checks if the "recentGames" already contains the current user logged in. If it does 
        bool DontAddToRecentGames = false;

        private void Changelbl()
        {
            if(Hangman.SaveOrLoadFunction == "Load")
            {
                lblWhichGame.Text = "Du har " + Hangman.TotSaves.ToString() + " spill du kan laste inn. Skriv " + Hangman.TotSaves.ToString() + " for ditt sist spilte spill, eller 1" +
    " for å laste inn det eldste spillet ditt";
            }
            else if(Hangman.SaveOrLoadFunction == "Save")
            {
                txtb1.Text = Hangman.TotSaves.ToString();
                lblWhichGame.Text = "Du har " + Hangman.TotSaves.ToString() + " spill lagret. Skriv inn 1 i teksboksen for å erstatte det eldste spillet, eller " + Hangman.TotSaves.ToString()
                + " for ditt nyeste spill";
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if(Hangman.SaveOrLoadFunction == "Load")
            {
                try
                {
                    if (txtb1.Text != "")
                    {
                        Hangman.userSaveFilePath = "Brukere/" + Hangman.currentuser + "/SaveFile" + txtb1.Text + ".txt";
                        FileStream checkifvalid = new FileStream(Hangman.userSaveFilePath, FileMode.Open, FileAccess.Read);
                        checkifvalid.Flush();
                        checkifvalid.Close();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Vennligst skriv inn tall i tekstboksen, ingen bokstaver eller mellomrom");
                }
            }
            else if(Hangman.SaveOrLoadFunction == "Save")
            {
                if (File.Exists("Brukere/" + Hangman.currentuser + "/SaveFile" + txtb1.Text + ".txt") && Convert.ToInt16(txtb1.Text) < 100)
                {
                    Hangman.FileNumberAlreadySet = true;
                    Hangman.FileNumber = Convert.ToInt16(txtb1.Text);
                    MessageBox.Show("Greit! Lagringspunkt nummer " + txtb1.Text + " er satt til det spillet du nettop holdt på med. Husk å skrive inn dette lagringspunk tallet " +
                        "når du vil laste inn dette spillet igjen");
                    //Legger til filen Recent.txt, brukerens most recent saved game

                    FileStream fs1 = new FileStream("RecentGames.txt", FileMode.Open, FileAccess.Read,FileShare.ReadWrite);
                    byte[] buffer1 = new byte[1024];
                    int fs1Length = fs1.Read(buffer1, 0, buffer1.Length);
                    AllRecentGames = Encoding.ASCII.GetString(buffer1, 0, fs1Length);
                    fs1.Flush();
                    fs1.Close();

                    string[] ArrayAllRecentGames = AllRecentGames.Split(':', ',');
                    //#2 If a user already has "a most recent game" it wont add another to the line, it will remove that users "most recent game" from the 
                    //recent games file. And the type their input in again
                    //Removes all white space from ArrayAllRecentGames
                    for (int ia = 0; ArrayAllRecentGames.Length > ia; ia++)
                    {
                        ArrayAllRecentGames[ia] = ArrayAllRecentGames[ia].Trim();
                    }
                    //Sets intiget to replace intiger
                    for (int i = 0; ArrayAllRecentGames.Length > i; i++)
                    {
                        if (ArrayAllRecentGames[i] == Hangman.currentuser)
                            Replaceint = Convert.ToInt16(ArrayAllRecentGames[i + 2]);
                    }
                        
                    if (AllRecentGames.Contains(Hangman.currentuser))
                    {
                        AllRecentGames = AllRecentGames.Replace(Hangman.currentuser + ", most recent game: " + Replaceint.ToString() + ",\r\n", string.Empty);
                    }
                    //#2 end
                    ContinueWork();
                }
                else if (Convert.ToInt16(txtb1.Text) > 99)
                    MessageBox.Show("Kan ikke ha flere enn 100 lagringspunkter, vennligst skriv inn ett mindre tall");
            }
        }

        public void SaveWithoutPrompt()
        {
            Hangman.FileNumberAlreadySet = true;
            Hangman.FileNumber = Convert.ToInt16(txtb1.Text);
            //Legger til filen Recent.txt, brukerens most recent saved game

            FileStream fs1 = new FileStream("RecentGames.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            byte[] buffer1 = new byte[1024];
            int fs1Length = fs1.Read(buffer1, 0, buffer1.Length);
            AllRecentGames = Encoding.ASCII.GetString(buffer1, 0, fs1Length);
            fs1.Flush();
            fs1.Close();

            string[] ArrayAllRecentGames = AllRecentGames.Split(':', ',');
            //#2 If a user already has "a most recent game" it wont add another to the line, it will remove that users "most recent game" from the 
            //recent games file. And the type their input in again
            //Removes all white space from ArrayAllRecentGames
            for (int ia = 0; ArrayAllRecentGames.Length > ia; ia++)
            {
                ArrayAllRecentGames[ia] = ArrayAllRecentGames[ia].Trim();
            }
            //Sets intiget to replace intiger
            for (int i = 0; ArrayAllRecentGames.Length > i; i++)
            {
                if (ArrayAllRecentGames[i] == Hangman.currentuser)
                    Replaceint = Convert.ToInt16(ArrayAllRecentGames[i + 2]);
            }

            if (AllRecentGames.Contains(Hangman.currentuser))
            {
                AllRecentGames = AllRecentGames.Replace(Hangman.currentuser + ", most recent game: " + Replaceint.ToString() + ",\r\n", string.Empty);
            }
            //#2 end

            string RecentSaveFile = Hangman.currentuser + ", most recent game: " + txtb1.Text + ",\r\n";
            FileStream fs = new FileStream("RecentGames.txt", FileMode.Create, FileAccess.Write);
            byte[] buffer = new byte[AllRecentGames.Length + RecentSaveFile.Length];
            buffer = Encoding.ASCII.GetBytes(AllRecentGames + RecentSaveFile);
            fs.Write(buffer, 0, buffer.Length);
            fs.Flush();
            fs.Close();
        }

        private void ContinueWork()
        {
            string RecentSaveFile = Hangman.currentuser + ", most recent game: " + txtb1.Text + ",\r\n";
            FileStream fs = new FileStream("RecentGames.txt", FileMode.Create, FileAccess.Write);
            byte[] buffer = new byte[AllRecentGames.Length + RecentSaveFile.Length];
            buffer = Encoding.ASCII.GetBytes(AllRecentGames + RecentSaveFile);
            fs.Write(buffer, 0, buffer.Length);
            fs.Flush();
            fs.Close();
            this.Close();
        }
    }
}
