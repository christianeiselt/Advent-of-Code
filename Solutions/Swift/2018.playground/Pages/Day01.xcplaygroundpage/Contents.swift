//: [Previous](@previous)

import Foundation
import XCPlayground
import PlaygroundSupport

let fileURL = playgroundSharedDataDirectory.appendingPathComponent("input.txt")

var fileContents: String?
do {
    fileContents = try String(contentsOf: fileURL)
} catch {
    print("Error reading contents: \(error)")
}

func calc(inputStr: String) {
    let numbers = inputStr.split(separator: "\n").map({ Int($0)! })
    print(numbers.reduce(0, +))
}


calc(inputStr: fileContents!)

//: [Next](@next)
