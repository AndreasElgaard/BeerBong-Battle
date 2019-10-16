using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Sensor;

namespace RaspberryPiStates
{
    public abstract class RaspberryPiStates
    {
        private int currentState = 0;
        public abstract bool IsFull();

        public void SetState(int index)
        {
            currentState = index; 
        }
    }
}
