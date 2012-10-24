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
        //CharStack[] theBoard;
        public int cnt;
        public const char Empty = '.';
        public const int Win = 100;
        public const int Lose = -100;

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
            cnt = 0;
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

        /// <summary>
        /// Check if the board is full or not
        /// </summary>
        /// <returns>true if full, false if not</returns>
        public bool IsFull()
        {
            for (int j = 0; j < 3; ++j)
            {
                if (board[3, j] == Empty)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check if a specified column is full or not
        /// </summary>
        /// <param name="col">column to check</param>
        /// <returns>true if 'col' is full, otherwise false</returns>
        public bool IsFull(int col)
        {
            return board[3, col] != Empty;
        }

        private char ReadCell(Point point)
        {
            return board[point.X, point.Y];
        }

        /// <summary>
        /// Drop a ball color 'side' into the board at collumn 'col
        /// </summary>
        /// <param name="col">column to drop the ball into</param>
        /// <param name="side">color of the ball to drop</param>
        /// <returns>true if successfully dropped, otherwise false</returns>
        public bool Drop(int col, char side)
        {
            if (IsFull(col))
                return false;

            for (int i = 0; i < 4; ++i)
            {
                if (board[i, col] == Empty)
                {
                    board[i, col] = side;
                    cnt++;
                    return true;
                }
            }

            return false;
        }


        public void Pop(int col)
        {
            for (int i = 3; i >= 0; --i)
            {
                if (board[i, col] != Empty)
                {
                    board[i, col] = Empty;
                    cnt--;
                    return;
                }
            }
        }
    }
}
