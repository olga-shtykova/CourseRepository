using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void Notify();  // делегат
    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // событие

        public void StartProcess()
        {
            Console.WriteLine("Процесс начат!");
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted() //protected virtual method
        {
            ProcessCompleted?.Invoke();
        }
    }
}
