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
    class Program
    {
        static void Main(string[] args)
        {
            Pi.Init<BootstrapWiringPi>();
            // Get a reference to t
            // he pin you need to use.
            // Both methods below are equivalent
            var GPIO_21 = Pi.Gpio[7];

            //TimeSpan
            GPIO_21.PinMode = GpioPinDriveMode.Input;
            //GPIO_21.ReadValue();
            while (true)
            {
                if (GPIO_21.Read() == false)
                {
                    Console.WriteLine("No laser detected");
                    //System.Threading.Thread.Sleep(1000);
                }
                if (GPIO_21.Read() == true)
                {
                    Console.WriteLine("Laser detected");
                    //System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
