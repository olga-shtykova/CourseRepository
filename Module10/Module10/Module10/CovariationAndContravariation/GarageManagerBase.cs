using Module10.ExcersiseTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ExcersiseTasks
{
    public class GarageManagerBase : IGarageManager<Car, Garage>
    {
        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public Garage GetGarageInfo()
        {
            throw new NotImplementedException();
        }
    }
}
