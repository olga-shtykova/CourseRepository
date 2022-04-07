using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = (@"D:\Text1.txt");
            var list = new List<string>();

            try
            {
                if (File.Exists(filePath))
                {
                    var stopWatch1 = Stopwatch.StartNew();
                    using (var streamReader = File.OpenText(filePath))
                    {
                        var text = "";
                        while ((text = streamReader.ReadLine()) != null)
                        {
                            list.Add(text);
                        }
                    }

                    Console.WriteLine($"Вставка в List<T> заняла: {stopWatch1.Elapsed.TotalMilliseconds} мс.");
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
