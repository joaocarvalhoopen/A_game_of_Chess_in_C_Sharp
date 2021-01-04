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
    public class PieceTour : Piece
    {
        private PieceTour(Color color, PieceType pType) : base(color, PieceType.Tour)
        {
        }

        public PieceTour(Color color) : this(color, PieceType.Tour)
        {
        }

        public override Tuple<int, int>[] PossibleMoves(MoveOrAtack moveOrAtack, int fromRow, int fromCol)
        {
            // Console.WriteLine("fromRow: {0}, fromCol: {1}", fromRow, fromCol);

            List<Tuple<int, int>> list = new List<Tuple<int, int>>();

            int toRow, toCol;

            // Vertical
            toCol = fromCol;
            for (toRow = fromRow - 1; toRow > toRow - 8; toRow--)
            {
                if (BoundsCheck(toRow))
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

            toCol = fromCol;
            for (toRow = fromRow + 1; toRow < toRow + 8; toRow++)
            {
                if (BoundsCheck(toRow))
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

            // Horizontal
            toRow = fromRow;
            for (toCol = fromCol - 1; toCol > toCol - 8; toCol--)
            {
                if (BoundsCheck(toCol))
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

            toRow = fromRow;
            for (toCol = fromCol + 1; toCol < toCol + 8; toCol++)
            {
                if (BoundsCheck(toCol))
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
