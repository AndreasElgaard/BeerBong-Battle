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
        MagnetSensor Magnet = new MagnetSensor();
        StopWatch.StopWatch Timer = new StopWatch.StopWatch();

        public override bool IsFull()
        {
            Console.WriteLine("This is NotDoneState");
            if (Magnet.Detected() == false)
            {
                if (LaserBot.Detected() == false)
                {
                    Console.WriteLine("You are not finished drinking - timer continues");
                    return false;
                }
            }
            //Also possible just to use an else loop
            if (Magnet.Detected() == false && LaserBot.Detected() == true)
            {
                Timer.StopTimer();
                Console.WriteLine("BeerBong is empty - stop timer");
                return true; 
            }

            return false; 
        }
    }
}
