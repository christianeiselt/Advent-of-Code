var fs = require('fs')
const text = fs.readFileSync('2018/01/input.txt','utf8')
const splitLines = str => str.split(/\r?\n/);

var strArray = splitLines(text);
var result = 0;

for(var i=0; i<strArray.length; i++) {
	var number = parseInt(strArray[i]);
	// console.log (number);	
	if (number > 0 || number < 0) {
		result += number;
	}
}

console.log (result);