using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresidentOliverLee
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

    class President
    {
        public string name;
        int environmentPriority;
        int defensePriority;
        int healthcarePriority;
        int corruption;
        int money;
        Random generator = new Random();

        public President(string n)
        {
            name = n;
            environmentPriority = generator.Next(0, 100);
            defensePriority = generator.Next(0, 100);
            healthcarePriority = generator.Next(0, 100);

        }
        public void Present()
        {
            Console.Clear();
            Console.WriteLine(name);
            Console.WriteLine("\nEnvironment priority: " + environmentPriority);
            Console.WriteLine("Defense priority: " + defensePriority);
            Console.WriteLine("Healthcare priority: " + healthcarePriority);
            Console.WriteLine("Corruption: " + corruption + "\n");
        }
        public bool PassLegislation(int e, int d, int h, int bribe)
        {
            money += bribe;
            environmentPriority += bribe;
            defensePriority += bribe;
            healthcarePriority += bribe;
            corruption += bribe / 10;

            if (e < environmentPriority && d < defensePriority && h < healthcarePriority)
            {
                return true;
            }

            return false;
        }
    }

    class Land
    {
        Random generator = new Random();

        public int population;
        public int BNP;
        public float BNPperCap;
        public int skatt;
        public int area;

        public string name;

        public Land(string n)
        {
            name = n;

            population = generator.Next(1000000, 10000000);
            skatt = generator.Next(0, 40);
            area = generator.Next(50000, 500000);
            BNP = generator.Next(Convert.ToInt32(Math.Pow(10, 7)), Convert.ToInt32(Math.Pow(10, 8)));
            BNPperCap = BNP / population;
        }
        public void Present()
        {
            Console.Clear();
            Console.WriteLine(name);
            Console.WriteLine("\n Population: " + population);
            Console.WriteLine("Skatt: " + skatt + "%");
            Console.WriteLine("Area: " + area + "km²");
            Console.WriteLine("BNP: " + BNP + "USD" + "\n");
            Console.WriteLine("BNP Per Capita: " + BNPperCap + "USD");
        }

    }
}
