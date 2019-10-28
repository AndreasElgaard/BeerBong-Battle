using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    public interface ITimer
    {
        void StartTimer();
        string StopTimer(); 
    }
}
