namespace Task2
{
    public class NumberReader
    {
        public delegate void SortList(int number);
        public event SortList SortListEvent;
               
        public void GetSortOrder()
        {
            Console.WriteLine("Введите число 1 или 2");
            var input = Convert.ToInt32(Console.ReadLine());

            if (input != 1 && input != 2)
            {
                throw new BaseException("Введено неправильное значение.");
            }

            SortOrder(input);            
        }

        protected virtual void SortOrder(int number)
        {
            SortListEvent?.Invoke(number);
        }
    }
}
