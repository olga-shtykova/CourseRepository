using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
{
    public class Record<T1, T2>
    {
        public T1 Id;
        public DateTime Date;
        public T2 Value;
    }
}
