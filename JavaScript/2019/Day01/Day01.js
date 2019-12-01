// Convert input.txt in array
var fs = require('fs')
const text = fs.readFileSync('2019/Day01/input.txt', 'utf8')
const splitLines = str => str.split(/\r?\n/);
var massPerModule = splitLines(text);

let partA = 0;
let partB = 0;

function calcFuelForModule(mass) {
    return Math.floor(mass / 3) - 2;
}

function calcModFuel() {
    let fuel = 0;
    for (let i = 0; i < massPerModule.length; i++) {
        let mass = parseInt(massPerModule[i]);

        if (!isNaN(mass)) {
            fuel += calcFuelForModule(mass);
        }
    }
    return fuel;
}

console.log("Test A1: " + (2 == calcFuelForModule(12)));
console.log("Test A2: " + (2 == calcFuelForModule(14)));
console.log("Test A3: " + (654 == calcFuelForModule(1969)));
console.log("Test A4: " + (33583 == calcFuelForModule(100756)));

console.log("Solution A: " + calcModFuel() + " units fuel needed for all modules");