using System;

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
            int[,] numbers = new int[8, 10];
            InitMatrixRandom(numbers, 1, 100);
            DisplayMatrix(numbers);

            Console.WriteLine();

            Console.Write("Enter a number (to search for): ");
            int number = int.Parse(Console.ReadLine());            
            SearchNumber(numbers, number);
            Console.WriteLine();
            SearchNumberBackwards(numbers, number);
            

            Console.ReadKey();
        }
        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random rnd = new Random();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rnd.Next(min, max);
                }
            }
        }
        void DisplayMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(string.Format("{0,4} ", matrix[row, col]));
                }
                Console.WriteLine();
            }
        }
        public Position SearchNumber(int[,] matrix, int number)
        {
            Position pos = new Position();
            bool found = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {                    
                    if (number == matrix[row,col])
                    {
                        pos.row = row;
                        pos.col = col;
                        Console.Write("Number {0} is found at position [{1},{2}] (first)",number,pos.row, pos.col);

                        found = true;
                        break;                        
                    }
                }
                if (found)
                {
                    break;
                } 
            }
            return pos;
        }
        public Position SearchNumberBackwards(int[,] matrix, int number)
        {
            Position pos = new Position();
            bool found = false;
            for (int row = matrix.GetLength(0)-1; row >= 0; row--)
            {
                for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                {
                    if (number == matrix[row,col])
                    {
                        pos.row = row;
                        pos.col = col;
                        Console.Write("Number {0} is found at position [{1},{2}] (last)", number, pos.row, pos.col);
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            return pos;
        }
    }
}
