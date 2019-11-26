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
        //LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        //Bluetooth bt = new Bluetooth();
        JsonWriter writer = new JsonWriter();
        public void IsFull(MyStopWatch Timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        {
            //bt.Init();
            Console.WriteLine("This is EmptyState");
            if (LaserTop.Detected() == true)
            {
                //bt.SendData("EmptyState - Beerbong is not full");
                context.setState(emptyState);
                Console.WriteLine("BeerBong is NOT full please refill your beerbong");
                Thread.Sleep(5000);
                
            }
            else
            {
                //bt.SendData("Empty state - Beerbong is full");
                writer.JsonWriterFunc("Fullstate", 0);
                context.setState(fullState);
                Console.WriteLine("BeerBong is full");
                Thread.Sleep(5000);
                
            }
        }
        
    }
}