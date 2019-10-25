using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RaspberryPi.Bluetooth;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public class EmptyState : RaspberryPiStates
    {
        //LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        Bluetooth bt = new Bluetooth();
        public override bool IsFull(MyStopWatch Timer)
        {
            bt.Init();
            Console.WriteLine("This is EmptyState");
            if (LaserTop.Detected() == true)
            {
                bt.SendData("EmptyState - Beerbong is not full");
                Console.WriteLine("BeerBong is NOT full please refill your beerbong");
                return false;
            }
            else
            {
                bt.SendData("Empty state - Beerbong is full");
                Console.WriteLine("BeerBong is full");
                return true;
            }
        }
    }
}
