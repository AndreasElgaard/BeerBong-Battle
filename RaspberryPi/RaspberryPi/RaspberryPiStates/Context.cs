using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPi.Bluetooth;
using RaspberryPi.Json_Writer;
using RaspberryPi.Writer;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{

    public class Context
    {
        public IRaspberryPiStates _currentState;
        public ISensor Magnet { set; get; }
        public ISensor LaserBot { set; get; }
        public ISensor LaserTop { set; get; }
        public IJsonWriter jsonWriter { set; get; }

        public Context()
        {
            _currentState = new EmptyState();
            Magnet = new MagnetSensor();
            
            LaserBot = new LaserSensorBottom();
            
            LaserTop = new LaserSensorTop();
            
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

        public void IsFull(ITimer timer, Context context, IRaspberryPiStates emptyState,
            IRaspberryPiStates fullState, IRaspberryPiStates notDoneState, IJsonWriter writer)
        {
            _currentState.IsFull(timer, context, emptyState, fullState, notDoneState, writer);
        }
    }
}