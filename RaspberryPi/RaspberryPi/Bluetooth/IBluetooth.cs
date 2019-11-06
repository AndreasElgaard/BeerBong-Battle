using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPi.Bluetooth
{
    interface IBluetooth
    {
        void Init();
        void SendData(string data);
        void closeBT();
    }
}
