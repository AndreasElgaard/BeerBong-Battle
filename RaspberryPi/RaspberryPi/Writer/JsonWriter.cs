using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RaspberryPi.Json_Writer
{
    public class JsonWriter
    {
        public void JsonWriterFunc(string context, string time)
        {
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
                        time = time
                    });

                    string json = JsonConvert.SerializeObject(_data.ToArray());

                    //write string to file
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

                    //write string to file
                    System.IO.File.WriteAllText("/home/pi/prj4/webapi/package.json", jsonF);
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

                    //write string to file
                    System.IO.File.WriteAllText("/home/pi/prj4/webapi/package.json", jsonN);
                    break;
                default:
                    break;
            }
        }
    }
}
