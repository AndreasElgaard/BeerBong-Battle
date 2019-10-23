using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public abstract class RaspberryPiStates
    {
        public abstract bool IsFull(StopWatch1 Timer);
    }
}
