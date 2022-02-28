namespace Task2
{
    public class ExceptionHandler
    {
        public static string GetExceptionMessage(BaseException exception)
        {
            return exception.Message;
        }
    }
}
