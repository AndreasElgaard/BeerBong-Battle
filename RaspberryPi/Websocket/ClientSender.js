//This client runs on the Raspberry Pi to send data via websocket server to
#!/usr/bin/env node
//Library for websocket client
var WebSocketClient = require('websocket').client;
var fs = require('fs');
//Object
var client = new WebSocketClient();

//Error handling
client.on('connectFailed', function(error) {
    console.log('Connection Error: ' + error.toString());
});
//When client connects to websocket, hosted by Raspberry Pi (websocket.js)
client.on('connect', function(connection) {
    console.log('WebSocket Client Connected');
    connection.on('error', function(error) {
        console.log("Connection Error: " + error.toString());
    });
    //When client closes connection between websocket server and itself
    connection.on('close', function() {
        console.log('Connection Closed');
    });
    //When client recieves utf8 data from websocket server. Recieves the data it sends itself for testing purporses.
    connection.on('message', function(message) {
        if (message.type === 'json') {
            console.log("Received json: " + message.jsonData + "");
        }
        if (message.type === 'utf8') {
            console.log("Received utf8: " + message.utf8Data + "");
        }
    });
    //Function to to send package.json to server and all listening clients. This function sends data
    //updated by the main program (RaspberryPi.sln)
    //Function only sends when connected
    function sendFile() {
        if (connection.connected) {
          //var states = JSON.parse(fs.readFileSync('/home/pi/prj4/webapi/package.json', 'utf8'));
          var states = fs.readFileSync('/home/pi/prj4/webapi/package.json', 'utf8');
          //send package.json
          connection.send(states);
          //Sends every 1 sec
          setTimeout(sendFile, 1000);
        }
    }
    sendFile();
});
//Connect to websocket server
client.connect('ws://192.168.43.171:3000/');
