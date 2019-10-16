using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RaspberryPiStates
{
    public abstract class RaspberryPiStates
    {
        public abstract bool IsFull();
        public abstract double Timer(); 
    }
}
