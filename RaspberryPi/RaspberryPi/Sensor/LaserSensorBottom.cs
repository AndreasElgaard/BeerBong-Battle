using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace RaspberryPi.Sensor
{
    class LaserSensorBottom
    {
        public void Initiate()
        {
            Pi.Init<BootstrapWiringPi>();
            
        }
        public bool Detect()
        {
            var Laser_Bot = Pi.Gpio[8];
            //TimeSpan
            Laser_Bot.PinMode = GpioPinDriveMode.Input;
            //GPIO_21.ReadValue();
            while (true)
            {
                if (Laser_Bot.Read() == false)
                {
                    Console.WriteLine("No laser detected");
                    //System.Threading.Thread.Sleep(1000);
                    return false;
                }
                if (Laser_Bot.Read() == true)
                {
                    Console.WriteLine("Laser detected");
                    //System.Threading.Thread.Sleep(1000);
                    return true;
                }
            }
        }
    }
}
