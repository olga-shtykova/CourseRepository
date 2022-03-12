namespace Module6
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new Bus() { Load = 27};
            bus.PrintStatus();

            var department = GetCurrentDepartment();

            if (department?.Company?.Type == "Банк" && department?.City?.Name == "Санкт-Петербург")
            {
                Console.WriteLine("У банка {0} есть отделение в Санкт-Петербурге.", department?.Company?.Name ?? "Неизвестная компания");
            }

            Console.ReadKey();
        }

        static Department GetCurrentDepartment()
        {
            return new Department()
            {
                Company = new Company() { Name = "Приор", Type = "Банк"},
                City = new City() { Name = "Санкт-Петербург" },
            };
        }
    }
}
