namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exceptionArray = new Exception[]
            { 
                new ArgumentException(),
                new DivideByZeroException(),
                new IndexOutOfRangeException(),
                new FileNotFoundException(),
                new BaseException("My exception message."),
            };

            for (int i = 0; i < exceptionArray.Length; i++)
            {
                try
                {
                    throw exceptionArray[i];
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (DivideByZeroException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (FileNotFoundException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (BaseException exception)
                {
                    Console.WriteLine(ExceptionHandler.GetExceptionMessage(exception));
                }
                finally
                {
                    Console.WriteLine("Блок Finally сработал!");
                }         
            }                       

            Console.ReadLine();
        }
    }
}
