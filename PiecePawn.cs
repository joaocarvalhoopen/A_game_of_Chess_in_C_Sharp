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
    public class PiecePawn : Piece
    {
        private PiecePawn(Color color, PieceType pType) : base(color, PieceType.Pawn)
        {
        }

        public PiecePawn(Color color) : this(color, PieceType.Pawn)
        {
        }

        public override Tuple<int, int>[] PossibleMoves(MoveOrAtack moveOrAtack, int fromRow, int fromCol)
        {
            // Console.WriteLine("fromRow: {0}, fromCol: {1}", fromRow, fromCol);

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            // Direction
            int dir = color == Color.White ? 1 : -1;

            // Default direction is White.
            int toRow, toCol;
            // Next forward position opening.
            // If there is no peace in the path.
            if (moveOrAtack == MoveOrAtack.Move)
            {
                toRow = fromRow - 2 * dir;
                toCol = fromCol;
                if (!hasMoved && b[fromRow - 1 * dir, fromCol] == null && b[toRow, toCol] == null)
                {
                    list.Add(new Tuple<int, int>(toRow, toCol));
                }
                // Nest forward position normal.
                toRow = fromRow - 1 * dir;
                toCol = fromCol;
                if (BoundsCheck(toRow) && b[toRow, toCol] == null)
                {
                    list.Add(new Tuple<int, int>(toRow, toCol));
                }

                // Eat to the right and eat to the left. 
                toRow = fromRow - 1 * dir;
                toCol = fromCol - 1;
                if (BoundsCheck(toRow) && BoundsCheck(toCol) && b[toRow, toCol] != null && b[toRow, toCol].GetColor() == otherColor)
                {
                    list.Add(new Tuple<int, int>(toRow, toCol));
                }
                toRow = fromRow - 1 * dir;
                toCol = fromCol + 1;
                if (BoundsCheck(toRow) && BoundsCheck(toCol) && b[toRow, toCol] != null && b[toRow, toCol].GetColor() == otherColor)
                {
                    list.Add(new Tuple<int, int>(toRow, toCol));
                }
            }
            else if (moveOrAtack == MoveOrAtack.Atack)
            {
                // Eat to the right and eat to the left. 
                toRow = fromRow - 1 * dir;
                toCol = fromCol - 1;
                if (   BoundsCheck(toRow) && BoundsCheck(toCol) 
                    && (b[toRow, toCol] == null || (b[toRow, toCol] != null && (   b[toRow, toCol].GetColor() == color
                                                                                || b[toRow, toCol].GetColor() != color)))) // Someting not correct here.
                {
                    list.Add(new Tuple<int, int>(toRow, toCol));
                }
                toRow = fromRow - 1 * dir;
                toCol = fromCol + 1;
                if (   BoundsCheck(toRow) && BoundsCheck(toCol) 
                    && (b[toRow, toCol] == null || (b[toRow, toCol] != null && (   b[toRow, toCol].GetColor() == color
                                                                                || b[toRow, toCol].GetColor() != color))))   // Someting not correct here.
                {
                    list.Add(new Tuple<int, int>(toRow, toCol));
                }
            }

            return list.ToArray();
        }
    }
}
