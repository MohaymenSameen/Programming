using System;
using System.Collections.Generic;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Start();
        }
        void Start()
        {
            HangmanGame hangman = new HangmanGame();
            List<string> words = ListOfWords();
            hangman.Init(SelectWord(words));         
            bool win = PlayHangman(hangman); 
            Console.WriteLine();
            if (win)
            {
                Console.WriteLine("You have guessed the word!!!");
            }
            else
            {
                Console.WriteLine("You lost");
            }
            Console.ReadKey();
        }
        public List<string> ListOfWords()
        {
            List<string> words = new List<string>();
            words.Add("last");
            words.Add("afford");
            words.Add("excited");
            words.Add("quarter");
            words.Add("wall");
            words.Add("order");
            words.Add("brush");
            words.Add("manage");
            words.Add("terrific");
            words.Add("highfalutin");
            words.Add("refuse");
            words.Add("flock");
            words.Add("growth");
            words.Add("camera");
            words.Add("dear");
            words.Add("saw");
            words.Add("imminent");
            words.Add("quarrelsome");
            return words;
        }
        public string SelectWord(List<string> words)
        {
            Random rnd = new Random();
            string randomword = "";            
            randomword = words[rnd.Next(0,words.Count)];            
            return randomword;
        }
        public bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            int attempts = 8;
            Console.Write("The Secret Word is: ");
            DisplayWord(hangman.secretWord);
            Console.WriteLine();
            Console.Write("The Guessed Word is: ");
            DisplayWord(hangman.guessedWord);
            Console.WriteLine();

            while (attempts>0 && !hangman.isGuessed())
            {
                char letter = ReadLetter(enteredLetters);
                enteredLetters.Add(letter);
                hangman.GuessLetter(letter);                
                Console.Write("Entered letters: ");
                DisplayLetters(enteredLetters);
                Console.WriteLine("   {0} Attempts left.", attempts);
                Console.WriteLine();
                DisplayWord(hangman.guessedWord);
                Console.WriteLine();
                if (!hangman.GuessLetter(letter))
                {
                    attempts--;
                }               
            }
            if (hangman.isGuessed())
            {
                return true;
            }
            return false;
        }
        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write("{0} ",c);               
            }
        }
        void DisplayLetters(List<char> letters)
        {
            foreach (char c in letters)
            {
                Console.Write("{0} ", c);                
            }
        }
        public char ReadLetter(List<char> blacklistLetters)
        {            
            char letter = 'a';
            bool doescontain = true;
            while (doescontain)
            {
                Console.Write("Enter a letter: ");
                letter = char.Parse(Console.ReadLine());               
                doescontain = blacklistLetters.Contains(letter);
            }
            return letter;
        }
    }
}
