// Solution to https://adventofcode.com/2019/day/2
const fs = require("fs");

// Convert input.txt in array
// @ts-ignore: ignore ts rules
function inputToArray(input) {
    console.log(input);
    const inputArr = fs.readFileSync(input).toString().split("\n");
    if (inputArr[inputArr.length - 1] == '') {
        inputArr.pop();
    }
    const outputArr = inputArr[0].split(',').map(Number);
    return outputArr;
}

// @ts-ignore: ignore ts rules
function runProgram(program) {
    let num1, num2, result;
    let num1Pos, num2Pos, resultPos;

    for (let i = 0; i < program.length; i += 4) {
        num1Pos = program[i + 1];
        num2Pos = program[i + 2];
        resultPos = program[i + 3];

        num1 = program[num1Pos];
        num2 = program[num2Pos];

        if (program[i] === 1) {
            result = num1 + num2;
        } else if (program[i] === 2) {
            result = num1 * num2;
        } else if (program[i] === 99) {
            break;
        } else {
            console.log("Error: opcode not found!");
        }
        program[resultPos] = result;
    }
    return program;
}

// @ts-ignore: ignore ts rules
function solveA(inputPath) {
    // push input in array
    const inputArr = inputToArray(inputPath);

    // prepare program
    inputArr[1] = 12;
    inputArr[2] = 2;
    console.log("Part One: " + runProgram(inputArr)[0]);
}

// @ts-ignore: ignore ts rules
function solveB(inputPath) {
    const seek = 19690720;
    let found = false;

    for (let verb = 0; verb < 100; verb++) {
        for (let noun = 0; noun < 100; noun++) {
            // push input in array
            const inputArr = inputToArray(inputPath);

            // prepare program
            inputArr[1] = noun;
            inputArr[2] = verb;

            const program = runProgram(inputArr);
            // console.log(program[0]);
            if (program[0] === seek) {
                found = true;
                console.log("Part Two: Number " + seek + " found (" + found +") with verb " + verb + " and noun " + noun + " (Result: " + (100 * noun + verb) + ").");
            }
        }
    }
}

function runTests() {
    const tests = {
        "TestA1": [
            [1, 0, 0, 0, 99],
            [2, 0, 0, 0, 99]
        ],
        "TestA2": [
            [2, 3, 0, 3, 99],
            [2, 3, 0, 6, 99]
        ],
        "TestA3": [
            [2, 4, 4, 5, 99, 0],
            [2, 4, 4, 5, 99, 9801]
        ],
        "TestA4": [
            [1, 1, 1, 4, 2, 5, 6, 0, 99],
            [30, 1, 1, 4, 2, 5, 6, 0, 99]
        ]
    };
    let succeed = true;

    for (const key in tests) {
        // @ts-ignore: ignore ts rules
        const result = runProgram(tests[key][0]);
        // @ts-ignore: ignore ts rules
        const expResult = tests[key][1];
        if (JSON.stringify(result) != JSON.stringify(expResult)) {
            succeed = false;
        }
    }
    return succeed;
}

if (runTests() === true) {
    solveA('../input.txt');
    solveB('../input.txt');
}
