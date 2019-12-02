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
        LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
        //Bluetooth bt = new Bluetooth();
        JsonWriter writer = new JsonWriter();

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        {
            //Console.WriteLine("Fullstate");
            if (LaserTop.Detected() == false)
            {
                //bt.SendData("Fullstate");
                context.setState(fullState);
                return; 
            }

            if (LaserTop.Detected() && Magnet.Detected() == true)
            {
                timer.StartTimer();
                //Bluetooth
                //bt.Init();
                //bt.SendData("NotDoneState");
                writer.JsonWriterFunc("NotDonestate", "0", "");
                context.setState(notDoneState);
            }
            else
            {
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
