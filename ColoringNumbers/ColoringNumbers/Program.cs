using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ColoringNumbers
{
    class Program
    {
        static readonly Random random = new Random();
        static void Main(string[] args)
        {
            const string helloWorldEng = "Hello World!";
            const string helloWorldRus = "Привет Мир!";            
            const string helloWorldSpn = "Hola el Mundo!";

            var words = new[] { helloWorldEng, helloWorldRus, helloWorldSpn };
            var list = Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>().ToArray();

            do
            {
                foreach (var word in words)
                {
                    foreach (var character in word)
                    {
                        var randomColor = random.Next(list.Count());
                        var charColor = list[randomColor];

                        if (charColor == ConsoleColor.Black)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Debug.WriteLine("The color would have been black now");
                        }
                        else
                        {
                            Console.ForegroundColor = charColor;
                            Debug.WriteLine($"Now the color is {charColor}");
                        }

                        Console.Write(character);
                        Thread.Sleep(150);
                    }

                    Console.WriteLine();
                }
            } while (true);
        }
    }
}
