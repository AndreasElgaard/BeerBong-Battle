using System;
using System.Threading;
using NUnit.Framework;
using NSubstitute;
using NUnit.Framework;
using RaspberryPi;
using RaspberryPi.Bluetooth;
using RaspberryPiStates;
using Sensor;
using StopWatch;

namespace RaspberryPiUnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        
        private ISensor _Sensor;
        private Program _uut;
        private IRaspberryPiStates _states;
        
        private MyStopWatch _stopWatch;
        private IBluetooth _bluetooth;
        private Context _context;
        private LaserSensorBottom _laserBot;
        private LaserSensorTop _laserTop;
        private MagnetSensor _magnet;
        private ITimer _timer;

        [SetUp]
        public void setup()
        {
            //Arrange 
            _Sensor = Substitute.For<ISensor>();
            _uut = new Program();
            _states = Substitute.For<RaspberryPiStates.IRaspberryPiStates>();
            _context = Substitute.For<Context>();
            _stopWatch = Substitute.For<MyStopWatch>();
            _bluetooth = Substitute.For<IBluetooth>();
            _laserBot = Substitute.For<LaserSensorBottom>();
            _laserTop = Substitute.For<LaserSensorTop>();
            _magnet = Substitute.For<MagnetSensor>();
            _timer = Substitute.For<MyStopWatch>();
        }

        #region States

        [Test]
        public void Test_GetState_isEqual_to_emptystate()
        {
            RaspberryPiStates.IRaspberryPiStates emptyState = new EmptyState();
            _context.setState(emptyState);
            RaspberryPiStates.IRaspberryPiStates result = _context.getState();
            Assert.That(result, Is.EqualTo(emptyState));
        }
        [Test]
        public void Test_GetState_isEqual_to_fullState()
        {
            RaspberryPiStates.IRaspberryPiStates fullState = new FullState();
            _context.setState(fullState);
            RaspberryPiStates.IRaspberryPiStates result = _context.getState();
            Assert.That(result, Is.EqualTo(fullState));
        }
        [Test]
        public void Test_GetState_isEqual_to_NotDoneState()
        {
            RaspberryPiStates.IRaspberryPiStates notDoneState = new NotDoneState();
            _context.setState(notDoneState);
            RaspberryPiStates.IRaspberryPiStates result = _context.getState();
            Assert.That(result, Is.EqualTo(notDoneState));
        }

        //[Test]
        //public void Test_EmptySate_returnsTrue_when_topAndBot_sensor_isFalse()
        //{
        //    //_laserTop.Initiate();
        //    //_laserBot.Initiate();
        //    RaspberryPiStates.IRaspberryPiStates emptyState = new EmptyState();
        //    _context.setState(emptyState);
        //    _stopWatch.StartTimer();
        //    _stopWatch.StopTimer();
        //    _laserBot.Detected().Returns(false);
        //    _laserTop.Detected().Returns(false);
        //    Assert.IsTrue(_context.IsFull(_stopWatch));
        //}

        [TestCase("02.23")]
        public void Test_timer_returns_right_value(string a)
        {
            _stopWatch.StartTimer();
            Thread.Sleep(2234);
            string result = _stopWatch.StopTimer();
            Assert.That(a, Is.EqualTo(result));
        }

        #endregion

        #region bluetooth
        /*
        [Test]
        public void bluetoothReceived()
        {
            IRaspberryPiStates _full = Substitute.For<IRaspberryPiStates>();
            IRaspberryPiStates _notdone = Substitute.For<IRaspberryPiStates>();

            _states.getBT().Returns(_bluetooth);

            _states.IsFull(_stopWatch, _context, _states, _full,_notdone);

            _bluetooth = _states.getBT();

            _bluetooth.Received().SendData(Arg.Any<string>());
        }*/

        #endregion
        }
}

