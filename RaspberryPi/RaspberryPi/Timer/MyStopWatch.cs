using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    public class MyStopWatch : ITimer
    {
        Stopwatch time = new Stopwatch();
        public void StartTimer()
        {
            time.Reset();
            time.Start();
        }

        /// <summary>
        /// Stop timer, og returner tid i en string
        /// </summary>
        /// <returns></returns>
        public string StopTimer()
        {
            string elapsedTime = null;
            TimeSpan ts = TimeSpan.Zero;
            //Stopper stopuret
            time.Stop();
            //Henter tid som er taget som en Timespan værdi
            ts = time.Elapsed;
            // Formaterer tiden til double
            elapsedTime = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            //Console.WriteLine(elapsedTime); //For testing

            return elapsedTime;
        }
        /// <summary>
        /// Watchdog for NotDoneException
        /// </summary>
        /// <returns></returns>
        public double GetTime()
        {
            TimeSpan ts = TimeSpan.Zero;
            ts = time.Elapsed;
            string elapsedTime = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds / 10);
            double result = double.Parse(elapsedTime);
            //Console.WriteLine(result); //for testing
            return result;
        }

    }
}
