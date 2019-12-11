var WebSocketServer = require('websocket').server;
var WebSocketClient = require('websocket').client;
var WebSocketFrame  = require('websocket').frame;
var WebSocketRouter = require('websocket').router;
var W3CWebSocket = require('websocket').w3cwebsocket;
var http = require('http');
//Clients connected to the websocket
var count = 0;
//Array of clients
var clients = {};

var server = http.createServer(function(request, response) {
    console.log(('Received request for ' + request.url);
    response.writeHead(404);
    response.end();
});
server.listen(3000, function() {
    console.log('Server is listening on port 3000'); //For testing
});

wsServer = new WebSocketServer({
  //Sets type of connection
    httpServer: server,
    //Verifies the connection's origin and after this if to or not to accept connection
    autoAcceptConnections: false
});

function originIsAllowed(origin) {
  return true;
}

//When a request from a client to the server happens
wsServer.on('request', function(request) {
  //Checks whether or not the origin is allowed
    if (!originIsAllowed(request.origin)) {
      //Reject not allowed requests
      request.reject();
      console.log(('Connection from origin ' + request.origin + ' is rejected');
      return;
    }

    //Origin (client) allowed to subscribe on websockt server
    var connection = request.accept(request.origin);

		// Creates variable for the client and increment count
		var clientID = count++;
		//puts the client in an array of clients
		clients[clientID] = connection;

    console.log(('Connection Accepted');
    connection.on('message', function(message) {
        if (message.type === 'utf8') {
					// Loop through all clients
					for(var i in clients){
						console.log('Received Message: ' + message.utf8Data);
						clients[i].sendUTF(message.utf8Data);
					}
        }
        else if (message.type === 'json') {
					// Loop through all clients subscribing to the websocket server
					for(var i in clients){
						console.log('Received json Message of ' + message.jsonData);
            connection.sendBytes(message.jsonData);
					}
        }
    });
    //When connection closes between client and server
    connection.on('close', function(reasonCode, description) {
			delete clients[clientID];
			console.log((' Peer ' + connection.remoteAddress + ' disconnected');
    });
});
