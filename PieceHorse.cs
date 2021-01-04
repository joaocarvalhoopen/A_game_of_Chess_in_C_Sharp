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
    public class PieceHorse : Piece
    {
        private PieceHorse(Color color, PieceType pType) : base(color, PieceType.Horse)
        {
        }

        public PieceHorse(Color color) : this(color, PieceType.Horse)
        {
        }

        public override Tuple<int, int>[] PossibleMoves(MoveOrAtack moveOrAtack, int fromRow, int fromCol)
        {
            // Console.WriteLine("fromRow: {0}, fromCol: {1}", fromRow, fromCol);

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            int toRow, toCol;

            //////////////
            // Like a horse
            // Upper left, Upper right, Lower right, Lower left.
            int[] toRowAr = new int[8] {-1, -2, -2, -1, +1, +2, +2, +1};
            int[] toColAr = new int[8] {-2, -1, +1, +2, +2, +1, -1, -2};

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
