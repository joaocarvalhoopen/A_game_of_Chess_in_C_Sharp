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
    public enum Color
    {
        White = 0,
        Black = 1
    }

    public static class ColorExt 
    {
        public static string AsText(this Color c)
        { 
            switch (c)
            {
                case Color.White: return "w";
                case Color.Black: return "b";
            }

            // Catch any other enum value
            return c.ToString();
        }
    }
}
