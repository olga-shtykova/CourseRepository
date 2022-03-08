using Module10.ExcersiseTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ExcersiseTasks
{
    public class Worker3 : IWorker
    {
        ILogger Logger { get; }
        public Worker3(ILogger logger)
        {
            Logger = logger;
        }

        public void Work()
        {
            Logger.Event("Worker3 started its work.");
            Thread.Sleep(3000);
            Logger.Event("Worker3 finished its work.");
        }
    }
}
