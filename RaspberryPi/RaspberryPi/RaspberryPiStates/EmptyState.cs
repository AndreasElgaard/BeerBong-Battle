using System;
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
    public class EmptyState : IRaspberryPiStates
    {
        //LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        Bluetooth bt = new Bluetooth();
        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        { 
            bt.Init();
            //Console.WriteLine("This is EmptyState");
            if (LaserTop.Detected() == true)
            {
                //Console.WriteLine("BeerBong is NOT full please refill your beerbong");
                bt.SendData("This is EmptyState");
                context.setState(emptyState);
                //Thread.Sleep(5000);

            }
            else
            {
                bt.SendData("Empty state - Beerbong is full");
                context.setState(fullState);
                //Console.WriteLine("BeerBong is full");
                //Thread.Sleep(5000);
                
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