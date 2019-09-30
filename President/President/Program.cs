using System;
using System.Collections.Generic;

namespace President
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var landList = new List<Land>();

            Console.WriteLine("How many countries u want to make?");
            int.TryParse(Console.ReadLine(), out int antalLand);

            for (int i = 0; i < antalLand; i++)
            {
                Console.Clear();
                Console.WriteLine("Name country nr: " + (i + 1));
                landList.Add(new Land(Console.ReadLine()));
                Console.Clear();
            }

            Console.WriteLine("Name the president!");
            President obama = new President(Console.ReadLine());
            Console.Clear();

            while (true)
            {
                Console.WriteLine("1: Present presídent");
                Console.WriteLine("2: Hey man do u want to pass new law?!");
                Console.WriteLine("3: Present country");

                var keyRead = Console.ReadKey(true).Key;
                if (keyRead == ConsoleKey.D1)
                {
                    obama.Present();
                }
                else if (keyRead == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("How much u care about environment? 0-100");
                    int.TryParse(Console.ReadLine(), out int eCare);
                    Console.WriteLine("How much u care about healthcare? 0-100");
                    int.TryParse(Console.ReadLine(), out int hCare);
                    Console.WriteLine("How much u care about defense? 0-100");
                    int.TryParse(Console.ReadLine(), out int dCare);
                    Console.WriteLine("Do u want to bribe el presidente? 0-100");
                    int.TryParse(Console.ReadLine(), out int bribe);

                    obama.PassLegislation(eCare, dCare, hCare, bribe);

                    if (obama.PassLegislation(eCare, dCare, hCare, bribe))
                    {
                        Console.WriteLine("\nThe legislation passed!");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else Console.WriteLine("\nThe legislation didn't pass!");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (keyRead == ConsoleKey.D3)
                {
                    Console.WriteLine("222");
                    for (int i = 0; i < antalLand; i++)
                    {
                        Console.WriteLine("dsdsdsdsdsdssd");
                        landList.ForEach(item => item.Present());
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}