using Module10.ExcersiseTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ExcersiseTasks
{
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }
    }
}
