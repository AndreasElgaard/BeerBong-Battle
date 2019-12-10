using System;
using System.CodeDom;
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
    public class NotDoneState : IRaspberryPiStates
    {
        //LaserSensorBottom LaserBot = new LaserSensorBottom(); 
        //MagnetSensor Magnet = new MagnetSensor(); 
        // Bluetooth bt = new Bluetooth();
        //JsonWriter writer = new JsonWriter();
       private double MAX_TIME = 20.00; 

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState, JsonWriter writer)
        {
            try
            {
                //Console.WriteLine("NotDoneState");
                if (context.LaserBot.Detected() == false)
                {
                    //bt.SendData("NotDoneState");
                    context.setState(notDoneState);
                }

                if (context.Magnet.Detected() == false && context.LaserBot.Detected() == true)
                {
                    //bt.Init();
                    string result = null;
                    result = timer.StopTimer();
                    Console.WriteLine(result);
                    //bt.SendData(result);
                    //bt.SendData("EmptyState");
                    writer.JsonWriterFunc("Emptystate", result, "");
                    context.setState(emptyState);
                }

                if (timer.GetTime() > MAX_TIME)
                {
                    throw new InvalidOperationException("TimeOut");
                }
            }
            catch (InvalidOperationException)
            {
                //bt.SendData("TimeoutGoEmptyState");
                writer.JsonWriterFunc("Emptystate", "0", "Timeout");
                context.setState(emptyState);
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
