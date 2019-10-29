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

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        {
            _currentState.IsFull(timer, context, emptyState, fullState, notDoneState);
        }
    }
}