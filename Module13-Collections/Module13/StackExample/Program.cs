using System;
using System.Collections.Generic;

namespace StackExample
{
    class Program
    {
        private static Stack<string> Words = new Stack<string>();

        static void Main(string[] args)
        {
            /*
            Stack<int> numbers = new Stack<int>();

            numbers.Push(3);
            numbers.Push(5);
            numbers.Push(8);

            Console.WriteLine("Элементы числового стека: ");
            foreach (var number in numbers)
                Console.WriteLine(number);

            Console.WriteLine($"Просматриваемый верхний элемент стека: {numbers.Peek()}");            
            Console.WriteLine($"Извлекаем верхний элемент из стека: {numbers.Pop()}");
            Console.WriteLine();
            Console.WriteLine("В стеке остались числа:");
            foreach (var number in numbers)
                Console.WriteLine(number);
            Console.WriteLine();            

            Stack<Person> persons = new Stack<Person>();
            persons.Push(new Person() { Name = "Иван" });
            persons.Push(new Person() { Name = "Сергей" });
            persons.Push(new Person() { Name = "Анна" });

            Console.WriteLine("Элементы стека объектов: ");
            foreach (Person p in persons)
                Console.WriteLine(p.Name);

            Console.WriteLine($"Извлекаем верхний элемент из стека объектов: {persons.Pop().Name}");
            Console.WriteLine("В стеке остались объекты:");
            foreach (Person p in persons)
                Console.WriteLine(p.Name);

            Console.ReadKey();
            */

            Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в стек.");
            Console.WriteLine();

            while (true)
            {
                var input = Console.ReadLine();

                Words.Push(input); // Изменить здесь


                Console.WriteLine();
                Console.WriteLine("В стеке:");

                PrintStack(Words);
            }
        }           
        
        public static void PrintStack(Stack<string> stack)
        {
            Console.WriteLine("В стеке:");
            foreach (var word in Words)            
                Console.WriteLine(" " + word);            
        }
    }
}
