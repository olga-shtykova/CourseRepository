using System;
using System.Collections;

namespace ArrayListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ArrayList() { 2, "Lol" };

            list.Add(2.3); // добавим double
            list.Add(55); // добавим int
            list.AddRange(new string[] { "Hello", "world" }); // добавим массив

            // выведем, что получилось
            foreach (var item in list)
                Console.WriteLine(item);

            Console.WriteLine();

            // добавим ещё строку
            list.Add("again!");

            // отрежем часть длиной в 3 элемента, начиная с четвертого
            var slice = list.GetRange(4, 3);

            // выведем результат
            foreach (var item in slice)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
