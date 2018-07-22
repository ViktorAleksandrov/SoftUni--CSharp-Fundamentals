using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App
{
    public class Position
    {
        private int left;
        private int top;

        public Position(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }

        public int Top
        {
            get { return this.top; }
            set { this.top = value; }
        }

        public int Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public static Position ConsoleCenter()
        {
            int centerTop = Console.WindowHeight / 2;
            int centerLeft = Console.WindowWidth / 2;

            var center = new Position(centerLeft, centerTop);
            return center;
        }
    }
}