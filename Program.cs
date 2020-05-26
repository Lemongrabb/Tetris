using System.Threading;
using System;

namespace Tetris
{
    class Program
    {
        static int time, score, level;
        static string[,] grid = new string[10,22];
        static void Main()
        {
            fill2DArray<string>(ref grid," ");
            Thread framePrinting = new Thread(printFrameThread);
            framePrinting.Start();

            while (true)
            {
                Console.ReadKey();
            }
        }

        static void printFrameThread()
        {
            while (true)
            {
                printFrame();
                Thread.Sleep(1000);
                time++;
            }
        }

        static void printFrame()
        {
            Console.Clear();
            Console.WriteLine("XXXXXXXXXXXX");
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                Console.Write("X");
                for (int j = 0; j < grid.GetLength(0); j++)
                {
                    Console.Write(grid[j,i]);
                }
                Console.Write("X\n");
            }
            Console.WriteLine("XXXXXXXXXXXX\n");
            Console.WriteLine("TIME: " + time);
            Console.WriteLine("SCORE: " + score);
            Console.WriteLine("LEVEL: " + level);
        }

        static void fill2DArray<T>(ref T[,] array, T value)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = value;
                }
            }
        }
    }
}
