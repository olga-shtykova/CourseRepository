using Module10.ExcersiseTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ExcersiseTasks
{
    public class NewMessenger : IWhatsApp, IViber
    {
        void IWhatsApp.SendMessage(string message)
        {
            Console.WriteLine("{0} : {1}", "WhatsApp", message);
        }

        void IViber.SendMessage(string message)
        {
            Console.WriteLine("{0} : {1}", "Viber", message);
        }
    }
}
