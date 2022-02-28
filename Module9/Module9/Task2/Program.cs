namespace Task2
{
    class Program
    {

        static void Main(string[] args)
        {         
            var sortOrder = new NumberReader();
            sortOrder.SortListEvent += SortSurnamesList;

            try
            {
                sortOrder.GetSortOrder();
            }
            catch (BaseException e)
            {
                Console.WriteLine(ExceptionHandler.GetExceptionMessage(e));
                Console.ReadLine();
            }
            finally
            {
                Console.WriteLine("Блок Finally сработал!");
            }

            Console.ReadLine();
        }

        public static void SortSurnamesList(int input)
        {
            var surnameList = new List<string>();
            surnameList.Add("Ковалёв");
            surnameList.Add("Попов");
            surnameList.Add("Голубь");
            surnameList.Add("Васильева");
            surnameList.Add("Антоненко");

            if (input == 1)
            {
                surnameList.Sort((a, z) => a.CompareTo(z));
                foreach (var surname in surnameList)
                {
                    Console.Write($"{surname} ");                
                }

                Console.WriteLine();
            }
            else
            {
                surnameList.Sort((a, z) => z.CompareTo(a));
                foreach (var surname in surnameList)
                {
                    Console.Write($"{surname} ");
                }

                Console.WriteLine();
            }
        }
    }
}
