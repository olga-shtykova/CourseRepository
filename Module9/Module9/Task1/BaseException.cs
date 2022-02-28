namespace Task1
{
    public class BaseException : Exception
    {
        public BaseException()
        { }

        public BaseException(string message) : base(message)
        { }

        public BaseException(string exception, Exception innerex) : base(exception, innerex)
        { }
    }
}
