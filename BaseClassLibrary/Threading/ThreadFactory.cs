using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BaseClassLibrary.Reflection;

namespace BaseClassLibrary.Threading
{
    /// <summary>
    /// Create different concrete thread by different ThreadName
    /// </summary>
    public class ThreadFactory<T>
    {
        /// <summary>
        /// Create different concrete thread by different ThreadName
        /// </summary>
        public static ParentThread<T> createThread(string FullThreadName, CancellationTokenSource _tokenSource, ICloneable _threadParameter)
        {
            ParentThread<T> thread ;
            thread = ObjectBuildFactory<ParentThread<T>>.Instance(FullThreadName, new object[] { _tokenSource, _threadParameter });
            return thread;
        }
    }
}
