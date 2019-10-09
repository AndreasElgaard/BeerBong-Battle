using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPiStates
{
    class EmptyState : RaspberryPiStates
    {
        public override bool IsFull()
        {
            return false;
        }

        public override double Timer()
        {
            return -1;
        }
    }
}
