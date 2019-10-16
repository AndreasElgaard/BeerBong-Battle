using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPiStates
{

    public class Context
    {
        private RaspberryPiStates _currentState;

        public Context()
        {
            _currentState = new EmptyState();
        }

        public void setState(RaspberryPiStates state)
        {
            _currentState = state;
        }

        public RaspberryPiStates getState()
        {
            return _currentState;
        }

        public bool IsFull()
        {
            _currentState.IsFull();
            return false;
        }
    }
}