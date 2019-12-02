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
using RaspberryPi.Json_Writer;
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
            //Bluetooth bt = new Bluetooth();
            //bt.Init();
            JsonWriter writer = new JsonWriter();
            context.setState(emptyState);
            writer.JsonWriterFunc("Emptystate", "0", "Start");
            //bt.SendData("EmptyState");
            while (ReferenceEquals(context.getState(),emptyState)
                   || ReferenceEquals(context.getState(), fullState)
                   || ReferenceEquals(context.getState(), notDoneState))
            {
                try
                {
                    context.IsFull(timer, context, emptyState, fullState, notDoneState);
                }
                catch (ArgumentException)
                {
                    //bt.SendData("ErrorFullStateGoEmptyState");
                    writer.JsonWriterFunc("Emptystate", "0", "Fullstate error");
                    context.setState(emptyState);
                }
                catch (InvalidOperationException)
                {
                    //bt.SendData("TimeoutGoEmptyState");
                    writer.JsonWriterFunc("Emptystate", "0", "Timeout");
                    context.setState(emptyState);
                }
                catch (Exception)
                {
                    //bt.SendData("ErrorGoEmptyState");
                    writer.JsonWriterFunc("Emptystate", "0", "ProgramCrash");
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
