﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using RaspberryPi.Bluetooth;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public class FullState : IRaspberryPiStates
    {
        //LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
        Bluetooth bt = new Bluetooth();

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState)
        {
            bt.Init();
            Console.WriteLine("This is Fullstate");
            if (LaserTop.Detected() == false)
            {
                bt.SendData("Fullstate - Beerbong is ready");
                context.setState(fullState);
                Console.WriteLine("BeerBong is full and you can start drinking!");
                //Thread.Sleep(1000);
                return; 
            }

            if (LaserTop.Detected() && Magnet.Detected() == true)
            {
                timer.StartTimer();
                bt.SendData("Fullstate - You have started drinking");
                context.setState(notDoneState);
                Console.WriteLine("You have started drinking START TIMER");
                //Thread.Sleep(1000);
                //return false;
            }
            else
            {
                Console.WriteLine("This should not happen");
                throw new Exception ("error in fullstate");
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