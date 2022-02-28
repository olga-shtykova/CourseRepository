using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BaseException : FormatException
    {
        public BaseException()
        { }

        public BaseException(string message) : base(message)
        { }

        public BaseException(string exception, Exception innerex) : base(exception, innerex)
        { }
    }
}
