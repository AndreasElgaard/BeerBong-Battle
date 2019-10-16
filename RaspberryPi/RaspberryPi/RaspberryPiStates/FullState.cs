using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using Sensor;

namespace RaspberryPiStates
{
    public class FullState : RaspberryPiStates
    {
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        Stopwatch time = new Stopwatch();
        public override bool IsFull()
        {
            if (LaserBot.Detected() == false && LaserTop.Detected() == false)
            {
                Console.WriteLine("BeerBong is full and you can start drinking!");
                return true; 
            }
            else
            {
                Console.WriteLine("BeerBong is NOT full and you can't start drinking!");
                return false;
            }
        }

        public void starTimer()
        {
            time.Start();
        }

        public string stopTimer()
        {
            //Stopper stopuret
            time.Stop();
            //Henter tid som er taget som en Timespan værdi
            TimeSpan ts = time.Elapsed;

            // Formaterer tiden til double
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime);

            return elapsedTime;
        }

    }
}
