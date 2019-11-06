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
            Console.WriteLine(elapsedTime); //For testing

            return elapsedTime;
        }
    }
}
