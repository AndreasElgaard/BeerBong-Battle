using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using RaspberryPiStates;
using Sensor;

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
            Magnet.Initiate();
            LaserTop.Initiate();
            LaserBot.Initiate();

            while (true)
            {
                while (true)
                {
                    if (context.IsFull() == false)
                    {
                        context.IsFull();
                        context.setState(new EmptyState());
                    }
                    else
                    {
                        context.IsFull();
                        context.setState(new FullState());
                        break; 
                    }
                }
                Console.WriteLine("Congratulatio" +
                                  "ns");
                context.IsFull();
                break; 
                //if (context.IsFull() == true)
                //{
                //    emptyState.IsFull();
                //    context.setState(new FullState());
                //}

                //if (fullState.IsFull() == true)
                //{

                //}
            }
        }
    }
}
