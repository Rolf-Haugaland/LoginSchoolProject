using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Values
    {
        //NewUserCreation
        public static int NewUserNumber = 1;


        //String som er brukernavnene og passordene til brukerene
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

        public static bool FirstStart = true;


        /// <summary>
        /// BondesjakkSpill
        /// </summary>
        //Boolean som skal skjekke om den skal laste inn user data. Altså X og O wins osv. Denne blir satt til true når brukeren logger ut. 
        public static bool LoadValues = false;
        //Boolean som bestemmer turen
        public static bool tur = true;
        //Boolean som sier om noen har vunnet
        public static bool DetErEnVinner = false;
        public static int XWins = 0;
        public static int OWins = 0;
        public static int draw = 0;
        public static int turncounter = 0;
        public static string vinner;

        //User1 Game
        public static bool User1DetErEnVinner = false;
        public static int User1XWins = 0;
        public static int User1OWins = 0;
        public static int User1draw = 0;
        public static int User1turncounter = 0;
        public static string User1vinner;

        //User2 Game
        public static bool User2DetErEnVinner = false;
        public static int User2XWins = 0;
        public static int User2OWins = 0;
        public static int User2draw = 0;
        public static int User2turncounter = 0;
        public static string User2vinner;

        //User3 Game
        public static bool User3DetErEnVinner = false;
        public static int User3XWins = 0;
        public static int User3OWins = 0;
        public static int User3draw = 0;
        public static int User3turncounter = 0;
        public static string User3vinner;

        /// <summary>
        /// Hangman
        /// </summary>

        //WinCounter and LossCounter for each spesific game
        public static int wincounter = 0;
        public static int losecounter = 0;
        public static int TotalGuesses = 0;

        public static string LetterAlreadyGuessed = "";

        //to create random word
        public static string[] text = System.IO.File.ReadAllLines(@"ord.txt");
        public static Random tilfeldigOrd = new Random();

        //User1 Game
        public static int User1WinCounter = 0;
        public static int User1LoseCounter = 0;
        public static int User1CorrectGuess = 0;
        public static int User1WrongGuess = 0;
        public static int User1TotalGuesses = 0;
        public static string User1blankDisplay = "";
        public static string User1Word = "";
        public static string User1LetterAlreadyGuessed = "";
        public static bool User1DisableButtons = false;

        //User2 Game
        public static int User2WinCounter = 0;
        public static int User2LoseCounter = 0;
        public static int User2CorrectGuess = 0;
        public static int User2WrongGuess = 0;
        public static int User2TotalGuesses = 0;
        public static string User2blankDisplay = "";
        public static string User2Word = "";
        public static string User2LetterAlreadyGuessed = "";
        public static bool User2DisableButtons = false;

        //User3 Game
        public static int User3WinCounter = 0;
        public static int User3LoseCounter = 0;
        public static int User3CorrectGuess = 0;
        public static int User3WrongGuess = 0;
        public static int User3TotalGuesses = 0;
        public static string User3blankDisplay = "";
        public static string User3Word = "";
        public static string User3LetterAlreadyGuessed = "";
        public static bool User3DisableButtons = false;
    }
}
