using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7.Tasks
{
    public class ElectricCar : Car<ElectricEngine>
    {
        public override void ChangePart<TCarPart>(TCarPart newPart)
        {
            throw new NotImplementedException();
        }
    }

    public class GasCar : Car<GasEngine>
    {
        public override void ChangePart<TCarPart>(TCarPart newPart)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Car<TEngine> where TEngine : Engine
    {
        public TEngine Engine;

        public abstract void ChangePart<TCarPart>(TCarPart newPart) where TCarPart : CarPart;        
    }

    public class ElectricEngine : Engine
    { 

    }

    public class GasEngine : Engine
    {
        
    }

    public class Battery : CarPart
    {

    }

    public class Differential : CarPart
    {

    }

    public class Wheel : CarPart
    {
    
    }

    public abstract class Engine { }
    public abstract class CarPart { }
}
