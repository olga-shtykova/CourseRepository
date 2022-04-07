using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

namespace QueueExample
{
    class Program
    {
        // объявим потокобезопасную очередь (полностью идентична обычной очереди, но
        // позволяет безопасный доступ
        // из разных потоков)
        public static ConcurrentQueue<string> WordsQueue = new ConcurrentQueue<string>();

        static void Main(string[] args)
        {
            /*
            var queue = new Queue<int>();

            for (int i = 0; i <= 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"{i} зашёл в очередь");
            }
            Console.WriteLine();

            // Посмотрим, кто первый в очереди
            Console.WriteLine($"Первый элемент: {queue.Peek()}");
            Console.WriteLine();

            // Посмотрим всю очередь
            Console.WriteLine($"В очереди {queue.Count} элементов");
            Console.WriteLine();

            Console.WriteLine("Элементы в очереди:");
            foreach (int i in queue)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // достанем элементы из очереди один за другим
            Console.WriteLine();
            var queueLength = queue.Count;
            for (int i = 0; i < queueLength; i++)
                Console.WriteLine($"{queue.Dequeue()} вышел из очереди");
            Console.WriteLine();

            //  Посмотрим, сколько элементов осталось
            Console.WriteLine($"В очереди  {queue.Count} элементов");
            */

            Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в очередь.");
            Console.WriteLine();

            //  запустим обработку очереди в отдельном потоке            

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "peek")
                {
                    if (WordsQueue.TryPeek(out var elem))
                        Console.WriteLine($"Первый элемент в очереди: {elem}");
                }
                else if (input == "pop")
                {
                    StartQueueProcessing();
                }
                else
                {
                    // если не введена - ставим элемент в очередь, как и обычно
                    WordsQueue.Enqueue(input);
                    Console.WriteLine("======>  " + input + " добавлен в очередь");
                }
            }
        }

        // метод, который обрабатывает и разбирает нашу очередь в отдельном потоке
        // ( для выполнения задания изменять его не нужно )
        static void StartQueueProcessing()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (!WordsQueue.IsEmpty)
                {
                    Thread.Sleep(1000);
                    if (WordsQueue.TryDequeue(out var element))
                        Console.WriteLine("======>  " + element + " прошел очередь");
                }

                Console.WriteLine("Очередь пуста.");
                Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в очередь.");

            }).Start();
        }
    }
}
