using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Module8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //throw new ArgumentOutOfRangeException("Сообщение об ошибке");
                throw new RankException("Сообщение об ошибке");
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (RankException ex)
            {
                Console.WriteLine(ex.GetType());
            }   
            finally
            {
                Console.Read();
            }

            //var exception = new Exception();
            //exception.Data.Add("Дата создания исключения : ", DateTime.Now);

            //var ex = new Exception("Собственное исключения")
            //{
            //    HelpLink = "www.google.ru"
            //};

            //try
            //{
            //    int result = Division(7, 0);
            //    Console.WriteLine(result);
            //}
            //catch (Exception e) when (e is DivideByZeroException)
            //{
            //    Console.WriteLine("Произошло исключение.");
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Блок Finally сработал!");
            //}

            Console.ReadKey();
        }

        static int Division(int a, int b)
        {
            return a / b;
        }
    }
}