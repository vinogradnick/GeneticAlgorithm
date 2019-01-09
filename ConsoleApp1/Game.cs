using System;
using System.Drawing;

namespace ConsoleApp1
{
    public class Game
    {
        private int[,] _gameBoard;
        public int Size { get; private set; }

        public Game(int size)
        {
            Size = size;
            _gameBoard=new int[size,size];
        }

        public void InitWorld()
        {
            for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                _gameBoard[i, j] = 0;
        }

        public void AddBactery(ushort[] arr)
        {
            Random random = new Random();
            int counter = 0;
            int sqrt = (int) Math.Sqrt(arr.Length);
            int startPoint = random.Next(0, Size- sqrt);
            
            for (int i = startPoint; i < startPoint+sqrt; i++)
            {
                for (int j = startPoint; j < startPoint+sqrt; j++)
                {
                    _gameBoard[i, j] = arr[counter];
                    counter++;
                }
            }
        }

        public void CheckNeightborhud()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Console.Write(_gameBoard[i, j] + " ");
                Console.WriteLine();
            }
        }

        public Bitmap FillBitmap()
        {
            Bitmap bitmap =new Bitmap(Size,Size);
            for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                bitmap.SetPixel(i, j, _gameBoard[i, j] == 1 ? Color.Red : Color.SeaShell);
            
            return bitmap;
        }
    }
}