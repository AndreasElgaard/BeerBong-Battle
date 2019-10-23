using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Sensor;
using RaspberryPiStates;
using RaspberryPi.Bluetooth;
using StopWatch;
using NUnit.Framework;
using RaspberryPi;

namespace TestRaspberryPi
{
    public class TestRaspberryPi
    {
        private ISensor _Sensor ;
        private Program _uut;
        private RaspberryPiStates.RaspberryPiStates _States;
        private StopWatch1 _StopWatch;
        private Bluetooth _Bluetooth; 
        //private LaserSensorBottom uutBotSensor;
        //private LaserSensorTop uutTopSensor;
        [SetUp]
        public void setup()
        {
            //Arrange 
            _Sensor = Substitute.For<ISensor>(); 
            _uut = new Program();
            _States = Substitute.For<RaspberryPiStates.RaspberryPiStates>();
            _StopWatch = Substitute.For<StopWatch1>();
            _Bluetooth = Substitute.For<Bluetooth>(); 
            //uutBotSensor = new LaserSensorBottom();
            //uutTopSensor = new LaserSensorTop();
        }
    }
}
