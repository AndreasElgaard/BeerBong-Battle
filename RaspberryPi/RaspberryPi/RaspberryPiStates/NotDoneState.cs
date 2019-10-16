using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensor;

namespace RaspberryPiStates
{
    public class NotDoneState : RaspberryPiStates
    {
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();

        public override bool IsFull()
        {
            Console.WriteLine("This is NotDoneState");
            if (LaserBot.Detected() && LaserTop.Detected() == true)
            {
                Console.WriteLine("You are not finished drinking!");
                return false;
            }

            if (LaserBot.Detected() == true && LaserTop.Detected() == false)
            {
                Console.WriteLine("We got a problem, this should not happen");
                return false;
            }

            else
            {
                Console.WriteLine("BeerBong is empty");
                return true; 
            }
        }
    }
}
