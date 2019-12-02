using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPi.Websocket
{
    public class MyWebsocket
    {
        private WebSocket _socket;
        MyWebsocket(WebSocket socket)
        {
            socket = new WebSocket("ws://192.168.43.171:3000/");
            _socket = socket; 
        }
        public void Init()
        {
            //using (var ws = new WebSocket("ws://192.168.43.171:3000/"))
            //{
            //    ws.Connect();
            //}

            _socket.Connect();
        }

        public void SendToWebsocket(string json)
        {
            //using (var ws = new WebSocket("ws://192.168.43.171:3000/"))
            //{
            //    ws.OnMessage += (sender, e) =>
            //        Console.WriteLine("Laputa says: " + e.Data);
            //    ws.Connect();
            //    ws.Send(json);
            //    Console.ReadKey(true);
            //}
            _socket.Send(json.ToString());

        }
    }
}
