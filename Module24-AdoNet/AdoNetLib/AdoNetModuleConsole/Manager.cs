using AdoNetLib;
using System;
using System.Data;

namespace AdoNetModuleConsole
{
    public class Manager
    {
        private MainConnector connector;
        private DbExecutor dbExecutor;
        private Table userTable;

        public Manager()
        {
            connector = new MainConnector();

            userTable = new Table();
            userTable.Name = "NetworkUser";
            userTable.ImportantField = "Login";
            userTable.Fields.Add("Id");
            userTable.Fields.Add("Login");
            userTable.Fields.Add("Name");
        }

        public void Connect()
        {
            var result = connector.ConnectAsync();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                dbExecutor = new DbExecutor(connector);
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }
        }

        public void Disconnect()
        {
            Console.WriteLine("Отключаем БД!");
            connector.DisconnectAsync();
        }

        public void ShowData()
        {
            var tablename = "NetworkUser";

            Console.WriteLine("Получаем данные таблицы " + tablename);

            var data = dbExecutor.SelectAll(tablename);

            Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

            Console.WriteLine();
            foreach (DataColumn column in data.Columns)
            {
                Console.Write($"{column.ColumnName}\t");
            }

            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {

                var cells = row.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write($"{cell}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public int DeleteUserByLogin(string value)
        {
            dbExecutor = new DbExecutor(connector);
            return dbExecutor.DeleteByColumn(userTable.Name, userTable.ImportantField, value);
        }

        public void AddUser(string name, string login)
        {
            dbExecutor = new DbExecutor(connector);
            dbExecutor.ExecProcedureAdding(name, login);
        }

        public int UpdateUserByLogin(string columnValue, string newvalue)
        {
            dbExecutor = new DbExecutor(connector);
            return dbExecutor.UpdateByColumn(userTable.Name, userTable.ImportantField, columnValue, userTable.Fields[2], newvalue);
        }
    }
}
