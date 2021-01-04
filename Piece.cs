/*
 * Author: João Nuno Carvalho
 * Date:   2021.01.03
 * Description: A simple game of Chess in C# programming language.
 * License: MIT Open Source License.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_in_C_Sharp
{
    public abstract class Piece
    {
        protected Color color;
        protected Color otherColor;
        protected PieceType pType;
        protected Board board;
        protected bool hasMoved = false;
        protected Piece[,] b;
        



        protected Piece(Color color, PieceType pType)
        {
            this.color = color;
            this.otherColor = color == Color.White ? Color.Black : Color.White;
            this.pType = pType;
        }

        public Color GetColor() 
        {
            return color;
        }

        public Color GetOtherColor()
        {
            return otherColor;
        }

        public PieceType GetPieceType()
        {
            return pType;
        }

        public void SetBoard(Board board)
        {
            this.board = board;
            b = board.GetBoard();
        }

        public void SetHasMoved()
        {
            this.hasMoved = true;
        }
        
        protected bool BoundsCheck(int pos1D)
        {
            if (pos1D >= 0 && pos1D < 8)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return ColorExt.AsText(color) + "_" + PieceTypeExt.AsText(pType); 
        }

        public abstract Tuple<int, int>[] PossibleMoves(MoveOrAtack moveOrAtack, int fromRow, int fromCol);

        public bool IsPossibleMove(int fromRow, int fromCol, int toRow, int toCol)
        {
            Tuple<int, int>[] tuplePossibleToAr = PossibleMoves(MoveOrAtack.Move, fromRow, fromCol);
            foreach (Tuple<int, int> tuplePossibleTo in tuplePossibleToAr)
            {
                // Console.Write("({0}, {1})", tuplePossibleTo.Item1, tuplePossibleTo.Item2);
            }
            // Console.WriteLine("");
            foreach (Tuple<int, int> tuplePossibleTo in tuplePossibleToAr)
            {
                int toPossibleRow = tuplePossibleTo.Item1;
                int toPossibleCol = tuplePossibleTo.Item2;
                if (toPossibleRow == toRow && toPossibleCol == toCol)
                {
                    // Console.WriteLine("toPossibleRow: {0}, toPossibleCol: {1}", toPossibleRow, toPossibleCol);
                    return true;
                }
            }
            return false;
        }
    }
}
