using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StopWatch;

namespace RaspberryPiStates
{

    public class Context
    {
        public IRaspberryPiStates _currentState;

        public Context()
        {
            _currentState = new EmptyState();
        }

        public void setState(IRaspberryPiStates state)
        {

            _currentState = state;
        }

        public IRaspberryPiStates getState()
        {
            return _currentState;
        }

        public bool IsFull(MyStopWatch timer)
        {
            return _currentState.IsFull(timer);
        }
    }
}