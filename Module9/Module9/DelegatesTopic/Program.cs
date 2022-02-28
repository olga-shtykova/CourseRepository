namespace DelegatesTopic
{
    public class Car
    {
        public string Model { get; set; }
    }
    public class BMW : Car 
    {        
    }

    class Program
    {
        /*Delegates*/
        //public delegate int SumDelegate(int a, int b, int c);
        //public delegate int CalculateDelegate(int a, int b);
        //public delegate void CalcDelegate(int a, int b);
        //public delegate void ShowDelegate();

        //delegate void ShowMessageDelegate();
        //delegate int SumDelegate(int a, int b, int c);
        //delegate bool CheckLengthDelegate(string _row);

        /*Ananymous methods*/
        //public delegate string GreetingsDelegate(string name);
        //delegate int RandomNumberDelegate();
        //delegate int CalculateSum(int a, int b, int c);

        /*ковариантность и контравариантность*/
        delegate Car CarDelegate(string name);
        delegate void BwmInfo(BMW bwm);

        static void Main(string[] args)
        {
            /*ковариантность и контравариантность*/
            BwmInfo bmwInfo = GetCarInfo; // контравариантность
            BMW bwm = new BMW
            {
                Model = "X6"
            };
            bmwInfo(bwm);

            CarDelegate carDelegate;
            carDelegate = BuildBMW; // ковариантность
            Car c = carDelegate("X6");
            Console.WriteLine(c.Model);
            Console.Read();

            /*Lambda expressions*/
            //CalculateSum calculate = (a, b, c) => a + b + c;
            //Console.WriteLine(calculate(1, 2, 3));
            //Console.WriteLine(calculate(1, 1, 1));

            //RandomNumberDelegate randomNumberDelegate = () =>
            //{
            //    return new Random().Next(0, 100);
            //};
            //int res = randomNumberDelegate.Invoke();
            //Console.WriteLine(res);

            /*Ananymous methods*/
            //RandomNumberDelegate randomNumber = delegate ()
            //{
            //    return new Random().Next(0, 100);
            //};

            //var result = randomNumber.Invoke();
            //Console.WriteLine(result);


            //string message = "добро пожаловать на SkillFactory!";
            //GreetingsDelegate gd = delegate (string name)
            //{
            //    return $"Привет, { name } {message}";
            //};
            //string GreetingsMessage = gd.Invoke("Будущий гуру");
            //Console.WriteLine(GreetingsMessage);

            /*Delegates Func, Action, Predicate*/
            //ShowMessageDelegate showMessageDelegate = ShowMessage;
            //showMessageDelegate.Invoke();
            //Action showMessageDelegate = ShowMessage;
            //showMessageDelegate.Invoke();

            //SumDelegate sumDelegate = Sum;
            //int result = sumDelegate.Invoke(1, 30, 120);
            //Console.WriteLine(result);
            //Func<int, int, int, int> sumDelegate = Sum;
            //int result = sumDelegate.Invoke(1, 30, 120);
            //Console.WriteLine(result);

            //CheckLengthDelegate checkLengthDelegate = CheckLength;
            //bool status = checkLengthDelegate.Invoke("skill_factory");
            //Console.WriteLine(status);
            //Predicate<string> checkLengthDelegate = CheckLength;
            //bool status = checkLengthDelegate.Invoke("skill_factory");
            //Console.WriteLine(status);

            /*Delegates*/
            //ShowDelegate showDelegate1 = ShowMessage1;
            //showDelegate1 += ShowMessage2;

            //ShowDelegate showDelegate2 = ShowMessage3;
            //showDelegate2 += ShowMessage4;

            //ShowDelegate showDelegate3 = showDelegate1 + showDelegate2;

            //showDelegate3.Invoke();

            //SumDelegate sumDelegate = Sum; 
            //Console.WriteLine(sumDelegate.Invoke(1, 10, 50));

            //CalcDelegate calcDelegate = SubtractIntegers;
            //calcDelegate += SumIntegers;
            //calcDelegate -= SubtractIntegers;
            //calcDelegate.Invoke(10, 50);

            //ShowDelegate showDelegate = ShowMessage1;
            //showDelegate += ShowMessage2;
            //showDelegate += ShowMessage3;
            //showDelegate += ShowMessage4;

            //showDelegate.Invoke();

            //var myClass = new MyClass();
            //myClass.Process();
            Console.ReadKey();
        }

        private static void GetCarInfo(Car p)
        {
            Console.WriteLine(p.Model);
        }
        private static BMW BuildBMW(string model)
        {
            return new BMW { Model = model };
        }

        static int RandomNumber()
        {
            return new Random().Next(0, 100);
        }

        static void ShowMessage()
        {
            Console.WriteLine("Hello World!");
        }

        static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        static bool CheckLength(string _row)
        {
            if (_row.Length > 3) return true;
            return false;
        }
       
        static int Calculate(int a, int b)
        {
            return a - b;
        }

        static void SumIntegers(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void SubtractIntegers(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        static void ShowMessage1()
        {
            Console.WriteLine("Метод 1");
        }

        static void ShowMessage2()
        {
            Console.WriteLine("Метод 2");
        }

        static void ShowMessage3()
        {
            Console.WriteLine("Метод 3");
        }

        static void ShowMessage4()
        {
            Console.WriteLine("Метод 4");
        }
    }
}
