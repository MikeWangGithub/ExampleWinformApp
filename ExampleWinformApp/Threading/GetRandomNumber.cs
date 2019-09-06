using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BaseClassLibrary.Threading;

namespace ExampleWinformApp.Threading
{
    public class GetRandomNumber : ParentThread<int>
    {
        private RandomNumberParameter param;
        public GetRandomNumber(CancellationTokenSource _tokenSource, ICloneable _threadParameter):base(_tokenSource, _threadParameter)
        {
            if (this.ThreadParameter != null)
            {
                param = (RandomNumberParameter)this.ThreadParameter;

            }
        }
        public override bool CheckParameter()
        {
            //throw new NotImplementedException();
            return true;
        }

        public override int RunSubThread(ICloneable ThreadParameter)
        {
            this.IsTaskCanceled();
            RandomNumberParameter  param;
            if (ThreadParameter != null)
            {
                param = (RandomNumberParameter)ThreadParameter;
            }
            else
            {
                return default(int);
            }
            Random ran = new Random((int)System.DateTime.Now.Ticks);
            int min = param.Min;
            int max = param.Max;
            if(max<min)
            {
                max = min;
            }
            return ran.Next(min, max + 1);
        }
    }

    
}
