// Solution to https://adventofcode.com/2019/day/1

// Convert input.txt in array
var fs = require('fs')
const text = fs.readFileSync('2019/Day01/input.txt', 'utf8')
const splitLines = str => str.split(/\r?\n/);
var massPerModule = splitLines(text);

function calcFuelForModule(mass) {
    return Math.floor(mass / 3) - 2;
}

function calcTotalFuelForModule(mass) {
    let totalFuelForModule = calcFuelForModule(mass);
    let addFuel = calcFuelForModule(totalFuelForModule);

    while (addFuel > 0) {
        totalFuelForModule += addFuel;
        addFuel = calcFuelForModule(addFuel);
    }

    return totalFuelForModule;
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

function calcFuelForLaunch() {
    let fuel = 0;

    for (let i = 0; i < massPerModule.length; i++) {
        let mass = parseInt(massPerModule[i]);

        if (!isNaN(mass)) {
            fuel += calcTotalFuelForModule(massPerModule[i]);
        }
    }

    return fuel;
}

console.log("Test A1: " + (2 == calcFuelForModule(12)) + " (" + calcFuelForModule(12) + ")");
console.log("Test A2: " + (2 == calcFuelForModule(14)) + " (" + calcFuelForModule(14) + ")");
console.log("Test A3: " + (654 == calcFuelForModule(1969)) + " (" + calcFuelForModule(1969) + ")");
console.log("Test A4: " + (33583 == calcFuelForModule(100756)) + " (" + calcFuelForModule(100756) + ")");

console.log("Solution A: " + calcModFuel() + " units fuel needed for all modules");


console.log("Test B1: " + (2 == calcTotalFuelForModule(12)) + " (" + calcTotalFuelForModule(12) + ")");
console.log("Test B2: " + (2 == calcTotalFuelForModule(14)) + " (" + calcTotalFuelForModule(14) + ")");
console.log("Test B3: " + (966 == calcTotalFuelForModule(1969)) + " (" + calcTotalFuelForModule(1969) + ")");
console.log("Test B4: " + (50346 == calcTotalFuelForModule(100756)) + " (" + calcTotalFuelForModule(100756) + ")");

console.log("Solution B: " + calcFuelForLaunch() + " units fuel needed for launch");