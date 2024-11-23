/**
 * Solution for Advent of Code 2018, Day 1.
 *
 * This utility processes a list of frequency changes and calculates:
 * 1. The resulting frequency after applying all changes.
 * 2. The first frequency reached twice during a repeated application of
 *    changes.
 */

// Constants for file path and initial frequency
export const INPUT_TXT: string = '2018/aoc_input/day01.txt'
const INITIAL_FREQUENCY: number = 0

/**
 * Processes frequency changes from a file and calculates:
 * 1. The resulting frequency after applying all changes once.
 * 2. The first frequency that is reached twice during repeated application of
 *    changes.
 *
 * @param path The file path containing frequency changes as lines of integers.
 */
export async function solve (path: string): Promise<void> {
  const changes = await getContent(path)

  let resultFreq: number = INITIAL_FREQUENCY // Use the constant for initial frequency
  let dupFreq: number = 0 // Variable for the first duplicate frequency
  let duplicateFound: boolean = false // Explicitly typing as boolean

  const frequencies = new Set<number>()
  frequencies.add(resultFreq)

  // Calculate the resulting frequency after applying all changes once
  for (const change of changes) {
    const number = parseInt(change, 10)
    resultFreq += number
  }
  console.log(`The resulting frequency is: ${resultFreq}`)

  // Find the first frequency reached twice
  resultFreq = INITIAL_FREQUENCY // Reset the frequency for repeated application
  while (!duplicateFound) { // Explicitly check for true
    for (const change of changes) {
      const number = parseInt(change, 10)
      resultFreq += number

      if (frequencies.has(resultFreq)) {
        dupFreq = resultFreq
        duplicateFound = true
        break
      }
      frequencies.add(resultFreq)
    }
  }

  console.log(`The first frequency reached twice is: ${dupFreq}`)
}

/**
 * Reads the content of a file line by line into an array of strings.
 *
 * @param path The file path to read from.
 * @returns A list of strings, each representing a line from the file.
 */
async function getContent (path: string): Promise<string[]> {
  try {
    const rawData = await Deno.readTextFile(path)
    return rawData.split('\n').map(line => line.trim()).filter(line => line !== '')
  } catch (error) {
    console.error(`Error reading file: ${String(error)}`)
    throw error
  }
}

// Run the solution
if (import.meta.main === true) { // Explicit comparison with true
  const inputPath = INPUT_TXT // Access the INPUT_TXT constant
  await solve(inputPath)
}
