//This client is made for testing, to test the sent data from the clientSender.js
#!/usr/bin/env node
//Library for websocket client
var WebSocketClient = require('websocket').client;
//Object 
var client = new WebSocketClient();

//Error handling
client.on('connectFailed', function(error) {
    console.log('Connecttion Error: ' + error.toString());
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
	//When client recieves jason data from websocket server 
    connection.on('message', function(message) {
        if (message.type === 'JSON') {
            console.log("Received json: " + message.jsonData + "");
        }
      });
	  //When client recieves utf8 data from websocket server 
    connection.on('message', function(message) {
        if (message.type === 'utf8') {
            console.log("Received utf8: " + message.utf8Data + "");
        }
    });
});
//WebSocket server ip-address
client.connect('ws://192.168.43.171:3000/');
