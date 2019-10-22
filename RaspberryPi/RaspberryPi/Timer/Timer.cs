﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    public class StopWatch
    {
        Stopwatch time = new Stopwatch();
        public void StartTimer()
        {
            time.Start();
        }

        public string StopTimer()
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