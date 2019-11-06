using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPi.Bluetooth
{
    public interface IBluetooth
    {
        int Init();
        void SendData(string data);
        string ReceviceByte();
        void closeBT();
    }
}
