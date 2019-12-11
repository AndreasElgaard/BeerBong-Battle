using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using RaspberryPi.Bluetooth;
using RaspberryPi.Json_Writer;
using RaspberryPi.Writer;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public class FullState : IRaspberryPiStates
    {
        //LaserSensorTop LaserTop = new LaserSensorTop();
       //MagnetSensor Magnet = new MagnetSensor();
        //Bluetooth bt = new Bluetooth();
        //JsonWriter writer = new JsonWriter();

        public void IsFull(ITimer timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState, IJsonWriter writer)
        {
            try
            {
                //Console.WriteLine("Fullstate");
                if (context.LaserTop.Detected() == false)
                {
                    //bt.SendData("Fullstate");
                    context.setState(fullState);
                    return;
                }

                if (context.LaserTop.Detected() && context.Magnet.Detected() == true)
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
            catch (ArgumentException)
            {
                writer.JsonWriterFunc("Emptystate", "0", "Fullstate error");
                context.setState(emptyState);
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
}
