using System;
using System.Threading;
using NUnit.Framework;
using NSubstitute;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
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
        private IRaspberryPiStates _states;
        
        private MyStopWatch _stopWatch;

        private IBluetooth _bluetooth;
        
        private Context _context;
        //private IRaspberryPiStates _emptyState;
        private IRaspberryPiStates _emptyState; 
        private IRaspberryPiStates _fullState;
        private IRaspberryPiStates _notDoneState;

        private ISensor _laserBot;
        private ISensor _laserTop;
        private ISensor _magnet;
        
        

        [SetUp]
        public void setup()
        {
            //Arrange 
            _states = Substitute.For<IRaspberryPiStates>();

            _bluetooth = Substitute.For<IBluetooth>();

            _laserBot = Substitute.For<ISensor>();
            _laserTop = Substitute.For<ISensor>();
            _magnet = Substitute.For<ISensor>();

            _stopWatch = Substitute.For<MyStopWatch>();

            _context = Substitute.For<Context>();
            //_emptyState = new EmptyState();
            _emptyState = Substitute.For<EmptyState>();
            //_fullState = new FullState();
            _fullState = Substitute.For<FullState>();
            //_notDoneState = new NotDoneState();
            _notDoneState = Substitute.For<NotDoneState>();
        }

        #region States

        [Test]
        public void Test_GetState_isEqual_to_emptystate()
        {
            _context.setState(_emptyState);
            IRaspberryPiStates result = _context.getState();
            Assert.That(result, Is.EqualTo(_emptyState));
        }
        [Test]
        public void Test_GetState_isEqual_to_fullState()
        {
            _context.setState(_fullState);
            IRaspberryPiStates result = _context.getState();
            Assert.That(result, Is.EqualTo(_fullState));
        }
        [Test]
        public void Test_GetState_isEqual_to_NotDoneState()
        {
            _context.setState(_notDoneState);
            IRaspberryPiStates result = _context.getState();
            Assert.That(result, Is.EqualTo(_notDoneState));
        }

        [Test]
        public void Test_LaserBot_returns_false()
        {
            bool result = false;
            _laserBot.Detected().Returns(result );
            Assert.That(_laserBot.Detected, Is.EqualTo(result));
        }

        [Test]
        public void Test_LaserBot_returns_true()
        {
            _laserBot.Detected().Returns(true);
            Assert.That(_laserBot.Detected, Is.EqualTo(true));
        }

        [Test]
        public void Test_EmptySate_returnsTrue_when_topAndBot_sensor_isFalse()
        {
            _context.setState(_emptyState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            _laserBot.Detected().Returns(false);
            _laserTop.Detected().Returns(false);
            _magnet.Detected().Returns(false);
            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState);
            Assert.That(_context.getState(), Is.EqualTo(_emptyState));
        }

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

        [Test]
        public void bluetoothReceived()
        {
            IRaspberryPiStates _full = Substitute.For<IRaspberryPiStates>();
            IRaspberryPiStates _notdone = Substitute.For<IRaspberryPiStates>();

            _states.getBT().Returns(_bluetooth);

            _states.IsFull(_stopWatch, _context, _states, _full,_notdone);

            _bluetooth = _states.getBT();

            _bluetooth.Received().SendData(Arg.Any<string>());
        }

        #endregion
        }
}

