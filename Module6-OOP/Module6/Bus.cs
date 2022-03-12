namespace Module6
{
    public class Bus
    {
        public int? Load;

        public void PrintStatus()
        {
            Console.WriteLine(Load.HasValue ? $"В автобусе {Load.Value} пассажиров."  : "Автобус пуст.");
        }
    }
}
