using System;

namespace Assignment1
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
            int[,] numbers = new int[11, 11];
            //InitMatrix2D(numbers);
            //DisplayMatrix(numbers);
            InitMatrixLinear(numbers);
            DisplayMatrixWithCross(numbers);

            Console.ReadKey();
        }
        void InitMatrix2D(int[,] matrix)
        {
            int count = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] += count++;
                }                
            }
        }
        void DisplayMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(string.Format("{0,4} ",matrix[row, col]));
                }
                Console.WriteLine();
            }
        }
        void InitMatrixLinear(int[,] matrix)
        {
            int row = 0;
            int col = 0;

            for (int i = 1; i <= matrix.Length; i++)
            {
                matrix[row, col] = i;
                col++;

                if (col>=matrix.GetLength(1))
                {
                    row++;
                    col=0;
                }
            }
        }
        void DisplayMatrixWithCross(int[,] matrix)
        {         
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row + col == matrix.GetLength(1) - 1)
                    {                        
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    if(row == col)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }    
                    Console.Write(string.Format("{0,4} ", matrix[row, col]));
                    Console.ResetColor();                    
                }
                Console.WriteLine();
            }
        }
    }
}
