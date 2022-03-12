namespace MiniCalculator
{
    class Program
    {
        static Logger Logger { get; set; }
        static void Main() 
        {
            Logger = new Logger();
            try
            {
                Console.WriteLine("Введите первое число:");
                var number1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите второе число:");
                var number2 = Convert.ToInt32(Console.ReadLine());

                var calculator = new Calculator(Logger);
                var result = calculator.SumTwoNumbers(number1, number2);
                Console.WriteLine($"Результат сложения: {result}");
            }
            catch (FormatException e)
            {
                Logger.LogError($"Введено неправильное значение: {typeof(Exception)}, {e.Message}.");                
            }
            catch(Exception e)
            {
                Logger.LogError($"Произошла ошибка {typeof(Exception)}, {e.Message}.");
            }
            finally
            {
                Console.WriteLine("Программа завершила свою работу.");
            }
          
            Console.ReadKey();
        }

    }
}
