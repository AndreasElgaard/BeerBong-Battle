using System;
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
            bool result = false;
            int counter = 0; 
            var magneticGpioPin = Pi.Gpio[6];
            magneticGpioPin.PinMode = GpioPinDriveMode.Input;

            while (counter > 1)
            {
                if (magneticGpioPin.Read() == true)
                {
                    counter++;
                }
            }
            return result; 
        }
    }
}
