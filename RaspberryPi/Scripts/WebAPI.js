var express = require("express");
var app = express();
var PORT = 3000;  

app.get("/", (req, res, next) => {
	var states = JSON.parse(fs.readFileSync('/home/pi/prj4/webapi/package.json', 'utf8'));
	res.json(states); 
});

app.post('/', (req, res, next) => {
	const state = {
	name: req.body.name,
	state: req.body.state, 
	time: req.body.time
	};
	states.push(state); 
	res.send(state); 	
});

app.listen(PORT, () => {
 console.log("Server running on port ${PORT}");
});