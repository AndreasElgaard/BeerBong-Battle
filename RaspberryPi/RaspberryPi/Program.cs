using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using System.Timers;
using RaspberryPiStates;
using Sensor;
using RaspberryPi.Bluetooth;

namespace RaspberryPi
{
    public class Program
    {
        static void Main(string[] args)
        {
            MagnetSensor Magnet = new MagnetSensor();
            LaserSensorBottom LaserBot = new LaserSensorBottom();
            LaserSensorTop LaserTop = new LaserSensorTop();
            Context context = new Context();
            RaspberryPiStates.RaspberryPiStates empty = new EmptyState();
            Magnet.Initiate();
            LaserTop.Initiate();
            LaserBot.Initiate();
            while (true)
            {
                while (context.getState() == )
                {
                    if (context.IsFull() == false)
                    {
                        context.setState(new EmptyState());
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        context.setState(new FullState());
                    }
                }

                while (context.getState() == new FullState())
                {
                    if (context.IsFull() == true)
                    {
                        context.setState(new FullState());
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        context.setState(new NotDoneState());
                    }
                }

                while (context.getState() == new NotDoneState())
                {
                    if (context.IsFull() == false)
                    {
                        context.setState(new NotDoneState());
                        Thread.Sleep(5000);
                    }

                    else
                    {
                        context.setState(new EmptyState());
                    }
                }
            }
        }
    }
}
