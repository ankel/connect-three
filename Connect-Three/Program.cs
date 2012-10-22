using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect_Three
{
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
        }
    }
}
