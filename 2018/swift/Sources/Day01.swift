// https://adventofcode.com/2018/day/1

import Foundation

func partOne(changes: String) {
    // Split input by lines and safely convert to integers
    let resultingFrequency = changes.split(separator: "\n")
        .compactMap { Int($0.trimmingCharacters(in: .whitespacesAndNewlines)) }
    
    // Calculate the sum of the frequencies and print the result
    let sum = resultingFrequency.reduce(0, +)
    print("The resulting frequency after 1 loop is: \(sum).")
}

do {
    // Use the updated initializer with encoding specified
    let input = try String(contentsOfFile: "2018/aoc_input/day01.txt", encoding: .utf8)
    partOne(changes: input)
} catch {
    print("Error reading the input file: \(error)")
}
