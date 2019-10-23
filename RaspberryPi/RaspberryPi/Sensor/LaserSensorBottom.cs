using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensor;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace Sensor
{
    public class LaserSensorBottom : ISensor
    {
        public void Initiate()
        {
            Pi.Init<BootstrapWiringPi>();
        }
        public bool Detected()
        {
            var Laser_Bot = Pi.Gpio[6];
            Laser_Bot.PinMode = GpioPinDriveMode.Input;
            if (Laser_Bot.Read() == true)
            {
                Console.WriteLine("Bottom Laser detected");
                return true;
            }
            else
            {
                Console.WriteLine("No Bottom laser detected");
                return false;
            }
        }
    }
}
