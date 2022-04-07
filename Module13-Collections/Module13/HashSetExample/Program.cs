using System;
using System.Collections.Generic;

namespace HashSetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Создаем массив строк
            string[] names =  
            {
               "Игорь",   // повторяющееся значение
               "Андрей",
               "Васиий",
               "София",
               "Елена",
               "Анна",
               "Игорь",  //  повторяющееся значение
           };

            // Выведем длину массива в консоль
            Console.WriteLine("Длина массива: " + names.Length);
            Console.WriteLine();
            Console.WriteLine("Данные в массиве:");
            foreach (var n in names)
                Console.WriteLine(n);
            Console.WriteLine();

            // Создаем хэш-сет, передавая в конструктор наш массив
            var hSet = new HashSet<string>(names);

            // Посчитаем объекты в массиве
            Console.WriteLine("Длина хэш-сета: " + hSet.Count);
            Console.WriteLine();

            // Выведем все элементы в консоль и посмотрим, есть ли дубликаты
            Console.WriteLine("Элементы в хэшсете:");
            foreach (var n in hSet)
                Console.WriteLine(n);
            Console.WriteLine();

            hSet.UnionWith(new[] { "Дмитрий", "Сергей", "Игорь" });
            Console.WriteLine("Элементы после объединения с новой коллекцией:");

            foreach (var n in hSet)
                Console.WriteLine(n);
            */

            /*
            // Создадим два множества
            var lettersOne = new SortedSet<char>() { 'A', 'B', 'C', 'Z', };
            var lettersTwo = new SortedSet<char>() { 'X', 'Y', 'Z', };
                       
            PrintCollection(lettersOne, "Первая коллекция: ");
            PrintCollection(lettersTwo, "Вторая коллекция");

            //  Выполним вычитание множеств.
            // ExceptWith Удаляет из хэш - сета все элементы, содержащиеся в другой коллекции.
            lettersOne.ExceptWith(lettersTwo);

            PrintCollection(lettersOne, "Результат вычитания");
            */

            /*
            var hSet = new HashSet<string>() { "Иван", "Дмитрий" };

            // SymmetricExceptWith исключает дубликаты на уровне обеих коллекций.
            hSet.SymmetricExceptWith(new[] { "Дмитрий", "Сергей", "Игорь" });
            Console.WriteLine("Элементы после объединения с новой коллекцией:");

            foreach (var n in hSet)
                Console.WriteLine(n);
            */

            // Сохраняем предложение в строку
            var sentence = "Подсчитайте, сколько уникальных символов в этом предложении, используя HashSet<T>, учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.";

            // сохраняем в массив char
            var characters = sentence.ToCharArray();
            var symbols = new HashSet<char>();

            foreach (var symbol in characters)
            {
                symbols.Add(symbol);
            }

            Console.WriteLine($"Символов со знаками препинания: {symbols.Count}");
            Console.WriteLine();

            // сохраняем знаки препинания в массив Char
            var signs = new[] { ' ', ',', '.' };

            // сохраняем числовые символы в массив Char
            var numbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            //  Проверяем, есть ли цифры
            var containsNumbers = symbols.Overlaps(numbers);
            Console.WriteLine($"Коллекция содержит цифры? - {containsNumbers}");
            Console.WriteLine();

            // Отбрасываем знаки препинания и заново считаем
            symbols.ExceptWith(signs);
            Console.WriteLine($"Символов без знаков препинания: {symbols.Count}");

            Console.ReadKey();
        }

        static void PrintCollection(SortedSet<char> ss, string s)
        {
            Console.WriteLine(s);
            foreach (var ch in ss)
                Console.Write(ch + " ");
            Console.WriteLine("\n");
        }
    }
}
