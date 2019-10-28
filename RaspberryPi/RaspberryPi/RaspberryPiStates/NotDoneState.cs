using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPi.Bluetooth;
using Sensor;
using StopWatch;


namespace RaspberryPiStates
{
    public class NotDoneState : IRaspberryPiStates
    {
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        //LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
        Bluetooth bt = new Bluetooth();

        public bool IsFull(MyStopWatch Timer)
        {
            //bt.Init();
            Console.WriteLine("This is NotDoneState");
            if (LaserBot.Detected() == false)
            {
                //bt.SendData("NotDoneState - You are not finished drinking and timer continues");
                Console.WriteLine("You are not finished drinking - timer continues");
                return false;
            }
            //Also possible just to use an else loop
            if (Magnet.Detected() == false && LaserBot.Detected() == true)
            {
                Console.WriteLine("BeerBong is empty - stop timer");
                string result = Timer.StopTimer();
                //bt.SendData(result);
                return true; 
            }
            else
            {
                throw new Exception("You are not do");
            }
        }
    }
}
