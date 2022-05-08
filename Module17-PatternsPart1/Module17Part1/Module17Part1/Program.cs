namespace Module17Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            calculator.PerformInterestCalculation(new StandardAccount() { Type = "Standard", Balance = 5000.00 });
            calculator.PerformInterestCalculation(new SalaryAccount() { Type = "Salary", Balance = 10000.00 });
        }
    }
}
