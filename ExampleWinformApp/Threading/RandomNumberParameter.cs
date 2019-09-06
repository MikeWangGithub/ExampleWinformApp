using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWinformApp.Threading
{
    public class RandomNumberParameter : ICloneable
    {
        // add own properties
        //......
        public int Max;
        public int Min;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
