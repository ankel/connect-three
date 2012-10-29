using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect_Three
{
    class BoardAndScore : IComparable<BoardAndScore>
    {
        public Board gameBoard;
        public int score;
        public int move;

        public BoardAndScore(Board gameBoard, char side)
        {
            this.gameBoard = new Board();
            Array.Copy(gameBoard.board, this.gameBoard.board, 3 * 4);
            score = this.gameBoard.Score(side, false);
        }

        public void UpdateScore(char side)
        {
            score = gameBoard.Score(side, false);
        }

        int IComparable<BoardAndScore>.CompareTo(BoardAndScore other)
        {
            return this.score - other.score;
        }
    }
}
