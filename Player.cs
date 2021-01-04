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
    public class Player
    {
        private string name;
        private Color color;

        public Player(string name, bool firstPlayer)
        {
            this.name = name;
            this.color = firstPlayer ? Color.White : Color.Black;
        }

        public string AskMovePlayer()
        {
            string colorTmp = GetColorLongStr();
            return name + " " + colorTmp + " move [ex: \"A2 A4\"]:";
        }

        public string GetName()
        {
            return name;
        }

        public string GetColor()
        {
            return color == Color.White ? "w" : "b";
        }

        public string GetColorLongStr()
        {
            return color == Color.White ? "white" : "black";
        }

        public Color GetColorEmum()
        {
            return color;
        }

        public bool IsFirstPlayer()
        {
            return color == Color.White ? true : false;
        }
    }
}
