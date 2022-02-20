namespace Module7
{
    public class DerivedClass : BaseClass
    {
        private readonly string? Description;

        private readonly int Counter;

        public override int Counter1 
        { 
            get             
            { 
                return Counter; 
            }
            set
            {
                if (value >= 0)
                {
                    Counter1 = value;
                }
            }
        }

        public DerivedClass()
        {

        }
        public DerivedClass(string name, string description) : base(name)
        {
            Description = description;
        }

        public DerivedClass(string name, string description, int counter) : base(name)
        {
            Description = description;
            Counter = counter;
        }

        public override sealed void Display()
        {
            base.Display();
            Console.WriteLine("Метод класса DerivedClass");
        }

        public new void NewDisplay()
        {
            Console.WriteLine("Метод класса DerivedClass");
        }
    }
}
