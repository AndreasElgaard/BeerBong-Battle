using System;
using System.Threading;
using NUnit.Framework;
using NSubstitute;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using RaspberryPi;
using RaspberryPi.Bluetooth;
using RaspberryPi.Json_Writer;
using RaspberryPi.Writer;
using RaspberryPiStates;
using Sensor;
using StopWatch;

namespace RaspberryPiUnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        private IRaspberryPiStates _states;
        
        private ITimer _stopWatch;

        private IBluetooth _bluetooth;
        
        private Context _context;
        //private IRaspberryPiStates _emptyState;
        private IRaspberryPiStates _emptyState; 
        private IRaspberryPiStates _fullState;
        private IRaspberryPiStates _notDoneState;

        private ISensor _laserBot;
        private ISensor _laserTop;
        private ISensor _magnet;

        private IJsonWriter _writer;

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

            _writer = Substitute.For<IJsonWriter>();

            _context.LaserBot = _laserBot;
            _context.LaserTop = _laserTop;
            _context.Magnet = _magnet;
            _context.jsonWriter = _writer;
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
        public void Test_Fullstate_returnsTrue_when_topAndBot_sensor_isFalse()
        {
            _context.setState(_emptyState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            _laserBot.Detected().Returns(false);
            _laserTop.Detected().Returns(false);
            _magnet.Detected().Returns(false);
            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
            Assert.That(_context.getState(), Is.EqualTo(_fullState));
        }

        [Test]
        public void Test_NotDoneState_returnsTrue()
        {
            _context.setState(_fullState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            _laserBot.Detected().Returns(false);
            _laserTop.Detected().Returns(true);
            _magnet.Detected().Returns(true);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
            Assert.That(_context.getState(), Is.EqualTo(_notDoneState));
        }

        [Test]
        public void EmptyState_returnsTrue()
        {
            _context.setState(_notDoneState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            _laserBot.Detected().Returns(true);
            _laserTop.Detected().Returns(true);
            _magnet.Detected().Returns(false);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
            Assert.That(_context.getState(), Is.EqualTo(_emptyState));
        }

        [Test]
        public void Empty_Stays_True()
        {
            _context.setState(_emptyState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            _laserBot.Detected().Returns(true);
            _laserTop.Detected().Returns(true);
            _magnet.Detected().Returns(false);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
            Assert.That(_context.getState(), Is.EqualTo(_emptyState));
        }

        [Test]
        public void FullState_Stays_True()
        {
            _context.setState(_fullState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            _laserBot.Detected().Returns(false);
            _laserTop.Detected().Returns(false);
            _magnet.Detected().Returns(false);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
            Assert.That(_context.getState(), Is.EqualTo(_fullState));
        }

        [Test]
        public void NotDone_Stays_True()
        {
            _context.setState(_notDoneState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            _laserBot.Detected().Returns(false);
            _laserTop.Detected().Returns(true);
            _magnet.Detected().Returns(true);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
            Assert.That(_context.getState(), Is.EqualTo(_notDoneState));
        }

        [Test]
        public void Emptystate_IsFull_Reveived()
        {
            _context.setState(_emptyState);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _emptyState.Received(1).IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
        }

        [Test]
        public void Fullstate_IsFull_Reveived()
        {
            _context.setState(_notDoneState);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _notDoneState.Received(1).IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
        }

        [Test]
        public void NotDonestate_IsFull_Reveived()
        {
            _context.setState(_fullState);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _fullState.Received(1).IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);
        }

        [Test]
        public void FullState_Exception_Thrown()
        {
            _context.setState(_fullState);

            _laserTop.Detected().Returns(true);
            _laserBot.Detected().Returns(false);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _writer.Received().JsonWriterFunc("Emptystate", "0", "Fullstate error");
        }

        [Test]
        public void NotDoneState_Exception_Timeout()
        {
            _stopWatch = Substitute.For<ITimer>();
            _context.setState(_notDoneState);

            _magnet.Detected().Returns(true);
            _laserBot.Detected().Returns(true);

            _stopWatch.GetTime().Returns(25.0);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);


            _writer.Received().JsonWriterFunc("Emptystate", "0", "Timeout");
        }
        #endregion

        #region Timer

        [TestCase("02.23")]
        public void Test_timer_returns_right_value(string a)
        {
            _stopWatch.StartTimer();
            Thread.Sleep(2234);
            string result = _stopWatch.StopTimer();
            Assert.That(a, Is.EqualTo(result));
        }

        [TestCase(1.0)]
        public void Test_get_time(double time)
        {
            _stopWatch.StartTimer();
            Thread.Sleep(1000);
            double result = _stopWatch.GetTime();
            _stopWatch.StopTimer();

            Assert.That(result, Is.EqualTo(01.00));
        }



        #endregion

        #region Sensor

        [Test]
        public void LaserTop_Detected_Empty()
        {
            _context.setState(_emptyState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            //_laserBot.Detected().Returns(false);
            //_laserTop.Detected().Returns(false);
            //_magnet.Detected().Returns(false);
            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _laserTop.Received(1).Detected();
        }

        [Test]
        public void LaserBot_Detected_NotDone()
        {
            _context.setState(_notDoneState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            //_laserBot.Detected().Returns(false);
            //_laserTop.Detected().Returns(false);
            //_magnet.Detected().Returns(false);
            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _laserBot.Received().Detected();
        }

        [Test]
        public void Magnet_Detected_FullState()
        {
            _context.setState(_fullState);
            //_stopWatch.StartTimer();
            //string result = _stopWatch.StopTimer();
            //_laserBot.Detected().Returns(false);
            _laserTop.Detected().Returns(true);
            //_magnet.Detected().Returns(false);
            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _magnet.Received(1).Detected();
        }

        #endregion

        #region Writer

        [Test]
        public void JsonWriter_Writer_Received()
        {
            _context.setState(_emptyState);
            _laserTop.Detected().Returns(false);

            _context.IsFull(_stopWatch, _context, _emptyState, _fullState, _notDoneState, _writer);

            _writer.Received().JsonWriterFunc("Fullstate", "0", "");
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

