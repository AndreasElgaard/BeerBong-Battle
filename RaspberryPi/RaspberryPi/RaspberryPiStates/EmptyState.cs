using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RaspberryPiStates
{
    class EmptyState : RaspberryPiStates

    {
        public override bool IsFull()
        {
            return true; 
        }

        public override double Timer()
        {
            return -1;
        }
    }
}
