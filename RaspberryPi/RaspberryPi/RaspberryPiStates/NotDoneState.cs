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
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        //LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
       // Bluetooth bt = new Bluetooth();
       JsonWriter writer = new JsonWriter();
        private double MAX_TIME = 20.00; 

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        {
            //Console.WriteLine("This is NotDoneState");
            if (LaserBot.Detected() == false)
            {
                //bt.SendData("NotDoneState");
                context.setState(notDoneState);
                //writer.JsonWriterFunc("Notdonestate", "pistid");
                //Console.WriteLine("You are not finished drinking - timer continues");
                //Thread.Sleep(1000);
            }
            //Also possible just to use an else loop
            if (Magnet.Detected() == false && LaserBot.Detected() == true)
            {
                //bt.Init();
                string result = null;
                result = timer.StopTimer();
                Console.WriteLine(result);
                //bt.SendData(result);
                //bt.SendData("EmptyState");
                writer.JsonWriterFunc("Emptystate", result, "");
                context.setState(emptyState);
                Console.WriteLine("EmptyState");
                //Thread.Sleep(5000);
            }

            if (timer.GetTime() > MAX_TIME)
            {
                throw new InvalidOperationException("TimeOut");

                //bt.SendData("TimeoutGOEmptyState");
                //context.setState(emptyState);
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
