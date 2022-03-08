using Module10.ExcersiseTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ExcersiseTasks
{
    //public class Viber : IMessenger<Phone>
    //{
    //    public Phone DeviceInfo()
    //    {
    //        return null;
    //    }
    //}

    public class Viber<T>: IMessenger<T> where T: Phone, new()
    {
        // Ковариация
        //public T GetDeviceInfo()
        //{
        //    T device = new T();
        //    Console.WriteLine(device);
        //    return new T();
        //}

        // Контрвариация
        public void GetDeviceInfo(T device)
        {
            Console.WriteLine(device.Type);
        }
    }
}
