namespace Module6
{
    public class Triangle
    {
		private int a;
		private int b;
		private int c;

        public int A
        {
            get
            {
                return a;
            }
            set
            {
                if (value > 0 && b + c > value)
                    a = value;
            }
        }

        public int B 
        {
            get
            {
                return b;
            }
            set
            {
                if (value > 0 && a + c > value)
                    b = value;
            }
        }
		public int C 
        {
            get
            {
                return c;
            }
            set
            {
                if (value > 0 && a + b > value)
                    c = value;
            }
        }

		public double Area()
		{
			throw new NotImplementedException();
		}

		public double Perimeter()
		{
			throw new NotImplementedException();
		}
	}
}
