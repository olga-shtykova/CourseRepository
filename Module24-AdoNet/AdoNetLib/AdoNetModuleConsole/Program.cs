using AdoNetLib;
using AdoNetLib.Configurations;
using System;
using System.Collections.Generic;
using System.Data;

namespace AdoNetModuleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var connector = new MainConnector();
            var data = new DataTable();

            //var result = connector.ConnectAsync();
            //var result = connector.Connect();

            //if (result)
            //if (result.Result)
            //{
            //    Console.WriteLine("Подключено успешно!");
            //}
            //else
            //{
            //    Console.WriteLine("Ошибка подключения!");
            //}

            //var db = new DbExecutor(connector);
            //var tablename = "NetworkUser";

            //Console.WriteLine("Получаем данные таблицы " + tablename);

            //data = db.SelectAll(tablename);
            //Console.WriteLine($"Количество строк в {tablename}: {data.Rows.Count}");

            //var reader = db.SelectAllCommandReader(tablename);

            //if (reader != null)
            //{
            //    var columnList = new List<string>();

            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        var name = reader.GetName(i);
            //        columnList.Add(name);
            //    }

            //    for (int i = 0; i < columnList.Count; i++)
            //    {
            //        Console.Write($"{columnList[i]}\t");
            //    }
            //    Console.WriteLine();

            //    while (reader.Read())
            //    {
            //        for (int i = 0; i < columnList.Count; i++)
            //        {
            //            var value = reader[columnList[i]];
            //            Console.Write($"{value}\t");
            //        }

            //        Console.WriteLine();
            //    }
            //}


            //Console.WriteLine("Отключаем БД!");
            //connector.DisconnectAsync();

            var manager = new Manager();

            manager.Connect();

            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.add + ": добавление данных");
            Console.WriteLine(Commands.delete + ": удаление данных");
            Console.WriteLine(Commands.update + ": обновление данных");
            Console.WriteLine(Commands.show + ": просмотр данных");

            string command;
            do
            {
                Console.WriteLine("Введите команду:");
                command = Console.ReadLine();
                switch (command)
                {
                    case
                    nameof(Commands.add):
                        {
                            Add();
                            break;
                        }

                    case
                    nameof(Commands.delete):
                        {
                            Delete();
                            break;
                        }
                    case
                    nameof(Commands.update):
                        {
                            Update();
                            break;
                        }
                    case
                    nameof(Commands.show):
                        {
                            Show();
                            break;
                        }
                }
                Console.WriteLine();
            }
            while (command != nameof(Commands.stop));            

            manager.Disconnect();

            Console.ReadKey();
        }

        static void Update()
        {
            var manager = new Manager();

            Console.WriteLine("Введите ваш логин:");
            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для обновления:");
            var newName = Console.ReadLine();

            var count = manager.UpdateUserByLogin(login, newName);

            Console.WriteLine("Строк обновлено" + count);

            manager.ShowData();
        }

        static void Show()
        {
            var manager = new Manager();

            manager.ShowData();
        }

        static void Add()
        {
            var manager = new Manager();

            Console.WriteLine("Введите имя для добавления:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите логин для добавления:");
            var login = Console.ReadLine();

            var cardNumber = new byte[] { 12, 200, 40, 56 };

            manager.AddUser(name, login, cardNumber);            

            manager.ShowData();
        }

        static void Delete()
        {
            var manager = new Manager();

            Console.WriteLine("Введите логин для удаления:");

            var count = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine("Количество удаленных строк " + count);

            manager.ShowData();
        }
    }
}
