using System;

namespace Tetris
{
    class Empty : Block
    {
        override public string Mark {get; set;} = " ";
        override public bool IsFalling {get; set;} = false;
    }
}