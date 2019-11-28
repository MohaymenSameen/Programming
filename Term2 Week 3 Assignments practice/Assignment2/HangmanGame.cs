using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string secretWord)
        {
            this.secretWord = secretWord;
            for (int i = 0; i < secretWord.Length; i++)
            {
                guessedWord += ".";
            }
        }
        public bool GuessLetter(char letter)
        {           
            bool doescontainsLetter = false;
            if (secretWord.Contains(letter))
            {
                doescontainsLetter = true;

                string Guess = "";

                for (int i = 0; i < guessedWord.Length; i++)
                {

                    if (secretWord[i] == letter)
                    {
                        Guess += letter;
                    }
                    else
                    {
                        Guess += guessedWord[i];
                    }
                }
                guessedWord = Guess;
            }
            return doescontainsLetter;            
        }
        public bool isGuessed()
        {
            if (secretWord == guessedWord)
            {
                return true;
            }
            return false;
        }
    }
}
