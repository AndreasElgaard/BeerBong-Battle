using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unosquare.WiringPi;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace RaspberryPi.Bluetooth
{
    public class Bluetooth
    {
        private SerialPort Bt;


        public void Init()
        {
            Bt = new SerialPort("/dev/rfcomm0",9600);
            Bt.Open();
        }

        public void SendData(string data)
        {
            Bt.WriteLine(data);
        }

        public string ReceviceByte()
        {
            if (Bt.ReadBufferSize != 0)
            {
                string data;
                data = Bt.ReadLine();
                return data;
            }

            return "No data received";

        }

        public void closeBT()
        {
            Bt.Close();
        }
    }
}
