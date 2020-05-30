using System.Net;
using System.Threading;
using System;

namespace Tetris
{
    public static class Program
    {
        public static int Time, Score, Level;
        public static Block[,] Grid = new Block[10,22];

        public static Random RNG = new Random();
        static void Main()
        {
            Prepare();
        }

        static void Prepare()
        {
            Fill2DArray<Block>(ref Grid,new Empty());
            
            Thread FramePrintingThread = new Thread(FramePrinting);
            FramePrintingThread.Start();

            Thread KeyListenerThread = new Thread(KeyListener);
            KeyListenerThread.Start();

            Thread GravityThread = new Thread(Gravity);
            GravityThread.Start();

            SpawnBlock();
        }

        static void Gravity()
        {
            while (true)
            {
                for (int j = Grid.GetLength(1)-2; j+1 > 0; j--)
                {
                    for (int i = Grid.GetLength(0)-1; i+1 > 0; i--)
                    {
                        if (Grid[i,j].IsFalling)
                        {
                            if (Grid[i,j+1] is Empty && j != Grid.GetLength(1)-2)
                            {
                                Grid[i,j] = new Empty();
                                Grid[i,j+1] = new Block1x1();
                                Thread.Sleep(100);
                            }else
                            {
                                Grid[i,j].IsFalling = false;
                                //TODO
                                // Sprawdź cały rząd
                                // Jeżeli cały rząd jest zajęty niespadającymi blokami, zamień go na puste pola, i każdy blok powyżej ustaw na falling
                                SpawnBlock();
                            }
                        }
                    }
                }
            }
        }

        static void SpawnBlock() //TODO temporary
        {
            Grid[RNG.Next(10),1] = new Block1x1();
        }

        static void KeyListener() //TODO temporary
        {
            while (true)
            {
                Console.ReadKey();
                Score++;
            }
        }

        static void FramePrinting()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("XXXXXXXXXXXX");
                for (int i = 0; i < Grid.GetLength(1)-1; i++)//TODO temporary solution, fix it later
                {
                    Console.Write("X");
                    for (int j = 0; j < Grid.GetLength(0); j++)
                    {
                        Console.Write(Grid[j,i].Mark);
                    }
                    Console.Write("X\n");
                }
                Console.WriteLine("XXXXXXXXXXXX\n");
                Console.WriteLine("TIME: " + Time);
                Console.WriteLine("SCORE: " + Score);
                Console.WriteLine("LEVEL: " + Level);
                Thread.Sleep(100);//TODO temporary
                Time++;
            }
        }

        static void Fill2DArray<T>(ref T[,] array, T value)
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
