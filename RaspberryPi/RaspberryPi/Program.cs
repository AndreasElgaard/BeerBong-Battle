using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPi.Sensor;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using RaspberryPiStates;
using Sensor;

namespace RaspberryPi
{
    class Program
    {
        private LaserSensor LaserTop;
        private LaserSensorBottom LaserBot;
        private MagnetSensor MagSen;
        private RaspberryPiStates.RaspberryPiStates currentState_;

        static void Main(string[] args)
        {
            

        }

        public void Init()
        {
            LaserTop = new LaserSensor();
            LaserBot = new LaserSensorBottom();
            MagSen = new MagnetSensor();
            currentState_ = new EmptyState();

        }
    }
}
