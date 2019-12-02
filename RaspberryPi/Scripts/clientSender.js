#!/usr/bin/env node
var WebSocketClient = require('websocket').client;
var fs = require('fs');
var client = new WebSocketClient();

client.on('connectFailed', function(error) {
    console.log('Connect Error: ' + error.toString());
});

client.on('connect', function(connection) {
    console.log('WebSocket Client Connected');
    connection.on('error', function(error) {
        console.log("Connection Error: " + error.toString());
    });
    connection.on('close', function() {
        console.log('echo-protocol Connection Closed');
    });
    connection.on('message', function(message) {
        if (message.type === 'utf8') {
            console.log("Received: " + message.utf8Data + "");
        }
    });

    function sendFile() {
        if (connection.connected) {
            var states = fs.readFileSync('/home/pi/prj4/webapi/package.json', 'utf8');
            //var states = JSON.parse(fs.readFileSync('/home/pi/prj4/webapi/package.json', 'utf8'));
            connection.send(states);
            setTimeout(sendFile, 1000);
        }
    }
    //sendNumber();
    sendFile();
});

client.connect('ws://192.168.43.171:3000/', 'echo-protocol');
