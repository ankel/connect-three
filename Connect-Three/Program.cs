using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect_Three
{
    class Program
    {
        const char Side1 = 'a';
        const char Side2 = 'b';
        
        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "g")
            {
                Board.GenerateDuplets();
                Board.GenerateTriplets();
                return;
            }

            DateTime start = DateTime.Now;

            Board gameBoard = new Board();
            bool drawnGame = false;
            bool wonGame = false;
            char winner = 'c';
            while (true)
            {
                MakeAMove(Side1, gameBoard);
                CheckWinLoseDraw(gameBoard, ref drawnGame, ref wonGame, ref winner);
                if (wonGame || drawnGame)
                {
                    break;
                }

                MakeAMove(Side2, gameBoard);
                CheckWinLoseDraw(gameBoard, ref drawnGame, ref wonGame, ref winner);
                if (wonGame || drawnGame)
                {
                    break;
                }
            }

            Console.WriteLine("Run time: " + (DateTime.Now - start));

            if (drawnGame)
            {
                Console.WriteLine("Drawn game!");
                Console.WriteLine(gameBoard.ToString());
                Console.ReadLine();
                return;
            }

            if (wonGame)
            {
                Console.WriteLine(winner + " has won!");
                Console.WriteLine(gameBoard.ToString());
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Impossible");
        }

        private static void CheckWinLoseDraw(Board gameBoard, ref bool drawnGame, ref bool wonGame, ref char winner)
        {
            if (gameBoard.IsFull())
            {
                drawnGame = true;
            }
            switch (gameBoard.Score(Side1, false))
            {
                case Board.Win:
                    wonGame = true;
                    winner = Side1;
                    break;
                case Board.Lose:
                    wonGame = true;
                    winner = Side2;
                    break;
            }
        }

        private static void MakeAMove(char side, Board gameBoard)
        {
            int col = MakeAMoveHelper(side, side, gameBoard);
            //while (gameBoard.IsFull(col))
            //{
            //    ++col;
            //}
            gameBoard.Drop(col, side);
            Console.WriteLine("{0} made a move at {1}. Current board size is {2}.", side, col, gameBoard.cnt);
            //System.Diagnostics.Debug.WriteLine(gameBoard.ToString());
        }

        private static int MakeAMoveHelper(char side, char playAs, Board gameBoard)
        {
            int score = gameBoard.Score(side, false);
            if (score != 0)
            {
                return score;
            }

            if (gameBoard.IsFull())
            {
                return 0;
            }

            List<int> scores = new List<int>(3);
            for (int i = 0; i < 3; ++i)
            {
                scores.Add(Board.Lose);
            }
            for (int i = 0; i < 3; ++i)
            {
                if (!gameBoard.IsFull(i))
                {
                    gameBoard.Drop(i, side);
                    scores[i] = (-(MakeAMoveHelper(side, side == Side1 ? Side2 : Side1, gameBoard)));
                    gameBoard.Pop(i);
                }
            }
            return scores.IndexOf(scores.Max());
        }
    }
}
