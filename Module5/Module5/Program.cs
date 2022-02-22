using System;
using System.Text;

namespace Module5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;

            (string name, string lastName, int age, bool hasPet, int numberOfPets,
            string[] petsNames, int numberOfFavColors, string[] favColours) UserInfo;

            UserInfo = GetUser();
            Console.WriteLine();
            Display(UserInfo);

            Console.ReadKey();
        }

        static void Display((string name, string lastName, int age, bool hasPet, int numberOfPets, 
            string[] petsNames, int numberOfFavColors, string[] favColours) UserInfo)
        {
            Console.WriteLine($"Ваше имя: {UserInfo.name}");
            Console.WriteLine($"Ваша фамилия: {UserInfo.lastName}");
            Console.WriteLine($"Ваш возраст: {UserInfo.age}");
            Console.WriteLine($"У вас есть питомец: {UserInfo.hasPet}");

            if (UserInfo.hasPet)
            {
                Console.WriteLine($"Количество питомцев: {UserInfo.numberOfPets}");
                Console.WriteLine("Клички ваших питомцев:");

                foreach (var petName in UserInfo.petsNames)
                {
                    Console.WriteLine(petName);
                }                
            }

            Console.WriteLine($"Количество любимых цветов: {UserInfo.numberOfFavColors}");
            Console.WriteLine("Ваши любимые цвета:");

            foreach (var favcol in UserInfo.favColours)
            {
                Console.WriteLine(favcol);
            }
        }

        static (string name, string lastName, int age, bool hasPet, int numberOfPets, 
            string[] petsNames, int numberOfFavColors, string[] favColours) GetUser()
        {
            (string name, string lastName, int age, bool hasPet, int numberOfPets,
                string[] petsNames, int numberOfFavColors, string[] favColours) UserInfo;

            do
            {
                Console.WriteLine("Введите ваше имя");
                UserInfo.name = Console.ReadLine();
            } while (!CorrectInput(UserInfo.name));

            do
            {
                Console.WriteLine("Введите вашу фамилию");
                UserInfo.lastName = Console.ReadLine();
            } while (!CorrectInput(UserInfo.lastName));            

            string age;
            int intAge;
            do
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();

            } while (!CheckNumber(age, out intAge));

            UserInfo.age = intAge;

            string answer;
            do
            {
                Console.WriteLine("Есть ли у вас питомец? Да или Нет");
                answer = Console.ReadLine();
            } while (!CorrectInput(answer));

            UserInfo.hasPet = answer.ToLower() == "да" ? true : false;

            string petNumber;
            int number;

            if (UserInfo.hasPet)
            {                              
                do
                {
                    Console.WriteLine("Введите количество питомцев цифрами?");
                    petNumber = Console.ReadLine();

                } while (!CheckNumber(petNumber, out number));

                UserInfo.numberOfPets = number;           
                
                UserInfo.petsNames = new string[UserInfo.numberOfPets];
                Console.WriteLine("Введите клички ваших питомцев");
                UserInfo.petsNames = GetArrayFromConsole(UserInfo.numberOfPets);
            }
            else
            {
                UserInfo.numberOfPets = 0;
                UserInfo.petsNames = new string[0]; 
            }                       

            string favcoloursnum;
            int intager;
            do
            {
                Console.WriteLine("Введите количество любимых цветов цифрами");
                favcoloursnum = Console.ReadLine();

            } while (!CheckNumber(favcoloursnum, out intager));

            UserInfo.numberOfFavColors = intager;

            UserInfo.favColours = new string[UserInfo.numberOfFavColors];
            Console.WriteLine("Введите ваши любимые цвета");
            UserInfo.favColours = GetArrayFromConsole(UserInfo.numberOfFavColors);

            return UserInfo;
        }

        static bool CheckNumber(string input, out int number)
        {
            if (int.TryParse(input, out int result))
            {
                if (result > 0)
                {
                    number = result;
                    return true;
                }
            }

            number = 0;
            return false;
        }

        static bool CorrectInput(string input)
        {
            if (input is null || input.Length < 2 || int.TryParse(input, out int result))
            {
                Console.WriteLine("Неправильный ввод, попробуйте еще раз.");
                return false;
            }

            foreach (var item in input)
            {
                if (char.IsDigit(item))
                {
                    Console.WriteLine("Неправильный ввод, попробуйте еще раз.");
                    return false;
                }
            }

            return true;
        }

        static string[] GetArrayFromConsole(int num)
        {
            var array = new string[num];
            for (int i = 0; i < array.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Введите {i + 1}:");
                    array[i] = Console.ReadLine();
                } while (!CorrectInput(array[i]));
            }

            return array;
        }
    }
}
