﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using RaspberryPiStates;

namespace Sensor
{
    public class MagnetSensor : ISensor
    {
        public void Initiate()
        {
            Pi.Init<BootstrapWiringPi>();
        }
        public bool Detected()
        {
            var magnet = Pi.Gpio[17];
            //TimeSpan
            magnet.PinMode = GpioPinDriveMode.Input;
            //GPIO_21.ReadValue();
            if (magnet.Read() == true)
            {
                Console.WriteLine("Magnet detected");
                return true;
            }

            else 
            {
                Console.WriteLine("No mangnet detected");
                return false;
            }
        }
    }
}
