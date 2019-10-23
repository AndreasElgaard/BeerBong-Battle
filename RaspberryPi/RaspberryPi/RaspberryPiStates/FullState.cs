using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using Sensor;

namespace RaspberryPiStates
{
    public class FullState : RaspberryPiStates
    {
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
        StopWatch.StopWatch Timer = new StopWatch.StopWatch();
        public override bool IsFull()
        {
            Console.WriteLine("This is Fullstate");
            if (LaserTop.Detected() == false)
            {
                Console.WriteLine("BeerBong is full and you can start drinking!");
                return true; 
            }

            if (Magnet.Detected() == true)
            {
                Timer.StartTimer();
                Console.WriteLine("You have started drinking START TIMER");
                return false;
            }
            else
            {
                Console.WriteLine("This should not happen");
                return true; 
            }
        }

    }
}
