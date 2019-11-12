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
            // int x = ReadInt("Type a number: ");
            // int y = ReadInt("Type another number: ");

            Console.WriteLine();
            // Console.WriteLine($"{x} + {y} = {x + y}");
            Console.WriteLine();


            Console.WriteLine("Exercise 2, give two years, 0 - 9999");
            // Years(); // Calls a second method
            Console.WriteLine();


            Console.WriteLine("Exercise 3, check if palindrome");
            //Console.WriteLine(IsPalindrome("asA a s    a  "));


            Console.WriteLine("Exercise 4, FizzBuzz");
            //FizzBuzz();
            Console.WriteLine();


            Console.WriteLine("Exercise 5, FizzBuzz");
            CoolGame();





            Console.ReadKey(); // Pause to view the reasults.
        }

        static int ReadInt(string message) // Exercise 1
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
                if (i % 4 == 0)
                    Console.Write(" *");
                Console.WriteLine();
            }
        }

        static int GetYear(int conA, int conB, bool first) // Exercise 2, Method 2/2
        {
            int year;
            while (true)
            {
                if (first)
                    Console.Write("First year: ");
                else
                    Console.Write("Second year: ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                    if (year <= conA || year > conB)
                        Console.WriteLine("Year must be between {0} and {1}", (conA + 1), conB);
                    else
                    {
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

        static bool IsPalindrome(string word) // Exercise 3, Palindrome
        {
            string processedWord = string.Concat(word.Where(ch => !char.IsWhiteSpace(ch))).ToLower();
            var reversedWordArray = processedWord.ToCharArray();
            Array.Reverse(reversedWordArray);
            string reversedWord = new string(reversedWordArray);

            if (processedWord.Equals(reversedWord))
                return true;
            else
                return false;
        }

        static void FizzBuzz() // Exercise 4, FizzBuzz
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i % 3 == 0)
                    Console.Write("Fizz");

                if (i % 5 == 0)
                    Console.Write("Buzz");

                if (i % 3 != 0 && i % 5 != 0)
                    Console.Write(i);

                Console.WriteLine();
            }
        }

        static void CoolGame()
        {
            Console.WriteLine("Wellcome to the coolest game.");
            Console.WriteLine();
            Console.WriteLine("Try ti guess the right number btween 1 and 99");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine("A random number is generated");
            var random = new Random();
            int randomNumber = random.Next(1, 99);

            int input = 0;

            while (true)
            {
                try
                {
                    Console.Write("Number: ");
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Bad input.");
                    Console.WriteLine("Try again.");
                }

                if (input == randomNumber)
                {
                    Console.WriteLine("That is correct!");
                    break;
                }

                if (input > randomNumber)
                    if (input > (randomNumber + 5))
                        Console.WriteLine("To high");
                    else
                        Console.WriteLine("A little bit to high");
                else
                    if (input < (randomNumber - 5))
                        Console.WriteLine("To low");
                    else
                        Console.WriteLine("Try just a little bigger number");
            }

            Console.ReadKey();
        }
    }
}
