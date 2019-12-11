using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RaspberryPi.Bluetooth;
using RaspberryPi.Json_Writer;
using RaspberryPi.Writer;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public interface IRaspberryPiStates
    {
        void IsFull(ITimer timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState, IJsonWriter writer);
    }
}
