using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace TodoREST.Data
{
    class WebsocketClient
    {
        

        public async void ConnectToWebsocket()
        {
            var client = new ClientWebSocket();
            Uri uri = new Uri("ws://192.168.43.171:3000");
            await client.ConnectAsync(uri, CancellationToken.None);
            

            Debug.WriteLine(client.State.ToString());

            ArraySegment<Byte> readbuffer = new ArraySegment<byte>(new byte[8192]);
             while (client.State == WebSocketState.Open)
             {
                 var result = await client.ReceiveAsync(readbuffer, CancellationToken.None);
                 var data = System.Text.Encoding.Default.GetString(readbuffer.Array, readbuffer.Offset, result.Count);
                 Debug.WriteLine(data);
             }
        }
    }
}
