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
    public enum MoveOrAtack
    {
        Move  = 0,
        Atack = 1
    }

    public static class MoveOrAtackExt
    {
        public static string AsText(this MoveOrAtack mA)
        {
            switch (mA)
            {
                case MoveOrAtack.Move:  return "Move";
                case MoveOrAtack.Atack: return "Black";
            }

            // Catch any other enum value
            return mA.ToString();
        }
    }

}
