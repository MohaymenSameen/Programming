using System;

namespace Assignment4
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
            YahtzeeGame yahtzeeGame = new YahtzeeGame();
            yahtzeeGame.Init();
            PlayYahtzee(yahtzeeGame);

            Console.ReadKey();
        }
        void PlayYahtzee(YahtzeeGame game)
        {
            int nrOfAttempts = 0;
            do
            {
                game.Throw(); // throw all dices 
                game.DisplayValues();
                Console.WriteLine();// display the thrown
                nrOfAttempts++;
            } while (!game.Yahtzee());
            Console.WriteLine("Number of attempts needed (Yahtzee): {0}", nrOfAttempts);
        }
    }
}
