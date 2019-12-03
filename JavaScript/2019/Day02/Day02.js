// Solution to https://adventofcode.com/2019/day/2

// Convert input.txt in array
function inputToArray(input) {
    let fs = require('fs')
    const splitLines = str => str.split(/\r?\n/);
    var inputArr = splitLines(fs.readFileSync(input, 'utf8'));
    let outputArr = [];

    if (inputArr[inputArr.length - 1] == '') {
        inputArr.pop();
    }
    return inputArr.keys();
    // return inputArr;
}

function runProgram(program) {
    console.log("Input: " + program);

    let start = 0;
    while (start < program.length) {
        console.log("Stelle: " + program[start]);

        if (program[start] == 1) {
            program[program[start + 3]] = program[program[start + 1]] + program[program[start + 2]];
        } else if (program[start] == 2) {
            program[program[start + 3]] = program[program[start + 1]] * program[program[start + 2]];
        } else if (program[start] == 99) {
            return program;
        }

        start += 4;
    }

    return program;
}

function splitIntoPrograms(programfile) {
    let programs = [];
    let program = [];
    console.log(programfile);

    for (let i = 0; i < programfile.length; i++) {
        console.log(programfile.length);
        let nextInt = parseInt(programfile[i]);
        if (!isNaN(nextInt)) {
            console.log("nextInt: " + nextInt);
            if (nextInt != 99) {
                program.push(nextInt);
                console.log("program: " + program);
            } else {
                program.push(nextInt);
                programs.push(program);
                program = [];
                console.log("Program: " + program);
            }
        }
    }
    return programs;
}



// console.log(inputToArray('2019/Day02/input.txt'));

console.log("Test A1: " + ([2, 0, 0, 0, 99] == runProgram([1, 0, 0, 0, 99])) + " (" + runProgram([1, 0, 0, 0, 99]) + ")");
console.log("Test A1: " + ([2, 3, 0, 6, 99] == runProgram([2, 3, 0, 3, 99])) + " (" + runProgram([2, 3, 0, 3, 99]) + ")");
console.log("Test A1: " + ([2, 4, 4, 5, 99, 9801] == runProgram([2, 4, 4, 5, 99, 0])) + " (" + runProgram([2, 4, 4, 5, 99, 0]) + ")");
console.log("Test A1: " + ([30, 1, 1, 4, 2, 5, 6, 0, 99] == runProgram([1, 1, 1, 4, 2, 5, 6, 0, 99])) + " (" + runProgram([1, 1, 1, 4, 2, 5, 6, 0, 99]) + ")");