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
    public partial class Hangman : Form
    {
        public Hangman()
        {
            InitializeComponent();
            LoadWords();
            FirstGame();
        }
        //Åpne forgje vindu etter dette ble lukker, blir brukt i Form_Closing event
        UserLoggedIn open = new UserLoggedIn();

        //This makes sure that the save function wont change "FileNumber" to save to, if the user has spesified his/her own FileNumber to overwrite
        public static bool FileNumberAlreadySet = false;

        bool Load1Game = false;

        //Dette sier hvilke fil som skal skrives til. Altså Savefile1/2/3.txt osv
        public static int FileNumber = 0;

        public static string SaveOrLoadFunction = "";

        //Sier om knappene er enabled/Disabled og dette brukes i save/load funksjonene
        string buttonstate = "";

        public static int TotSaves = 0;

        //Int som sier hvilke savefile som skal lastes inn, hvis brukeren har valgt "most recent played game"
        int CurrentSaveFile = 0;

        public static string userSaveFilePath = "";
        public static string currentuser = "";

        string userloggedin = "";
        string userloggedin1 = "";

        //intigers
        int TotalGuesses = 0;
        int CorrectGuess = 0;
        int wrongguess = 0;


        //String which is displayed to player
        StringBuilder blank = new StringBuilder();

        //to create random word
        string[] words = { };
        string word = "";


        string LetterAlreadyGuessed = "";
        int wincounter = 0;
        int losecounter = 0;

        private void LoadWords()
        {
            words = File.ReadAllLines("ord.txt");
            Random rnd = new Random();
            int randomInt = rnd.Next(0, words.Length);
            word = words[randomInt].ToUpper();
        }

        public void FirstGame()
        {
            FileStream getuser = new FileStream("CurrentUserLoggedIn.txt", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024];
            int getFileLength = getuser.Read(buffer, 0, buffer.Length);
            currentuser = Encoding.ASCII.GetString(buffer,0,getFileLength);
            userSaveFilePath = "Brukere/" + currentuser + "/SaveFile1.txt";
            getuser.Flush();
            getuser.Close();

            TotSaves = Directory.GetFiles("Brukere/" + currentuser, "*.*", SearchOption.TopDirectoryOnly).Length;
            if(TotSaves == 1)
            {
                DialogResult LoadGame = MessageBox.Show("Du har 1 lagret spill fra før av, vil du laste inn dette spillet?", "Last inn spill?",MessageBoxButtons.YesNo);
                if(LoadGame == DialogResult.Yes)
                {
                    Load1Game = true;
                }
            }
            if(TotSaves > 1)
            {
                DialogResult LoadGame = MessageBox.Show("Det ser ut til at du allerede har " + TotSaves.ToString() + " Lagrede spill, vil du laste inn did sist " +
                "spilte spill? Trykk nei for å selv velge hvilket spill du vil laste inn, trykk avbryt for å avbryte laste prosessen og begynne ett nytt spill.", 
                "Laste inn spill?", MessageBoxButtons.YesNoCancel);
                if(LoadGame == DialogResult.Yes)
                {
                    FileStream fs = new FileStream("RecentGames.txt", FileMode.Open, FileAccess.Read);
                    byte[] buffer2 = new byte[10240];
                    int lengthing = fs.Read(buffer2, 0, buffer2.Length);
                    string FindRecentGames = Encoding.ASCII.GetString(buffer2, 0, lengthing);
                    fs.Flush();
                    fs.Close();
                    string[] FindRecentGamesArray = FindRecentGames.Split(',', ':');
                    for(int i = 0; FindRecentGamesArray.Length > i; i++)
                    {
                        if(FindRecentGamesArray[i].Contains(currentuser))
                        {
                            FindRecentGamesArray[i + 2] = FindRecentGamesArray[i + 2].Trim();
                            CurrentSaveFile = Convert.ToInt16(FindRecentGamesArray[i + 2]);
                            userSaveFilePath = "Brukere/" + currentuser + "/SaveFile" + CurrentSaveFile + ".txt";
                        }
                    }
                    Load1Game = true;
                }
                else if(LoadGame == DialogResult.No)
                {
                    SaveOrLoadFunction = "Load";
                    Load1Game = true;
                    LastInnSpill open = new LastInnSpill();
                    open.ShowDialog();
                }
            }
            if(Load1Game)
            {
                FileStream fs = new FileStream(userSaveFilePath, FileMode.Open, FileAccess.Read);
                getFileLength = fs.Read(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
                string saveFileString = Encoding.ASCII.GetString(buffer, 0, getFileLength);
                string nowhitespacesave = string.Join("", saveFileString.Split((string[])null, StringSplitOptions.RemoveEmptyEntries));
                char[] dilimiters = { ',', ':' };
                string[] saveFile = nowhitespacesave.Split(dilimiters);
                for (int i = 0; saveFile.Length > i; i++)
                {
                    if (saveFile[i].Contains("Vinnteller"))
                        wincounter = Convert.ToInt16(saveFile[i + 1]);
                    else if (saveFile[i].Contains("Tapteller"))
                        losecounter = Convert.ToInt16(saveFile[i + 1]);
                    else if (saveFile[i].Contains("Ord"))
                        word = saveFile[i + 1];
                    else if (saveFile[i].Contains("Totalt"))
                        TotalGuesses = Convert.ToInt16(saveFile[i + 1]);
                    else if (saveFile[i].Contains("Bokst"))
                        LetterAlreadyGuessed = saveFile[i + 1];
                    else if (saveFile[i].Contains("Korrektegjett"))
                        CorrectGuess = Convert.ToInt16(saveFile[i + 1]);
                    else if (saveFile[i].Contains("Feilgjett"))
                        wrongguess = Convert.ToInt16(saveFile[i + 1]);
                    else if (saveFile[i].Contains("VisesTilSpiller"))
                    {
                        blank.Clear();
                        blank.Append(saveFile[i + 1]);
                    }
                    else if(saveFile[i].Contains("KnapperEnabled"))
                    {
                        if(saveFile[i + 1] == "Disabled")
                            foreach(Control c in Controls)
                            {
                                if (c.GetType() == typeof(Button))
                                    c.Enabled = false;
                            }
                    }
                }
                lbl_Display.Text = blank.ToString();
                lbl_Defeats.Text = "Tapt: " + losecounter.ToString();
                lbl_GuessedLetters.Text = "Gjettede bokstaver: " + LetterAlreadyGuessed;
                lbl_Wins.Text = "Vunnet: " + wincounter.ToString();
                lbl_TotalGuesses.Text = "Gjett: " + TotalGuesses.ToString();
            }
            if(!Load1Game)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    blank.Append("_");
                }
                lbl_Display.Text = blank.ToString();
                MessageBox.Show("Velkommen til hangman! Dette spillet er akuratt som hangman, der du gjetter ved å trykke på bokstavene, itilleg så er det på engelsk." +
                    " Det blir tilfeldig valgt ett av flere hundre ord på engelsk med 4 bokstaver eller mer, lykke til!");
            }
        }

        private void btn_GjettBokstav(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            //Display to player
            if (word.Contains(b.Text) && (CorrectGuess != word.Length) && !blank.ToString().Contains(b.Text))
            {
                lbl_GuessMessage.Text = b.Text + " var rett gjettet!";
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == b.Text[0])
                    {
                        CorrectGuess++;
                        blank[i] = b.Text[0];
                    }
                }
                lbl_Display.Text = blank.ToString();
                TotalGuesses++;
                lbl_TotalGuesses.Text = "Gjett: " + TotalGuesses.ToString();
            }
            else if (LetterAlreadyGuessed.Contains(b.Text))
                lbl_GuessMessage.Text = "Du har allerede gjettet " + b.Text;
            else if (!word.Contains(b.Text))
            {
                TotalGuesses++;
                lbl_TotalGuesses.Text = "Gjett: " + TotalGuesses.ToString();
                lbl_GuessMessage.Text = b.Text + " var feil, prøv igjen!";
                wrongguess++;
            }
            if (LetterAlreadyGuessed.Contains(b.Text))
            {

            }
            else if (!LetterAlreadyGuessed.Contains(b.Text))
                LetterAlreadyGuessed += b.Text;
            lbl_GuessedLetters.Text = "Gjettede bokstaver: " + LetterAlreadyGuessed;

            //Winner
            if (CorrectGuess == word.Length)
            {
                foreach (Control c in Controls)
                    if (c.GetType() == typeof(Button))
                    {
                        c.Enabled = false;
                    }
                wincounter++;
                lbl_GuessMessage.Text = "Du vant!";
                lbl_Wins.Text = "Vunnet: " + wincounter.ToString();
                DialogResult NewGame = MessageBox.Show("Gratulerer du vant! Bra jobbet. Vil du starte nytt spill?", "Du vant, nytt spill?", MessageBoxButtons.YesNo);
                if (NewGame == DialogResult.Yes)
                {
                    NyttSpill();
                }
                else if (NewGame == DialogResult.No)
                {
                    MessageBox.Show("Greit! Du kan starte nytt spill ved Fil>Nytt Spill");
                    CorrectGuess = 0;
                    wrongguess = 0;
                    TotalGuesses = 0;
                }
            }
            //Loser
            if (wrongguess == 10)
            {
                foreach (Control c in Controls)
                    if (c.GetType() == typeof(Button))
                    {
                        c.Enabled = false;
                    }
                losecounter++;
                lbl_GuessMessage.Text = b.Text + " var feil, du tapte";
                lbl_Defeats.Text = "Tapt: " + losecounter.ToString();
                DialogResult NewGame = MessageBox.Show("Du tapte! Bedre lykke neste gang. Vil du starte nytt spill?", "Tap", MessageBoxButtons.YesNo);
                if (NewGame == DialogResult.Yes)
                {
                    NyttSpill();
                }
                else if (NewGame == DialogResult.No)
                    MessageBox.Show("Greit! Du kan starte nytt spill ved Fil>Nytt Spill");
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult test = MessageBox.Show("Vil du lagre dette spillet?", "Lagre?", MessageBoxButtons.YesNoCancel);
            if (test == DialogResult.Yes)
            {
                int SavedFiles = Directory.GetFiles("Brukere/" + Hangman.currentuser, "*.*", SearchOption.TopDirectoryOnly).Length;
                if (SavedFiles > 0)
                {
                    DialogResult ErstatteLagringsFil = MessageBox.Show("Det ser ut til at du har " + SavedFiles.ToString() + " largringspunkter fra før. Vil du overskrive " +
    "eller lage nytt lagringspunkt? (Du vil bli spurt om hvilke du vil overskrive hvis det er flere enn ett). Ja for å overskrive og nei for å lage " +
    "nytt lagringspunkt", "Overskrive eller lage nytt largrinspubkt"
    , MessageBoxButtons.YesNoCancel);
                    if (ErstatteLagringsFil == DialogResult.Yes)
                    {
                        SaveOrLoadFunction = "Save";
                        LastInnSpill open1 = new LastInnSpill();
                        if (SavedFiles > 1)
                        {
                            open1.ShowDialog();
                        }
                        //If the user has 1 file save, it wont open the "LastInnSpill" to let the user choose which file to overwrite, since there is only one.
                        else if (SavedFiles == 1)
                            open1.SaveWithoutPrompt();

                    }
                }
                if (button1.Enabled == false)
                {
                    buttonstate = "Disabled";
                }
                else if (button1.Enabled == true)
                {
                    buttonstate = "Enabled";
                }
                //Reads which user is currently logged in
                FileStream fs1 = new FileStream("CurrentUserLoggedIn.txt", FileMode.Open, FileAccess.Read);
                byte[] buffer2 = new byte[1024];
                int bytesread = fs1.Read(buffer2, 0, buffer2.Length);
                fs1.Flush();
                fs1.Close();
                userloggedin1 = Encoding.ASCII.GetString(buffer2, 0, bytesread);

                //Gets how many files there are in this directory, and adds 1 to it so that it saves to a new file
                if(!FileNumberAlreadySet)
                FileNumber = Directory.GetFiles("Brukere/" + userloggedin1, "*.*", SearchOption.TopDirectoryOnly).Length + 1;

                FileNumberAlreadySet = false;//I am resetting the boolean. It needs to be reset to always create a new SaveFile if the user has not said otherwise

                //Which file to write to
                string brukersave = "Brukere/" + userloggedin1 + "/SaveFile" + FileNumber + ".txt";

                FileStream fs = new FileStream(brukersave, FileMode.Create, FileAccess.Write);
                string[] everythingSaved = new string[9];
                everythingSaved[0] = "Vises Til Spiller: " + blank.ToString();
                everythingSaved[1] = "\r\n" + "Ord å gjette: " + word;
                everythingSaved[2] = "\r\n" + "Vinn teller: " + wincounter.ToString();
                everythingSaved[3] = "\r\n" + "Tap teller: " + losecounter.ToString();
                everythingSaved[4] = "\r\n" + "Totalt gjettede ord: " + TotalGuesses.ToString();
                everythingSaved[5] = "\r\n" + "Bokst. som allerede er gjettet: " + LetterAlreadyGuessed;
                everythingSaved[6] = "\r\n" + "Korrekte gjett: " + CorrectGuess.ToString();
                everythingSaved[7] = "\r\n" + "Feil gjett: " + wrongguess.ToString();
                everythingSaved[8] = "\r\n" + "Knapper Enabled/Disabled: " + buttonstate;
                string SeverythingSaved = string.Join(",", everythingSaved);
                byte[] buffer = new byte[SeverythingSaved.Length];
                buffer = Encoding.ASCII.GetBytes(SeverythingSaved);
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
                open.show();
            }
            else if(test == DialogResult.No)
                open.show();
            else if (test == DialogResult.Cancel)
            {
                MessageBox.Show("Ingen data ble lagret/overskrevet");
                e.Cancel = true;
            }
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            NyttSpill();
        }
        private void NyttSpill()
        {
            Random rnd = new Random();
            string[] tempwords = File.ReadAllLines("ord.txt");
            int randomint = rnd.Next(0, tempwords.Length);
            word = tempwords[randomint].ToUpper();
            while(word.Length < 4)
            {
                int a = rnd.Next(0, tempwords.Length);
                word = tempwords[a].ToUpper();
            }
            blank.Clear();
            for (int i = 0; i < word.Length; i++)
            {
                blank.Append("_");
            }
            lbl_Display.Text = blank.ToString();
            lbl_GuessMessage.Text = "";
            lbl_TotalGuesses.Text = "Gjett: ";
            lbl_GuessedLetters.Text = "Gjettede bokstaver: ";
            wrongguess = 0;
            CorrectGuess = 0;
            TotalGuesses = 0;
            LetterAlreadyGuessed = "";
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Enabled = true;
                }
            }
        }
    }
}
