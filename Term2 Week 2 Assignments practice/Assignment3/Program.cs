using System;

namespace Assignment3
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
            RegularCandies[,] playingfield = new RegularCandies[9, 9];
            InitCandies(playingfield);
            DisplayCandies(playingfield);

            if (ScoreRowPresent(playingfield))
            {
                Console.WriteLine("row score!");
            }
            else
            {
                Console.WriteLine("no row score");
            }

            if (ScoreColumnPresent(playingfield))
            {
                Console.WriteLine("column score!");
            }
            else
            {
                Console.WriteLine("no column score!");
            }

            Console.ReadKey();
        }
        void InitCandies(RegularCandies[,] matrix)
        {
            Random rnd = new Random();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (RegularCandies)rnd.Next(0, 7);
                }
            }
        }
        void DisplayCandies(RegularCandies[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == (RegularCandies)0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if(matrix[row, col] == (RegularCandies)1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if(matrix[row, col] == (RegularCandies)2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (matrix[row, col] == (RegularCandies)3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (matrix[row, col] == (RegularCandies)4)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
        public bool ScoreRowPresent(RegularCandies[,] matrix)
        {
            RegularCandies regularCandies = new RegularCandies();
            int count = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (regularCandies==matrix[row,col])
                    {
                        count++;
                        regularCandies = matrix[row, col];
                    }
                    else
                    {
                        count = 1;                        
                    }

                    if (count>=3)
                    {
                        return true;
                    }
                    
                }                
            }
            return false;
        }     
        public bool ScoreColumnPresent(RegularCandies[,] matrix)
        {
            RegularCandies regularCandies = new RegularCandies();
            int count = 1;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (regularCandies == matrix[row, col])
                    {
                        count++;
                        regularCandies = matrix[row, col];
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count >= 3)
                    {
                        return true;
                    }                    
                }
            }
            return false;
        }        
    }
}
