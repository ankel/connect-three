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

        public Board()
        {
            board = new char[4,3];
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    board[i, j] = '.';
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

        public int Score(char side)
        {
            //check for winning state
            foreach (var a in triplet)
            {
                if (side == ReadCell(a.Item1) && side == ReadCell(a.Item2) && side == ReadCell(a.Item3))
                {
                    return (int.MaxValue / 2);
                }
            }

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

        private char ReadCell(Point point)
        {
            return board[point.X, point.Y];
        }

        public bool Drop(int col, char side)
        {
            if (col < 0 || col >= 3)
            {
                throw new ArgumentOutOfRangeException("position can only be 0, 1, or 2");
            }

            int cnt = 0;
            for (int j = 0; j < 3; ++j)
            {
                cnt += board[3, j] == '.' ? 0 : 1;
            }

            if (cnt >= 3)
            {
                return false;
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
