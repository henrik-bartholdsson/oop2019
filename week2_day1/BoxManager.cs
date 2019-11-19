using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_day1
{
    class BoxManager
    {
        ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        public ConsoleColor previewsColor;
        public int _nrOfBoxes { get; set; }
        public List<Box> theBoxes = new List<Box>();
        public BoxManager(int nrOfBoxes)
        {
            _nrOfBoxes = nrOfBoxes;
        }



        public void DrawInCenter()
        {
            var height = (Console.WindowHeight / 2);
            var width = (Console.WindowWidth / 2);

            for (int i = 0; i < _nrOfBoxes; i++)
            {
                theBoxes.Add(new Box((i * 4), (i * 2), width, height, getNewColor()));
                height -= 1;
                width -= 2;
            }

            for(int i = theBoxes.Count -1; i >= 0; i--)
            {
                theBoxes[i].Draw();
            }

        }

        public ConsoleColor getNewColor()
        {
            var random = new Random();
            ConsoleColor returningColor = ConsoleColor.Black;
            while (previewsColor == returningColor || returningColor == ConsoleColor.Black)
            {
                System.Threading.Thread.Sleep(3);
                returningColor = colors[random.Next(0, 15)];
                
            }

            previewsColor = returningColor;
            return returningColor;
        }
    }
}
