using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaspberryPi.Websocket;

namespace RaspberryPi.Json_Writer
{
    public class JsonWriter
    {
        public void JsonWriterFunc(string context, string time, string comment)
        {
            //MyWebsocket socket;
            //socket.Init();
            //var filename = @"home\pi\test.json";
            //var file = await StorageFile.GetFileFromPathAsync(filename);
            //if(File.Exists("/home/pi/prj4/webapi/package.json"))
            //  File.Delete("/home/pi/prj4/webapi/package.json");
            switch (context)
            {
                case ("Emptystate"):
                    List<Data> _data = new List<Data>();
                    _data.Add(new Data()
                    {
                        name = "BeerBong",
                        state = "Emptystate",
                        time = time,
                        comment = comment
                    });

                    string json = JsonConvert.SerializeObject(_data.ToArray());

                    //socket.SendToWebsocket(json);

                    File.WriteAllText("/home/pi/prj4/webapi/package.json", json);
                    break;

                case ("Fullstate"):
                    List<Data> _dataF = new List<Data>();
                    _dataF.Add(new Data()
                    {
                        name = "BeerBong",
                        state = "Fullstate",
                        time = time
                    });

                    string jsonF = JsonConvert.SerializeObject(_dataF.ToArray());

                    //socket.SendToWebsocket(jsonF);

                    File.WriteAllText("/home/pi/prj4/webapi/package.json", jsonF);
                    break;

                case ("NotDonestate"):
                    List<Data> _dataN = new List<Data>();
                    _dataN.Add(new Data()
                    {
                        name = "BeerBong",
                        state = "NotDonestate",
                        time = time
                    });

                    string jsonN = JsonConvert.SerializeObject(_dataN.ToArray());

                    File.WriteAllText("/home/pi/prj4/webapi/package.json", jsonN);
                    break;
                default:
                    break;
            }
        }
    }
}
