namespace Module7
{
    public class BaseClass
    {
        protected string Name;

        public virtual int Counter1 { get; set; }

        public BaseClass()
        {

        }
        public BaseClass(string name)
        {
            Name = name;
        }

        public virtual void Display()
        {
            Console.WriteLine("Метод класса BaseClass");
        }

        public virtual void NewDisplay()
        {
            Console.WriteLine("Метод класса BaseClass");
        }
    }
}
