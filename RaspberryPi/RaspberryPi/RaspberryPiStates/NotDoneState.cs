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
            //Console.WriteLine("This is NotDoneState");
            if (LaserBot.Detected() == false)
            {
                //bt.SendData("NotDoneState");
                context.setState(notDoneState);
                //Console.WriteLine("You are not finished drinking - timer continues");
                //Thread.Sleep(1000);
            }
            //Also possible just to use an else loop
            if (Magnet.Detected() == false && LaserBot.Detected() == true)
            {
                bt.Init();
                string result = null;
                result = timer.StopTimer();
                Console.WriteLine(result);
                bt.SendData(result);
                bt.SendData("EmptyState");
                context.setState(emptyState);
                //Console.WriteLine("EmptyState");
                //Thread.Sleep(5000);
            }

            if (timer.GetTime() > 20.00)
            {
                //context.setState(emptyState);
                throw new Exception("Error In fullstate - time went out");
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
