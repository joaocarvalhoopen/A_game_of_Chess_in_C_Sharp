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
    public enum PieceType
    {
        None   = 0,
        King   = 1,
        Queen  = 2,
        Bishop = 3,
        Horse  = 4,
        Tour   = 5,
        Pawn   = 6
    }

    public static class PieceTypeExt
    {
        public static string AsText(this PieceType pType)
        {
            switch (pType)
            {
                case PieceType.None: return " ";
                case PieceType.King: return "K";
                case PieceType.Queen: return "Q";
                case PieceType.Bishop: return "B";
                case PieceType.Horse: return "H";
                case PieceType.Tour: return "T";
                case PieceType.Pawn: return "P";
            }

            // Catch any other enum value
            return pType.ToString();
        }
    }
}
