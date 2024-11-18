// https://adventofcode.com/2018/day/1
export {}

const rawInput = await Deno.readTextFile('./input.txt')
const input: number[] = rawInput.split('\n').map(Number).filter((n) => !isNaN(n)) // Filter out non-numeric values

class Day01 {
  private readonly changes: number[]

  constructor (input: number[]) {
    this.changes = input
  }

  PartOne (): void {
    const resultingFrequency = this.changes.reduce((acc, change) => acc + change, 0)
    console.log(`The resulting frequency after 1 loop is: ${resultingFrequency}.`)
  }

  PartTwo (): void {
    let resultingFrequency = 0
    const seenFrequencies = new Set<number>()
    let duplicateFrequency: number | null = null
    let i = 0

    while (duplicateFrequency === null) {
      const change = this.changes[i % this.changes.length] // Loop through changes cyclically
      resultingFrequency += change

      if (seenFrequencies.has(resultingFrequency)) {
        duplicateFrequency = resultingFrequency
        console.log(`The first frequency reached twice is: ${duplicateFrequency}.`)
        break
      }

      seenFrequencies.add(resultingFrequency)
      i++
    }
  }
}

const solution = new Day01(input)
solution.PartOne()
solution.PartTwo()
