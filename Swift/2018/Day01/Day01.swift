func calc(inputStr: String) {
    let numbers = inputStr.split(separator: "\n").map({ Int($0)! })
    print(numbers.reduce(0, +))
}

import Foundation
let str = try! String(contentsOfFile: "input.txt")
//let str = try! String(contentsOfFile: CommandLine.arguments[1])
calc(inputStr: str)
