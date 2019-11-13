using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        {
            bt.Init();
            Console.WriteLine("This is NotDoneState");
            if (LaserBot.Detected() == false)
            {
                bt.SendData("NotDoneState - You are not finished drinking and timer continues");
                context.setState(notDoneState);
                //Console.WriteLine("You are not finished drinking - timer continues");
                //Thread.Sleep(1000);
            }
            //Also possible just to use an else loop
            if (Magnet.Detected() == false && LaserBot.Detected() == true)
            {
                string result = null;
                result = timer.StopTimer();
                Console.WriteLine(result);
                bt.SendData(result);
                context.setState(emptyState);
                //Console.WriteLine("BeerBong is empty - stop timer");
                Thread.Sleep(5000);
            }
            else
            {
                context.setState(notDoneState);
            }
        }
        public Bluetooth getBT()
        {
            return bt;
        }
        public void setBT(Bluetooth bt_)
        {
            bt = bt_;
        }
    }
}
