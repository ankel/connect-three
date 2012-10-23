using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect_Three
{
    class DrawnGame : Exception
    {
        public DrawnGame()
            : base()
        {
        }

        public DrawnGame(string str)
            : base(str)
        {
        }
    }

    class WonGame : Exception
    {
        public WonGame()
            : base()
        {
        }

        public WonGame(string str)
            : base()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "g")
            {
                Board.GenerateDuplets();
                Board.GenerateTriplets();
                return;
            }

            Board gameBoard = new Board();

            try
            {
                while (true)
                {
                    MakeAMove('a', gameBoard);
                    MakeAMove('b', gameBoard);
                }
            }
            catch (DrawnGame)
            {

            }
            catch (WonGame e)
            {

            }
        }

        private static void MakeAMove(char side, Board gameBoard)
        {
            
        }
    }
}
