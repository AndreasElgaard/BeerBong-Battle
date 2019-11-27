using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using RaspberryPi.Bluetooth;
using RaspberryPi.Json_Writer;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public class FullState : IRaspberryPiStates
    {
        //LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
        //Bluetooth bt = new Bluetooth();
        JsonWriter writer = new JsonWriter();

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        {
            //Console.WriteLine("This is Fullstate");
            if (LaserTop.Detected() == false)
            {
                //bt.SendData("Fullstate");
                context.setState(fullState);
                //Console.WriteLine("BeerBong is full and you can start drinking!");
                //Thread.Sleep(1000);
                return; 
            }

            if (LaserTop.Detected() && Magnet.Detected() == true)
            {
                //bt.Init();
                timer.StartTimer();
                //bt.SendData("NotDoneState");
                writer.JsonWriterFunc("NotDonestate", "0");
                context.setState(notDoneState);
                //Console.WriteLine("You have started drinking START TIMER");
                //Thread.Sleep(1000);
            }
            else
            {
                //bt.SendData("NotFullGOEmptyState");
                //context.setState(emptyState);
                throw new ArgumentException("Error In FullState");
            }
        }
        //public Bluetooth getBT()
        //{
        //    return bt;
        //}

        //public void setBT(Bluetooth bt_)
        //{
        //    bt = bt_;
        //}

    }
}
