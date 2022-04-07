using System;
using System.IO;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText(@"D:\Text1.txt");

            var delimiters = new char[] { ',', '.', ' ', '\r', '\n', };
            var noPunctuationText = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var mostCommonWords = noPunctuationText
               .GroupBy(x => x)
               .Select(x => new
               {
                   Word = x.Key,
                   Count = x.Count()
               })
               .OrderByDescending(x => x.Count)
               .Take(10);

            Console.WriteLine("10 слов чаще всего встречающихся в тексте:");
            foreach (var word in mostCommonWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
