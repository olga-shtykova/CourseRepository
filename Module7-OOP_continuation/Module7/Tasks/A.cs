using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    class A
    {
        public virtual void Display()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public new void Display()
        {
            Console.WriteLine("B");
        }
    }
    class C : A
    {
        public override void Display()
        {
            Console.WriteLine("C");
        }
    }
    class D : B
    {
        public new void Display()
        {
            Console.WriteLine("D");
        }
    }
    class E : C
    {
        public new void Display()
        {
            Console.WriteLine("E");
        }
    }
}
