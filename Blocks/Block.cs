using System;

namespace Tetris
{
    public abstract class Block
    {
        public virtual bool IsFalling {get; set;} = true;
        int[,] Position;
        int[,] Shape;

        public virtual string Mark {get; set;}
    }
}