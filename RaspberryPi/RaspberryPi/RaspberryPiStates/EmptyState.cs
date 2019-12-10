using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RaspberryPi.Bluetooth;
using RaspberryPi.Json_Writer;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public class EmptyState : IRaspberryPiStates
    {
        //LaserSensorTop LaserTop = new LaserSensorTop();
        //Bluetooth bt = new Bluetooth();
        //JsonWriter writer = new JsonWriter();
        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState, JsonWriter writer)
        {
            //Console.WriteLine("EmptyState");
            if (context.LaserTop.Detected() == true)
            {
                //bt.SendData("EmptyState");
                context.setState(emptyState);
            }
            else
            {
                //bt.Init();
                //bt.SendData("FullState");
                writer.JsonWriterFunc("Fullstate", "0", "");
                context.setState(fullState);
            }
        }

    //    public Bluetooth getBT()
    //    {
    //        return bt;
    //    }

    //    public void setBT(Bluetooth bt_)
    //    {
    //        bt = bt_;
    //    }
    }
}