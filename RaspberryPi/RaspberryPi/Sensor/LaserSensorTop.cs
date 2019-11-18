using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace Sensor
{
    public class LaserSensorTop : ISensor
    {
        public void Initiate()
        {
            Pi.Init<BootstrapWiringPi>();
        }
        public bool Detected()
        {
            var Laser_Top = Pi.Gpio[4];
            Laser_Top.PinMode = GpioPinDriveMode.Input;
            if (Laser_Top.Read() == true)
            {
                //Console.WriteLine("Top Laser detected");
                return true;
            }
            else
            {
                //Console.WriteLine("No top laser detected");
                return false;
            }
        }
    }
}

