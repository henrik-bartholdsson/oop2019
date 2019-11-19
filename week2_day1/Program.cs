using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_day1
{
    class Program
    {
        static void Main(string[] args)
        {
            //First();

            //Second();

            //Third();

            //Forth();
        }

        static void First()
        {
            var box1 = new Box(4, 3, 7, 4);
            var box2 = new Box(11, 7, 13, 8);

            box1.Draw();
            Console.WriteLine();
            box2.Draw();


            Console.ReadKey();
        }

        static void Second()
        {
            var box1 = new Box(4, 3, 7, 4, ConsoleColor.Red);
            var box2 = new Box(11, 7, 13, 8, ConsoleColor.Green);

            box1.Draw();
            Console.WriteLine();
            box2.Draw();


            Console.ReadKey();
        }

        static void Third()
        {
            var xNrOfBoxes = new BoxManager(8);

            xNrOfBoxes.DrawInCenter();

            Console.ReadKey();
        }

        static void Forth()
        {
            // slumba box storlek 0-15 (x = y * 2)
            // slumpa en färg
            // slumpa en x-position, om förstor, minska ner den
            // slumpa en y-position, om förstor, minska ner den
            // Upprepa till tidens ände.

            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            int boxHeight = 0;
            int boxWidth = 0;
            int boxYPos = 0;
            int boxXPos = 0;
            var random = new Random();
           int boxColor = 0;
            

            while(true)
            {
                System.Threading.Thread.Sleep(200);
                boxHeight = random.Next(2, 12);
                boxWidth = boxHeight * 2;
                boxYPos = random.Next(0, Console.WindowHeight);
                boxXPos = random.Next(0, Console.WindowWidth);
                boxColor = random.Next(0, (colors.Length -1));

                if ((boxYPos + boxHeight) > Console.WindowHeight)
                    boxYPos -= boxHeight;

                if ((boxXPos + boxWidth) > Console.WindowHeight)
                    boxXPos -= boxWidth;

                Console.BackgroundColor = colors[boxColor];

                var box = new Box(
                    boxWidth,
                    boxHeight,
                    boxXPos,
                    boxYPos,
                    colors[boxColor]
                    );

                box.Draw();
            }









        }
    }
}
