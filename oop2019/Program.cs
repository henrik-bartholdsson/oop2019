using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 1, give two numbers");
            int x = ReadInt("Type a number: ");
            int y = ReadInt("Type another number: ");

            Console.WriteLine();
            Console.WriteLine($"{x} + {y} = {x + y}");

            Console.WriteLine();
            Console.WriteLine("Exercise 1, give two years, 0 - 9999");
            Years();


            Console.Read(); // Pause to view the reasults.
        }

        static int ReadInt(string message) // Exercise 1, Method 1/1
        {
            int returningNumber;
            while (true)
            {
                Console.Write(message);
                var numberAsString = Console.ReadLine();

                if (int.TryParse(numberAsString, out returningNumber))
                {
                    returningNumber = Convert.ToInt32(numberAsString);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not a number, try again");
                    Console.ResetColor();
                }
            }
            return returningNumber;
        }

        static void Years() // Exercise 2, Method 1/2
        {
            Console.WriteLine("-- Amazing Leap Year Calculator 2019 --");
            int firstYear = GetYear(0, 9999, true);
            int secondYear = GetYear(firstYear, 9999, false);
            
            for (int i = firstYear; i <= secondYear; i++)
            {
                Console.Write(i);
                if(i % 4 == 0)
                    Console.Write(" *");
                Console.WriteLine();
            }
        }

        static int GetYear(int conA, int conB, bool first) // Exercise 2, Method 2/2
        {
            int year;
            while (true)
            {
                if(first)
                    Console.Write("First year: ");
                else
                    Console.Write("Second year: ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                    if (year < conA || year > conB)
                        Console.WriteLine("Year must be between {0} and {1}", conA, conB);
                    else {
                        Console.WriteLine("Ok");
                        Console.WriteLine();
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Bad input, try again");
                }
            }

            return year;
        }


    }
}
