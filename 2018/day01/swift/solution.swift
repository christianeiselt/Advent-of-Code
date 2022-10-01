// https://adventofcode.com/2018/day/1

func partOne(changes: String) {
    let resultingFrequency = changes.split(separator: "\n").map({ Int($0)! })
    print("The resulting frequency after 1 loop is: \(resultingFrequency.reduce(0, +)).")
}

import Foundation
let input = try String(contentsOfFile: "input.txt")

partOne(changes: input)
