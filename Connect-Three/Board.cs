using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Connect_Three
{
    class BoardOutOfSpace : Exception
    {
        public readonly int col;

        public BoardOutOfSpace() 
            : base()
        {
        }

        public BoardOutOfSpace(string str)
            : base(str)
        {
        }

        public BoardOutOfSpace(int col)
        {
            this.col = col;
        }
    }

    class FullBoard : Exception
    {
        public FullBoard()
            : base()
        {
        }

        public FullBoard(string str)
            : base(str)
        {
        }
    }

    class Board
    {
        public char[,] board;
        public static const char Empty = '.';
        public static const int Win = int.MaxValue / 2;
        public static const int Lose = -(int.MaxValue / 2);

        #region 2-in-a-row hard code
        public static Tuple<Point, Point>[] duplet = 
            {   new Tuple<Point, Point>(new Point(0,0), new Point(0,1)),
                new Tuple<Point, Point>(new Point(0,1), new Point(0,2)),
                new Tuple<Point, Point>(new Point(1,0), new Point(1,1)),
                new Tuple<Point, Point>(new Point(1,1), new Point(1,2)),
                new Tuple<Point, Point>(new Point(2,0), new Point(2,1)),
                new Tuple<Point, Point>(new Point(2,1), new Point(2,2)),
                new Tuple<Point, Point>(new Point(3,0), new Point(3,1)),
                new Tuple<Point, Point>(new Point(3,1), new Point(3,2)),

                new Tuple<Point, Point>(new Point(0,0), new Point(1,0)),
                new Tuple<Point, Point>(new Point(1,0), new Point(2,0)),
                new Tuple<Point, Point>(new Point(0,1), new Point(1,1)),
                new Tuple<Point, Point>(new Point(1,1), new Point(2,1)),
                new Tuple<Point, Point>(new Point(0,2), new Point(1,2)),
                new Tuple<Point, Point>(new Point(1,2), new Point(2,2)),
                new Tuple<Point, Point>(new Point(1,0), new Point(2,0)),
                new Tuple<Point, Point>(new Point(2,0), new Point(3,0)),
                new Tuple<Point, Point>(new Point(1,1), new Point(2,1)),
                new Tuple<Point, Point>(new Point(2,1), new Point(3,1)),
                new Tuple<Point, Point>(new Point(1,2), new Point(2,2)),
                new Tuple<Point, Point>(new Point(2,2), new Point(3,2)),

                new Tuple<Point, Point>(new Point(0,0), new Point(1,1)),
                new Tuple<Point, Point>(new Point(1,1), new Point(2,2)),
                new Tuple<Point, Point>(new Point(1,0), new Point(2,1)),
                new Tuple<Point, Point>(new Point(2,1), new Point(3,2)),

                new Tuple<Point, Point>(new Point(0,2), new Point(1,1)),
                new Tuple<Point, Point>(new Point(1,1), new Point(2,0)),
                new Tuple<Point, Point>(new Point(1,2), new Point(2,1)),
                new Tuple<Point, Point>(new Point(2,1), new Point(3,0)),
            };
        #endregion

        #region 3-in-a-row hard code
        public static Tuple<Point, Point, Point>[] triplet = 
            {   new Tuple<Point, Point, Point>(new Point(0,0), new Point(0,1), new Point(0,2)),
                new Tuple<Point, Point, Point>(new Point(1,0), new Point(1,1), new Point(1,2)),
                new Tuple<Point, Point, Point>(new Point(2,0), new Point(2,1), new Point(2,2)),
                new Tuple<Point, Point, Point>(new Point(3,0), new Point(3,1), new Point(3,2)),

                new Tuple<Point, Point, Point>(new Point(0,0), new Point(1,0), new Point(2,0)),
                new Tuple<Point, Point, Point>(new Point(0,1), new Point(1,1), new Point(2,1)),
                new Tuple<Point, Point, Point>(new Point(0,2), new Point(1,2), new Point(2,2)),
                new Tuple<Point, Point, Point>(new Point(1,0), new Point(2,0), new Point(3,0)),
                new Tuple<Point, Point, Point>(new Point(1,1), new Point(2,1), new Point(3,1)),
                new Tuple<Point, Point, Point>(new Point(1,2), new Point(2,2), new Point(3,2)),

                new Tuple<Point, Point, Point>(new Point(0,0), new Point(1,1), new Point(2,2)),
                new Tuple<Point, Point, Point>(new Point(1,0), new Point(2,1), new Point(3,2)),

                new Tuple<Point, Point, Point>(new Point(0,2), new Point(1,1), new Point(2,0)),
                new Tuple<Point, Point, Point>(new Point(1,2), new Point(2,1), new Point(3,0)),
            };
        #endregion

        #region Generate 2-in-a-row hardcode
        public static void GenerateDuplets()
        {
            int[,] board = new int[4, 3];

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i, j] == 0 && board[i, j + 1] == 0 && board[i, j + 2] == 0)
                        {
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i, j, i, j + 1));
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i, j + 1, i, j + 2));
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i, j] == 0 && board[i + 1, j] == 0 && board[i + 2, j] == 0)
                        {
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i, j, i + 1, j));
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i + 1, j, i + 2, j));
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i, j] == 0 && board[i + 1, j + 1] == 0 && board[i + 2, j + 2] == 0)
                        {
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i, j, i + 1, j + 1));
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i + 1, j + 1, i + 2, j + 2));
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i, j] == 0 && board[i + 1, j - 1] == 0 && board[i + 2, j - 2] == 0)
                        {
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i, j, i + 1, j - 1));
                            Console.WriteLine(String.Format("new Tuple<Point, Point>(new Point({0},{1}), new Point({2},{3})),", i + 1, j - 1, i + 2, j - 2));
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            Console.ReadLine();
        }
        #endregion

        #region Generate 3-in-a-row hardcode
        public static void GenerateTriplets()
        {
            int[,] board = new int[4, 3];

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i,j] == 0 && board[i,j+1] == 0 && board[i,j+2] == 0)
                            Console.WriteLine(String.Format("new Tuple<Point, Point, Point>(new Point({0},{1}), new Point({2},{3}), new Point({4},{5})),", i, j, i, j+1, i, j+2));
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i,j] == 0 && board[i+1,j] == 0 && board[i+2,j] == 0)
                            Console.WriteLine(String.Format("new Tuple<Point, Point, Point>(new Point({0},{1}), new Point({2},{3}), new Point({4},{5})),", i, j, i+1, j, i+2, j));
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i,j] == 0 && board[i+1,j+1] == 0 && board[i+2,j+2] == 0)
                            Console.WriteLine(String.Format("new Tuple<Point, Point, Point>(new Point({0},{1}), new Point({2},{3}), new Point({4},{5})),", i, j, i+1, j+1, i+2, j+2));
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    try
                    {
                        if (board[i,j] == 0 && board[i+1,j-1] == 0 && board[i+2,j-2] == 0)
                            Console.WriteLine(String.Format("new Tuple<Point, Point, Point>(new Point({0},{1}), new Point({2},{3}), new Point({4},{5})),", i, j, i+1, j-1, i+2, j-2));
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
            }
            Console.WriteLine();

            Console.ReadLine();
        }
        #endregion

        public Board()
        {
            board = new char[4,3];
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    board[i, j] = Empty;
                }
            }
        }

        public override string ToString()
        {
            string str = string.Empty;

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    str += board[i, j] + " ";
                }
                str += Environment.NewLine;
            }
            return str;
        }

        /// <summary>
        /// Grade a board based on whether it has 3-in-a-row or not, if being used as a heuristic function (with heuristic flag)
        /// then count all 2-in-a-row's and return as result
        /// </summary>
        /// <param name="side">what side is playing</param>
        /// <param name="heuristic">true if being used as a heuristic function, otherwise false</param>
        /// <returns>int.max / 2 if 'side' won, - (int.max / 2) if 'side' lost. If being used as heuristic, return the number of 2-in-a-row's</returns>
        public int Score(char side, bool heuristic)
        {
            //check for winning state
            foreach (var a in triplet)
            {
                if (side == ReadCell(a.Item1) && side == ReadCell(a.Item2) && side == ReadCell(a.Item3))
                {
                    return Win;
                }
                if (ReadCell(a.Item1) != side && ReadCell(a.Item1) != Empty &&
                    ReadCell(a.Item2) != side && ReadCell(a.Item2) != Empty &&
                    ReadCell(a.Item3) != side && ReadCell(a.Item3) != Empty)
                    return Lose;
            }

            if (!heuristic)
                return 0;

            //no winning state, check for all 2-in-a-row's
            int score = 0;
            foreach (var a in duplet)
            {
                if (side == ReadCell(a.Item1) && side == ReadCell(a.Item2))
                {
                    ++score;
                }
            }

            return score;
        }

        public bool IsFull()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (board[i, j] == Empty)
                        return false;
                }
            }
            return true;
        }

        private char ReadCell(Point point)
        {
            return board[point.X, point.Y];
        }

        public bool Drop(int col, char side)
        {
            if (col < 0 || col >= 3)
            {
                throw new ArgumentOutOfRangeException("col can only be 0, 1, or 2");
            }

            if (board[3, col] != '.')
            {
                return false;
            }

            for (int i = 0; i < 4; ++i)
            {
                if (board[i, col] == '.')
                {
                    board[i, col] = side;
                    return true;
                }
            }

            return false;
        }
    }
}
