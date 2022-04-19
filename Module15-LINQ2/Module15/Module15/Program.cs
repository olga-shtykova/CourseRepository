using System;
using System.Collections.Generic;
using System.Linq;

namespace Module15
{
    class Program
    {
        static void Main(string[] args)
        {
            //  объявляем две коллекции
            var letters = new string[] { "A", "B", "C", "D", "E" };
            var numbers = new int[] { 1, 2, 3 };

            // проводим "упаковку" элементов, сопоставляя попарно
            var q = letters.Zip(numbers, (l, n) => l + n.ToString());

            // вывод
            foreach (var s in q)
                Console.WriteLine(s);

            /*
            var cars = new List<Car>()
            {
               new Car() { Model  = "SX4", Manufacturer = "Suzuki"},
               new Car() { Model  = "Grand Vitara", Manufacturer = "Suzuki"},
               new Car() { Model  = "Jimny", Manufacturer = "Suzuki"},
               new Car() { Model  = "Land Cruiser Prado", Manufacturer = "Toyota"},
               new Car() { Model  = "Camry", Manufacturer = "Toyota"},
               new Car() { Model  = "Polo", Manufacturer = "Volkswagen"},
               new Car() { Model  = "Passat", Manufacturer = "Volkswagen"},
            };

            
            var manufacturers = new List<Manufacturer>()
            {
               new Manufacturer() { Country = "Japan", Name = "Suzuki" },
               new Manufacturer() { Country = "Japan", Name = "Toyota" },
               new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
            };

            //var result = from car in cars
            //             join m in manufacturers on car.Manufacturer equals m.Name
            //             select new
            //             {
            //                 Name = car.Model,
            //                 Manufacturer = m.Name,
            //                 Country = m.Country,
            //             };

            var result  = cars.Join(manufacturers, // передаем в качестве параметра вторую коллекцию
                           car => car.Manufacturer, // указываем общее свойство для первой коллекции
                           m => m.Name, // указываем общее свойство для второй коллекции
                           (car, m) =>
                               new // проекция в новый тип
                               {
                                   Name = car.Model,
                                   Manufacturer = m.Name,
                                   Country = m.Country,
                               });

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");

            Console.WriteLine();

            // Выборка + группировка
            var result2 = manufacturers.GroupJoin(
               cars, // первый набор данных
               m => m.Name, // общее свойство второго набора
               car => car.Manufacturer, // общее свойство первого набора
               (m, crs) => new  // результат выборки
   {
                   Name = m.Name,
                   Country = m.Country,
                   Cars = crs.Select(c => c.Model),
               });
            
            foreach (var m in result2)
            {
                Console.WriteLine(m.Name + ":");

                foreach (var car in m.Cars)
                    Console.WriteLine(car);

                Console.WriteLine();
            }
            */

            /*
            // Список напитков в продаже
            string[] drinks = { "Вода", "Кока-кола", "Лимонад", "Вино" };
            // Алкогольные напитки
            string[] alcohol = { "Вино", "Пиво", "Сидр" };

            // Убираем алкоголь из ассортимента
            var drinksForKids = drinks.Except(alcohol);

            foreach (string drink in drinksForKids)
                Console.WriteLine(drink);
            */
        }
    }
}
