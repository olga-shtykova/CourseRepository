using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ExcersiseTasks.Interfaces
{
    //public interface IMessenger<T>
    //{
    //    T DeviceInfo();
    //}

    /* Слово out указывает, что интерфейс IMessenger теперь является ковариантным. */
    //public interface IMessenger<out T>
    //{
    //    T GetDeviceInfo();
    //}

    /* Контрвариация в интерфейсах реализуется через слово in */
    public interface IMessenger<in T>
    {
        void GetDeviceInfo(T device);
    }
}
