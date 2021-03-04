using System;
using System.Collections.Generic;
using System.Text;

namespace Warcaby
{
    class Pawn
    {
        public bool IsWhite;
        public bool IsCrowned;
        public int x;
        public int y;

        public bool move(int new_x, int new_y)
        {
            return true;
        }

        public Pawn(int x_pos, int y_pos, bool iswhite)
        {
            x = x_pos;
            y = y_pos;
            IsWhite = iswhite;
            IsCrowned = false;
        }
    }
}