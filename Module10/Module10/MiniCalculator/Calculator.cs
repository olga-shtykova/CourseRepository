using MiniCalculator.Interfaces;

namespace MiniCalculator
{    
    public class Calculator : ICalculator
    {
        private readonly ILogger Logger;
        public Calculator(ILogger logger)
        {
            Logger = logger;
        }
        public int SumTwoNumbers(int number1, int number2)
        {
            Logger.LogEvent($"Складываем два числа: {number1} и {number2}.");
            return number1 + number2;
        }
    }
}
