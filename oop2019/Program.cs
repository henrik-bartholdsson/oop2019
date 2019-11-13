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

            Console.WriteLine("Exercise 5, Game");
            //CoolGame();
            Console.WriteLine();

            Console.WriteLine("Exercise 6, Game with AI");
            //CoolGameWithAi();


            LoadingBars();


            Console.ReadKey(); // Pause to view the reasults.
        }

        /// Metoder
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
        } // Exercise 5, Game

        static void CoolGameWithAi() // Exercise 6, Game with super AI
        {
            int lowerNumber = 1;
            int upperNumber = 99;

            int CPUguess = 0;
            int HumanGuess = 0;

            var computer = new NpcPlayer(lowerNumber, upperNumber);

            var randomObj = new Random();
            bool humanStarts = randomObj.Next(0, 2) == 0 ? false : true;
            int randomNumber = randomObj.Next(lowerNumber, upperNumber);

            Console.WriteLine("Gissa ett tal mellan {0} och {1} " + humanStarts, lowerNumber, upperNumber);
            if (humanStarts)
                Console.WriteLine("Human starts");
            else
                Console.WriteLine("Computer starts");

            while (true)
            {
                if (humanStarts)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.Write("Human, pick a number: ");
                    try
                    {
                        HumanGuess = Convert.ToInt32(Console.ReadLine());
                        if (randomNumber == HumanGuess)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Correct! Human won.");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            if (randomNumber > HumanGuess)
                                Console.WriteLine("Try a bigger number");
                            else
                                Console.WriteLine("Try a lower number");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Bad input!");
                    }

                    humanStarts = false;
                }
                else
                {
                    Console.WriteLine("------------------------------------------");
                    Console.Write("CPU pick your number: ");
                    CPUguess = computer.NpcGuess();
                    Console.WriteLine(CPUguess);
                    if (randomNumber == CPUguess)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CPU won!");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        if (randomNumber > CPUguess)
                        {
                            Console.WriteLine("CPU! Try a bigger number");
                            computer.higherThan = CPUguess;
                        }
                        else
                        {
                            Console.WriteLine("CPU! Try a lower number");
                            computer.lowerThen = CPUguess;
                        }
                    }

                    humanStarts = true;
                }
            }


            Console.ReadKey();
        }

        static void LoadingBars() // Exercise 7, C64 loading bars
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

            var random = new Random();
            int additive = 0;
            int stop = 10;
            while (stop > 0)
            {
                for (int i = 0; i < 30; i++)
                {
                    additive = random.Next(5, 30);
                    foreach (var c in colors)
                    {
                        Console.BackgroundColor = c;
                        for (int j = 0; j < (120 + additive); j++)
                        {
                            Console.Write(" ");
                        }
                    }
                    System.Threading.Thread.Sleep(50);
                }
                stop--;
            }
        }

        static void RenderTree() // Exercise 8, Christmas tree.
        {
            Console.WriteLine("Input size of thew tree");
            var random = new Random();
            int leftMargin = 0;
            int treeSize = 0;
            try
            {
                treeSize = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("So you're a trubble maker!? Then we pic a size for you!");
                treeSize = random.Next(5,9);
            }

            leftMargin = treeSize + 1;

            for (int i = 0; i< treeSize; i++)
            {

            }

        }

    }







    // Klasser!
    class NpcPlayer
    {
        public int guess { get; set; }
        public int higherThan { get; set; }
        public int lowerThen { get; set; }
        public NpcPlayer(int higherThan, int lowerThen)
        {
            this.higherThan = higherThan;
            this.lowerThen = lowerThen;
        }

        public int NpcGuess()
        {
            System.Threading.Thread.Sleep(400);
            var random = new Random();

            return random.Next(higherThan, lowerThen);
        }
    } // AIns medvetande.


}
