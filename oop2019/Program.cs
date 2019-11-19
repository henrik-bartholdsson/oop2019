using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oop2019
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kommentera ut den som ska testas //
            //      De tre första hör ihop!     //


            // int x = ReadInt("Type a number: ");
            // int y = ReadInt("Type another number: ");
            // Console.WriteLine($"{x} + {y} = {x + y}");

            // Years();

            //Console.WriteLine(IsPalindrome("asA a s    a  "));

            //FizzBuzz();

            //CoolGame();

            //CoolGameWithAi();

            //LoadingBars();

            //RenderTree();

            //CalculateLandArea();

            //Invader();

            //Calculator();

            //Tetris();

            //TetrisPieces();


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
            int nrOfAsterisk = 1;
            int leftMargin = 0;
            int treeSize = 0;
            var repeated = new string('*', nrOfAsterisk);


            try
            {
                treeSize = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("So you're a trubble maker!? Then we pic a size for you!");
                treeSize = random.Next(5, 9);
            }

            leftMargin = treeSize + 1;

            for (int i = 0; i < treeSize; i++)
            {
                Console.WriteLine(string.Join("", Enumerable.Repeat(' ', leftMargin)) + string.Join("", Enumerable.Repeat('*', nrOfAsterisk)));
                nrOfAsterisk += 2;
                leftMargin--;
            }
            Console.Write(string.Join("", Enumerable.Repeat(' ', treeSize)));
            Console.WriteLine("[]");
            Console.ReadKey();
        }

        static void CalculateLandArea() // Exercise 9, Calculate land
        {
            int landArea = 0;
            int waterSurface = 0;
            var Lines = File.ReadLines(@"C:\map.txt");

            foreach (var l in Lines)
            {
                foreach (var c in l)
                {
                    if (c.Equals('#'))
                        landArea++;
                    else if (c.Equals('.'))
                        waterSurface++;
                }
            }
            Console.WriteLine("----------- Absolute numbers -----------");
            Console.WriteLine("Land area: " + landArea);
            Console.WriteLine("Water surface:" + waterSurface);
            Console.WriteLine();
            Console.WriteLine("----------- Relative -----------");
            Console.WriteLine("Land area: " + Math.Round(Decimal.Divide(landArea, (landArea + waterSurface)), 3));
        }

        static void Invader() // Exercise 10, Invader
        {
            var invader = new[,]
            {
                    { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                    { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
                    { 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0 }
            };

            var random = new Random();
            int buffTop = 0;
            int buffLeft = 0;

            for(int i = 0; i < invader.GetLength(0); i++)
            {
                for(int j = 0; j < invader.GetLength(1); j++)
                {
                    if(invader[i,j] == 1)
                        Console.Write("**");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
            }

            // Console.WriteLine("Enter to move the invader, Any key then Enter to exit.");
            while (true)
            {

                
                buffTop = random.Next(0,10);
                buffLeft = random.Next(0, 10);

                Console.MoveBufferArea(0, 0, 22,
                           16, buffLeft, buffTop);
                Thread.Sleep(500);

                Console.MoveBufferArea(buffLeft, buffTop, 22,
                           16, 0, 0);

            }
        }

        static void Calculator()
        {
            var formula = "2 + 2 * 3 / 9";

            var result = CalculateString(formula);
            Console.WriteLine("{0} = {1}", formula, result);

        } // Exercise 11, Calc 1/2

        public static double CalculateString(string formula)
        {
            double result;
            var calc = new string[formula.Split(' ').Length];
            int countTracker = 0;

            foreach (char c in formula)
            {
                if (!c.Equals(' '))
                    calc[countTracker] += c.ToString();

                if (c.Equals(' '))
                    countTracker++;
            }

            result = Convert.ToInt32(calc[0]);
            for (int i = 1; i < calc.Length; i++)
            {
                if (i % 2 != 0)
                    switch (calc[i])
                    {
                        case "+":
                            result += Convert.ToInt32(calc[i + 1]);
                            break;
                        case "-":
                            result -= Convert.ToInt32(calc[i + 1]);
                            break;
                        case "*":
                            result *= Convert.ToInt32(calc[i + 1]);
                            break;
                        case "/":
                            result /= Convert.ToInt32(calc[i + 1]);
                            break;
                    }
            }

            return result;
        } // Exercise 11, Calc 2/2

        static void Tetris()
        {
            var block = new byte[,] {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 },
            };

            int rowLength = block.GetLength(0);
            int colLength = block.GetLength(1);

            for (int k = 0; k < 10; k++)
            {
                Console.Clear();
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                        Console.Write(block[i, j] + " ");
                    Console.WriteLine();
                }
                Thread.Sleep(1000);
                block = Rotate(block);
            }

            Console.WriteLine();
        } // Exercise 12, Tetris

        static byte[,] Rotate(byte[,] b)
        {
            // Lite fulkod kanske? :)
            int rowLength = b.GetLength(0);
            int colLength = b.GetLength(1);
            int getZero = 0;

            // Looking for horizontal sum = 0
            for (int i = 0; i < b.GetLength(1); i++)
            {
                getZero = 0;
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    getZero += b[i, j];
                }
                if (getZero == 0 && i == 0)
                {
                    b[1, 0] = 0;
                    b[0, 1] = 1;
                    return b;
                }
                else if (getZero == 0 && i == 2)
                {
                    b[1, 2] = 0;
                    b[2, 1] = 1;
                    return b;
                }
            }

            // Looking for vertical sum = 0
            for (int i = 0; i < b.GetLength(1); i++)
            {
                getZero = 0;
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    getZero += b[j, i];
                }
                if (getZero == 0 && i == 0)
                {
                    b[2, 1] = 0;
                    b[1, 0] = 1;
                    return b;
                }
                else if (getZero == 0 && i == 2)
                {
                    b[0, 1] = 0;
                    b[1, 2] = 1;
                    return b;
                }
            }
            return b;
        } // Exercise 12, Tetris

        static void TetrisPieces()
        {
            var delayRandomSeed = new Random();
            Console.Clear();
            var bagOfItems = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(delayRandomSeed.Next(10, 30));
                bagOfItems = CreateBag();
                Console.WriteLine("---- Bag nr# {0} ----", (i + 1));
                foreach (var item in bagOfItems)
                {
                    Console.WriteLine("Item: {0}", item);
                }
            }
            Console.WriteLine("End.....");
            Console.ReadKey();
        } // Exercise 12, Tetris bag

        static List<string> CreateBag()
        {
            var random = new Random();
            var rawMaterialBag = new List<int>();
            var returningBag = new List<string>();
            int randomIndex;

            for (int i = 0; i < 7; i++)
            {
                rawMaterialBag.Add(i + 1);
            }

            for (int i = 0; i < 7; i++)
            {
                randomIndex = random.Next(0, rawMaterialBag.Count);
                returningBag.Add(rawMaterialBag[randomIndex].ToString());
                rawMaterialBag.RemoveAt(randomIndex);
            }

            return returningBag;
        } // Exercise 12, Tetris bag


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
    } // AIns gudomliga medvetande.


}
