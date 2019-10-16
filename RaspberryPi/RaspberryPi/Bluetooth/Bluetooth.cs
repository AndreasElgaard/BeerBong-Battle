using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJCP.IO.Ports;

namespace RaspberryPi.Bluetooth
{
    class Bluetooth
    {
        private SerialPortStream bt;
        public void Init()
        {
            bt = new SerialPortStream("/dev/rfcomm0", 9600, 8, RJCP.IO.Ports.Parity.None, RJCP.IO.Ports.StopBits.One);
            bt.Open();

        }

        public void SendByte(byte[] a)
        {
            bt.Write(a,0,8);
        }

        public int ReceviceByte()
        {
            if (bt.BytesToRead != 0)
            {
                int data;
                data = bt.ReadByte();
                return data;
            }
            else
            {
                return -1;
            }
        }
    }
}
