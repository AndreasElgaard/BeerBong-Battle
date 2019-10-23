using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Sensor;

namespace RaspberryPiStates
{
    public class EmptyState : RaspberryPiStates
    {
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        public override bool IsFull()
        {
            Console.WriteLine("This is EmptyState");
            if (LaserTop.Detected() == true)
            {
                Console.WriteLine("BeerBong is NOT full please refill your beerbong");
                return false;
            }
            if (LaserBot.Detected() == true)
            {
                Console.WriteLine("BeerBong is NOT full please refill your beerbong");
                return false;
            }
            else
            {
                Console.WriteLine("BeerBong is full");
                return true;
            }
        }
    }
}
