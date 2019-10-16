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
    public class Program
    {
        public LaserSensorTop LaserTop;
        private LaserSensorBottom LaserBot;
        private MagnetSensor MagSen;
        private RaspberryPiStates.RaspberryPiStates currentState_;

        static void Main(string[] args)
        {
            //Program start = new Program();
            //start.Init();
            MagnetSensor Magnet = new MagnetSensor();
            LaserSensorBottom LaserBot = new LaserSensorBottom();
            LaserSensorTop LaserTop = new LaserSensorTop();
            Magnet.Initiate();
            Magnet.Detected();
        }
        public void Init()
        {
            LaserTop = new LaserSensorTop();
            LaserBot = new LaserSensorBottom();
            MagSen = new MagnetSensor();
            currentState_ = new EmptyState();
        }
    }
}
