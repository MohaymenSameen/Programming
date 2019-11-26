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
            Position pos = new Position();
            int[,] chessboard = new int[8, 8];
            InitChessboard(chessboard);
            //PositionKnight(chessboard);
            PossibleKnightMoves(chessboard, PositionKnight(chessboard));
            DisplayChessboard(chessboard);

            Console.ReadKey();
        }
        void InitChessboard(int[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = 0;
                }
            }
        }
        void DisplayChessboard(int[,] chessboard)
        {
            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row,col]==0)
                    {
                        Console.Write(". ");
                    }
                    else if (chessboard[row,col]==1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("* ");
                        Console.ResetColor();
                    }                    
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("* ");
                        Console.ResetColor();
                    }                
                }
                Console.WriteLine();
            }
        }
        public Position PositionKnight(int[,] chessboard)
        {
            Random rnd = new Random();
            Position pos = new Position();
            pos.row = rnd.Next(0, chessboard.GetLength(0));
            pos.col = rnd.Next(0, chessboard.GetLength(1));

            chessboard[pos.col, pos.row] = 1;
            return pos;
        }
        void PossibleKnightMoves(int[,] chessboard, Position position)
        {
            int tgtX = 0;
            int tgtY = 0;

            int[] Xpos = { 1, 2, -2, -1, 2, 1, -1, -2 };
            int[] Ypos = { 2, 1, 1, 2, -1, -2, -2, -1 };

            for (int i = 0; i < Xpos.Length; i++)
            {
                tgtX = position.row + Xpos[i];
                tgtY = position.col + Ypos[i];

                if (tgtX >= 0 && tgtX < 8 && tgtY >= 0 && tgtY < 8)
                {
                    chessboard[tgtY, tgtX] = 2;
                }
            }
        }
    }
}
