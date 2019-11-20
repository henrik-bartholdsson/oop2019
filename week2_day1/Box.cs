using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_day1
{
    class Box
    {
        public int _xPos { get; set; }
        public int _yPos { get; set; }
        public int _x { get; set; }
        public int _y { get; set; }
        public ConsoleColor _col { get; set; }

        public Box(int x, int y, int xPos, int yPos)
        {
            _xPos = xPos;
            _yPos = yPos;
            _x = x;
            _y = y;
            _col = ConsoleColor.Gray;
        }
        public Box(int x, int y, int xPos, int yPos, ConsoleColor? col)
        {
            _xPos = xPos;
            _yPos = yPos;
            _x = x;
            _y = y;
            _col = col.GetValueOrDefault();
        }

        public void Draw()
        {
            Console.ForegroundColor = _col;
            for (int i = 0; i <= _y; i++)
            {
                for (int j = 0; j <= _x; j++)
                {
                    Console.SetCursorPosition((_xPos + j), (_yPos + i));
                    Console.Write("X");
                }
            }
        }
    }
}
