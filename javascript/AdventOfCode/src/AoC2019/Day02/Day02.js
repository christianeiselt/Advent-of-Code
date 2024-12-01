// Solution to https://adventofcode.com/2019/day/2
const fs = require('fs')

// Convert input.txt in array
function inputToArray (input) {
  const inputArr = fs.readFileSync(input).toString().split('\n')
  if (inputArr[inputArr.length - 1] === '') {
    inputArr.pop() // Remove last empty string (if file ends with a newline)
  }
  const outputArr = inputArr[0].split(',').map(Number)
  return outputArr
}

// Run the program and execute opcodes
function runProgram (program) {
  let num1, num2, result
  let num1Pos, num2Pos, resultPos

  for (let i = 0; i < program.length; i += 4) {
    num1Pos = program[i + 1]
    num2Pos = program[i + 2]
    resultPos = program[i + 3]

    num1 = program[num1Pos]
    num2 = program[num2Pos]

    if (program[i] === 1) {
      result = num1 + num2
    } else if (program[i] === 2) {
      result = num1 * num2
    } else if (program[i] === 99) {
      break // Halt when opcode 99 is encountered
    } else {
      console.log(`Error: Unknown opcode ${program[i]} at position ${i}`)
      throw new Error('Unknown opcode encountered!')
    }
    program[resultPos] = result
  }
  return program
}

// Solve part A: set noun=12, verb=2, and run the program
function solveA (inputPath) {
  const inputArr = inputToArray(inputPath)

  // Modify input program (noun=12, verb=2)
  inputArr[1] = 12
  inputArr[2] = 2

  const result = runProgram(inputArr)
  console.log('Part One: ' + result[0])
}

// Solve part B: Find the correct noun and verb for the output 19690720
function solveB (inputPath) {
  const seek = 19690720
  let found = false

  for (let noun = 0; noun < 100; noun++) {
    for (let verb = 0; verb < 100; verb++) {
      const inputArr = inputToArray(inputPath)

      // Modify input program (noun, verb)
      inputArr[1] = noun
      inputArr[2] = verb

      const program = runProgram(inputArr)

      if (program[0] === seek) {
        found = true
        console.log(`Part Two: Number ${seek} found (Result: ${100 * noun + verb}) with noun ${noun} and verb ${verb}.`)
        break // Stop once we found the solution
      }
    }
    if (found) break // Exit outer loop if found
  }

  if (!found) {
    console.log('Part Two: No solution found')
  }
}

// Run tests
function runTests () {
  const tests = {
    TestA1: [
      [1, 0, 0, 0, 99],
      [2, 0, 0, 0, 99]
    ],
    TestA2: [
      [2, 3, 0, 3, 99],
      [2, 3, 0, 6, 99]
    ],
    TestA3: [
      [2, 4, 4, 5, 99, 0],
      [2, 4, 4, 5, 99, 9801]
    ],
    TestA4: [
      [1, 1, 1, 4, 2, 5, 6, 0, 99],
      [30, 1, 1, 4, 2, 5, 6, 0, 99]
    ]
  }

  let succeed = true

  for (const key in tests) {
    const result = runProgram(tests[key][0])
    const expectedResult = tests[key][1]

    if (JSON.stringify(result) !== JSON.stringify(expectedResult)) {
      succeed = false
      console.log(`Test ${key} failed!`)
    }
  }

  return succeed
}

// Start solving
if (runTests()) {
  solveA('_puzzle_inputs_answers/2019/day02_input.txt')
  solveB('_puzzle_inputs_answers/2019/day02_input.txt')
} else {
  console.log('Some tests failed!')
}
