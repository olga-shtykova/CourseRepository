using DataFinder.DataFinder.BLL;
using System;
using System.Linq;

namespace DataFinder.PLL
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Data Finder v.1.0");
                Console.WriteLine("Отобразить все файлы - нажмите 1");
                Console.WriteLine("Выполнить поиск файла по имени - нажмите 2");


                string inputValue = Console.ReadLine();

                if (inputValue == "1")
                {
                    fileService.GetAllFiles().ToList().ForEach(file =>
                    {
                        Console.WriteLine("Идентификатор: {0}, Имя файла: {1}, Путь: {2}", file.Id, file.Name, file.Path);
                    });
                }

                if (inputValue == "2")
                {
                    Console.Write("Введите имя файла, который хотите найти: ");
                    string fileName = Console.ReadLine();

                    try
                    {
                        var file = fileService.GetFileByFileName(fileName);
                        Console.WriteLine("Идентификатор: {0}, Имя файла: {1}, Путь: {2}", file.Id, file.Name, file.Path);
                    }

                    catch (BusinessRuleException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
