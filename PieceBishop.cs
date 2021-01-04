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
    public class PieceBishop : Piece
    {
        private PieceBishop(Color color, PieceType pType) : base(color, PieceType.Bishop)
        {
        }

        public PieceBishop(Color color) : this(color, PieceType.Bishop)
        {
        }

        public override Tuple<int, int>[] PossibleMoves(MoveOrAtack moveOrAtack, int fromRow, int fromCol)
        {
            // Console.WriteLine("fromRow: {0}, fromCol: {1}", fromRow, fromCol);

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            int toRow, toCol;

            // To lower left.
            for (toRow = fromRow - 1, toCol = fromCol - 1; toRow > toRow - 8 && toCol > toCol - 8; toRow--, toCol--)
            {
                if (BoundsCheck(toRow) && BoundsCheck(toCol))
                {
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == color)
                    {
                        break;
                    }
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == otherColor)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                        break;
                    }
                    if (b[toRow, toCol] == null)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                    }
                }
                else
                {
                    break;
                }
            }

            // To upper right.
            for (toRow = fromRow + 1, toCol = fromCol + 1; toRow < toRow + 8 && toCol < toCol + 8; toRow++, toCol++)
            {
                if (BoundsCheck(toRow) && BoundsCheck(toCol))
                {
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == color)
                    {
                        break;
                    }
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == otherColor)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                        break;
                    }
                    if (b[toRow, toCol] == null)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                    }
                }
                else
                {
                    break;
                }
            }

            // To lower right.
            for (toRow = fromRow - 1, toCol = fromCol + 1; toRow > toRow - 8 && toCol < toCol + 8; toRow--, toCol++)
            {
                if (BoundsCheck(toRow) && BoundsCheck(toCol))
                {
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == color)
                    {
                        break;
                    }
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == otherColor)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                        break;
                    }
                    if (b[toRow, toCol] == null)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                    }
                }
                else
                {
                    break;
                }
            }

            // To upper left.
            for (toRow = fromRow + 1, toCol = fromCol - 1; toRow < toRow + 8 && toCol > toCol - 8; toRow++, toCol--)
            {
                if (BoundsCheck(toRow) && BoundsCheck(toCol))
                {
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == color)
                    {
                        break;
                    }
                    if (b[toRow, toCol] != null && b[toRow, toCol].GetColor() == otherColor)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                        break;
                    }
                    if (b[toRow, toCol] == null)
                    {
                        list.Add(new Tuple<int, int>(toRow, toCol));
                    }
                }
                else
                {
                    break;
                }
            }

            return list.ToArray();
        }
    }
}
