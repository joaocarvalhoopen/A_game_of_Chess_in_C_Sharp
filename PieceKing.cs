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
    public class PieceKing : Piece 
    {
        private PieceKing(Color color, PieceType pType) : base(color, PieceType.King)
        {
        }

        public PieceKing(Color color) : this(color, PieceType.King) 
        {
        }

        public override Tuple<int, int>[] PossibleMoves(MoveOrAtack moveOrAtack, int fromRow, int fromCol)
        {
            // Console.WriteLine("fromRow: {0}, fromCol: {1}", fromRow, fromCol);

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            int toRow, toCol;

            //////////////
            // Like a King
            // Upper left, Upper, Upper right, Right, Lower right, Lower, Lower left, Left.
            int[] toRowAr = new int[8] { -1, -1, -1,  0, +1, +1, +1,  0 };
            int[] toColAr = new int[8] { -1,  0, +1, +1, +1, +0, -1, -1 };

            for (int i = 0; i < toRowAr.Length; i++)
            {
                toRow = fromRow + toRowAr[i];
                toCol = fromCol + toColAr[i];
                if (BoundsCheck(toRow) && BoundsCheck(toCol))
                {
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == color)
                    {
                    }
                    else if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == otherColor)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                    }
                    else if (b[toRow, toCol] == null)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                    }
                }
            }

            return list.ToArray();
        }
    }
}
