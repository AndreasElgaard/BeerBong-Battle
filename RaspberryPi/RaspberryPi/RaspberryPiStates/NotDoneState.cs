using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPi.Bluetooth;
using Sensor;



namespace RaspberryPiStates
{
    public class NotDoneState : RaspberryPiStates
    {
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
        StopWatch.StopWatch Timer = new StopWatch.StopWatch();
        Bluetooth bt = new Bluetooth();

        public override bool IsFull()
        {
            bt.Init();
            Console.WriteLine("This is NotDoneState");
            if (Magnet.Detected() && LaserBot.Detected() == false)
            {
                bt.SendBData("NotDoneState - You are not finished drinking and timer continues");
                Console.WriteLine("You are not finished drinking - timer continues");
                return false;
            }
            //Also possible just to use an else loop
            if (Magnet.Detected() == false && LaserBot.Detected() == true)
            {
                string result = Timer.StopTimer();
                bt.SendBData(result);
                Console.WriteLine("BeerBong is empty - stop timer");
                return true; 
            }

            return false; 
        }
    }
}
