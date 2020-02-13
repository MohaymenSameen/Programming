using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1._2_Week6
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
            ChessPiece[,] chessboard = new ChessPiece[8, 8];
            InitChessboard(chessboard);
            DisplayChessboard(chessboard);
            PlayChess(chessboard);            
        }
        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    chessboard[i, j] = null;
                }
                PutChessPieces(chessboard);
            }

        }
        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            Console.Write("    A  B  C  D  E  F  G  H");
            Console.WriteLine();

            int count = 0;
            
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {     
                
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {

                    if (j==0)
                    {
                        count++;
                        Console.Write("{0}  ", count);
                        
                    }
                    if ((i+j) % 2==0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;                        
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;                       
                    }

                    DisplayChessPiece(chessboard[i, j]);
                    Console.ResetColor();


                }
                Console.WriteLine();
            }       
            
        }
        void PutChessPieces(ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = { ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.King, ChessPieceType.Queen, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };

            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if (i == 1 || i == 6)
                    {
                        chessboard[i, j] = new ChessPiece();
                        chessboard[i, j].Type = ChessPieceType.Pawn;
                    }
                    else if (i == 0 || i == 7)
                    {
                        chessboard[i, j] = new ChessPiece();
                        chessboard[i, j].Type = order[j];
                    }


                    if (i == 0 || i == 1)
                    {
                        chessboard[i, j].Color = ChessPieceColor.White;
                    }
                    else if(i==6 || i==7)
                    {
                        chessboard[i, j].Color = ChessPieceColor.Black;
                    }

                }
            }
        }
        void DisplayChessPiece(ChessPiece chessPiece)
        {
            if (chessPiece == null)
            {
                Console.Write("   ");
                return;
            }


            if (chessPiece.Color == ChessPieceColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (chessPiece.Type == ChessPieceType.Pawn)
            {
                Console.Write(" p ");
            }
            else if (chessPiece.Type == ChessPieceType.Rook)
            {
                Console.Write(" r ");
            }
            else if (chessPiece.Type == ChessPieceType.Knight)
            {
                Console.Write(" k ");
            }
            else if (chessPiece.Type == ChessPieceType.Bishop)
            {
                Console.Write(" b ");
            }
            else if (chessPiece.Type == ChessPieceType.King)
            {
                Console.Write(" K ");
            }
            else
            {
                Console.Write(" Q ");
            }

            Console.ResetColor();
        }
        Position ReadPosition(string question)
        {
            Console.Write(question);

            string userPos = Console.ReadLine();

            int column1 = userPos[0] - 'A';
            int row1 = int.Parse(userPos[1].ToString()) - 1;

            Position pos = new Position();

            if (row1 >=8 && column1 >=8)
            {
                Console.WriteLine("Invalid Position! ");
            }
            else
            {
                pos.column = column1;
                pos.row = row1;
            }
            return pos;                      
        }
        void PlayChess(ChessPiece[,] chessboard)
        {
            int value = 4;
            while (value!=0)
            {
                try
                {
                    Position from = ReadPosition("The Current Position Of The ChessPiece: ");
                    Position to = ReadPosition("To the Position the ChessPiece Moves: ");
                    CheckMove(chessboard, from, to);
                }
                catch
                {
                    Console.WriteLine("Invalid Position! ");
                }

                DisplayChessboard(chessboard);
            }
           
        }
        void DoMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            chessboard[to.row, to.column] = chessboard[from.row, from.column];
            chessboard[from.row, from.column] = null;
        }
        void CheckMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            if (chessboard[from.row,from.column]==null)
            {
                Console.WriteLine("no chess piece at from - position");
                return;
            }

            if (chessboard[to.row,to.column]!=null)
            {
                Console.WriteLine("Piece existing at position");
                return;
            }

            ChessPiece chess = chessboard[from.row, from.column];
            bool Moves = ValidMove(chess, from, to);

            if (Moves)
            {
                DoMove(chessboard, from, to);
            }
            else
            {
                Console.WriteLine("Invalid move for chess piece {0}", chess.Type);
            }
        }
        bool ValidMove(ChessPiece chessPiece, Position from, Position to)
        {
            int hor = Math.Abs(from.column - to.column);
            int ver = Math.Abs(from.row - to.row);

            if (hor == 0 && ver == 0)
            {
                return false;
            }
            else 
            {
                switch (chessPiece.Type)
                {
                    case ChessPieceType.Pawn:
                        if (hor ==0 &&ver==1)
                        {
                            return true;
                        }
                        break;
                    case ChessPieceType.Rook:
                        if (hor*ver==0)
                        {
                            return true;
                        }
                        break;
                    case ChessPieceType.Knight:
                        if (hor * ver ==2)
                        {
                            return true;
                        }
                        break;
                    case ChessPieceType.Bishop:
                        if (hor==ver)
                        {
                            return true;
                        }
                        break;
                    case ChessPieceType.King:
                        if ((hor ==1 || ver==1) || (hor==1 && ver==1))
                        {
                            return true;
                        }
                        break;
                    case ChessPieceType.Queen:
                        if ((hor * ver == 0) || (hor==ver))
                        {
                            return true;
                        }
                        break;                   
                }
                return false;
            }

        }
    }
}
