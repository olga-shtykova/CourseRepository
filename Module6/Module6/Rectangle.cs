namespace Module6
{
    public class Rectangle
    {
        public int a;
        public int b;

        public Rectangle()
        {
            a = 6;
            b = 4;
        }

        public Rectangle(int parameter)
        {
            a = parameter;
            b = parameter;
        }

        public Rectangle(int parameter1, int parameter2)
        {
            a = parameter1;
            b = parameter2;
        }

        public int Square(int a, int b)
        {
            return a * b;
        }
    }
}
