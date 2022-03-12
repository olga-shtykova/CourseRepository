using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ExceptionHandler
    {
        public static string GetExceptionMessage(BaseException exception)
        {
            return exception.Message;
        }
    }
}
