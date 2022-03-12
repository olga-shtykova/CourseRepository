using System;
using System.Text;

namespace Module4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;

            (string name, string lastName, double age, string login, int loginLength, bool hasPet, string[] favouriteColours) user;
            int count = 0;
            do
            {
                Console.WriteLine("Введите имя");
                user.name = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                user.lastName = Console.ReadLine();
                Console.WriteLine("Введите логин");
                user.login = Console.ReadLine();
                user.loginLength = user.login.Length;

                Console.WriteLine("Есть ли у вас животные? Да или Нет");
                string answer = Console.ReadLine();
                user.hasPet = answer.ToLower() == "Да" ? true : false;

                Console.WriteLine("Введите возраст пользователя");
                user.age = double.Parse(Console.ReadLine());

                user.favouriteColours = new string[3];
                Console.WriteLine("Введите три любимых цвета пользователя");

                for (int i = 0; i < user.favouriteColours.Length; i++)
                {
                    user.favouriteColours[i] = Console.ReadLine();
                }
            } while (count < 3);

            Console.ReadKey();            
        }
    }
}
