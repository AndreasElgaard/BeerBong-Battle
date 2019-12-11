using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPi.Writer
{
    public interface IJsonWriter
    {
        void JsonWriterFunc(string context, string time, string comment);
    }
}
