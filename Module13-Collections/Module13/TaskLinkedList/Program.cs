using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TaskLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = (@"D:\Text1.txt");
            var linkedList = new LinkedList<string>();

            try
            {
                if (File.Exists(filePath))
                {                    
                    var stopWatch2 = Stopwatch.StartNew();
                    using (var streamReader = File.OpenText(filePath))
                    {
                        var text = "";
                        while ((text = streamReader.ReadLine()) != null)
                        {
                            linkedList.AddLast(text);
                        }
                    }

                    Console.WriteLine($"Вставка в LinkedList<T> заняла: {stopWatch2.Elapsed.TotalMilliseconds} мс.");
                }
                else
                {
                    Console.WriteLine("Файл не существует.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Произошла ошибка {exception.Message}.");
            }
        }
    }
}
