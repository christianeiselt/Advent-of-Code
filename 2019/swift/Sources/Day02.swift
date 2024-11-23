func runIntcode(program: inout [Int]) {
    var pointer = 0

    while pointer < program.count {
        let opcode = program[pointer]
        if opcode == 99 {
            break
        }

        guard pointer + 3 < program.count else {
            print("Error: Invalid program length")
            return
        }

        let input1Pos = program[pointer + 1]
        let input2Pos = program[pointer + 2]
        let outputPos = program[pointer + 3]

        guard input1Pos < program.count, input2Pos < program.count, outputPos < program.count else {
            print("Error: Invalid memory address")
            return
        }

        if opcode == 1 {
            program[outputPos] = program[input1Pos] + program[input2Pos]
        } else if opcode == 2 {
            program[outputPos] = program[input1Pos] * program[input2Pos]
        } else {
            print("Error: Unknown opcode \(opcode)")
            return
        }

        pointer += 4
    }
}

import Foundation

do {
    let filePath = "2019/Day02/input.txt"
    let input = try String(contentsOfFile: filePath, encoding: .utf8)

    var program = input.split(separator: ",").compactMap { Int($0) }

    program[1] = 12
    program[2] = 2

    runIntcode(program: &program)

    print("Value at position 0: \(program[0])")
} catch {
    print("Error reading the file: \(error)")
}
