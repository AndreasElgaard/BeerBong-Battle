using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using System.Timers;
using RaspberryPi.Bluetooth;
using RaspberryPi.Bluetooth;
using RaspberryPiStates;
using Sensor;
using StopWatch;

namespace RaspberryPii
{
    public class Program
    {
        static void Main(string[] args)
        {
            Init();
            MyStopWatch timer = new MyStopWatch();
            Context context = new Context();
            IRaspberryPiStates emptyState = new EmptyState();
            IRaspberryPiStates fullState = new FullState();
            IRaspberryPiStates notDoneState = new NotDoneState();
            Bluetooth bt = new Bluetooth();
            bt.Init();
            context.setState(emptyState);
            bt.SendData("EmptyState");
            while (ReferenceEquals(context.getState(),emptyState)
                   || ReferenceEquals(context.getState(), fullState)
                   || ReferenceEquals(context.getState(), notDoneState))
            {
                //context.IsFull(timer, context, emptyState, fullState, notDoneState);
                try
                {
                    context.IsFull(timer, context, emptyState, fullState, notDoneState);
                }
                catch (ArgumentException)
                {
                    bt.SendData("ErrorFullStateGoEmptyState");
                    context.setState(emptyState);
                }
                catch (InvalidOperationException)
                {
                    bt.SendData("TimeoutGoEmptyState");
                    context.setState(emptyState);
                }
                catch (Exception)
                {
                    bt.SendData("ErrorGoEmptyState");
                    context.setState(emptyState);
                }
            }

            void Init()
            {
                MagnetSensor Magnet = new MagnetSensor();
                LaserSensorBottom LaserBot = new LaserSensorBottom();
                LaserSensorTop LaserTop = new LaserSensorTop();
                Magnet.Initiate();
                LaserTop.Initiate();
                LaserBot.Initiate();
            }
        }
    }
}
