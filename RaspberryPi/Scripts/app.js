var WebSocketServer = require('websocket').server;
var WebSocketClient = require('websocket').client;
var WebSocketFrame  = require('websocket').frame;
var WebSocketRouter = require('websocket').router;
var W3CWebSocket = require('websocket').w3cwebsocket;
var http = require('http');

var server = http.createServer(function(request, response) {
    console.log((new Date()) + ' Received request for ' + request.url);
    response.writeHead(404);
    response.end();
});
server.listen(3000, function() {
    console.log((new Date()) + ' Server is listening on port 8080');
});

wsServer = new WebSocketServer({
    httpServer: server,
    // You should not use autoAcceptConnections for production
    // applications, as it defeats all standard cross-origin protection
    // facilities built into the protocol and the browser.  You should
    // *always* verify the connection's origin and decide whether or not
    // to accept it.
    autoAcceptConnections: false
});

function originIsAllowed(origin) {
  // put logic here to detect whether the specified origin is allowed.
  return true;
}

var count = 0;
var clients = {};

wsServer.on('request', function(request) {
    if (!originIsAllowed(request.origin)) {
      // Make sure we only accept requests from an allowed origin
      request.reject();
      console.log((new Date()) + ' Connection from origin ' + request.origin + ' rejected.');
      return;
    }

    var connection = request.accept('echo-protocol', request.origin);
		// Specific id for this client & increment count
		var id = count++;
		// Store the connection method so we can loop through & contact all clients
		clients[id] = connection;

    console.log((new Date()) + ' Connection accepted.');
    connection.on('message', function(message) {
        if (message.type === 'utf8') {
					// Loop through all clients
					for(var i in clients){
						console.log('Received Message: ' + message.utf8Data);
						clients[i].sendUTF(message.utf8Data);
					}
        }
        else if (message.type === 'JSON') {
					// Loop through all clients
					for(var i in clients){
						console.log('Received json Message of ' + message.jsonData + ' bytes');
            connection.sendBytes(message.jsonData);
					}
        }
    });
    connection.on('close', function(reasonCode, description) {
			delete clients[id];
			console.log((new Date()) + ' Peer ' + connection.remoteAddress + ' disconnected.');
    });
});
