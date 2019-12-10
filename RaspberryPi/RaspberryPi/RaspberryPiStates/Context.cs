using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPi.Bluetooth;
using RaspberryPi.Json_Writer;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{

    public class Context
    {
        public IRaspberryPiStates _currentState;
        public MagnetSensor Magnet;
        public LaserSensorBottom LaserBot;
        public LaserSensorTop LaserTop;
        public JsonWriter jsonWriter;

        public Context()
        {
            _currentState = new EmptyState();
            Magnet = new MagnetSensor();
            Magnet.Initiate();
            LaserBot = new LaserSensorBottom();
            LaserBot.Initiate();
            LaserTop = new LaserSensorTop();
            LaserTop.Initiate();
            jsonWriter = new JsonWriter();
        }

        public void setState(IRaspberryPiStates state)
        {

            _currentState = state;
        }

        public IRaspberryPiStates getState()
        {
            return _currentState;
        }

        public void IsFull(MyStopWatch timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState, JsonWriter writer)
        {
            _currentState.IsFull(timer, context, emptyState, fullState, notDoneState, writer);
        }
    }
}