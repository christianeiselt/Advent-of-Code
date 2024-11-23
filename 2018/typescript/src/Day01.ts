/**
 * Solution for Advent of Code 2018, Day 1.
 * 
 * This utility class processes a list of frequency changes and calculates:
 * 1. The resulting frequency after applying all changes.
 * 2. The first frequency reached twice during a repeated application of
 *    changes.
 */
export class Day01 {
  // Make the constant public so that it can be accessed from outside
  public static readonly INPUT_TXT: string = 'aoc_input/day01.txt';
  // Konstante für die Startfrequenz
  private static readonly INITIAL_FREQUENCY: number = 0;

  /**
   * Processes frequency changes from a file and calculates:
   * 1. The resulting frequency after applying all changes once.
   * 2. The first frequency that is reached twice during repeated application
   *    of changes.
   *
   * @param path The file path containing frequency changes as lines of integers.
   */
  public static async solve(path: string): Promise<void> {
    const changes = await this.getContent(path);

    let resultFreq = Day01.INITIAL_FREQUENCY; // Use the constant for initial frequency
    let dupFreq = 0;    // Variable for the first duplicate frequency
    let duplicateFound = false;

    const frequencies = new Set<number>();
    frequencies.add(resultFreq);

    // Calculate the resulting frequency after applying all changes once
    for (const change of changes) {
      const number = parseInt(change, 10);
      resultFreq += number;
    }
    console.log(`The resulting frequency is: ${resultFreq}`);

    // Find the first frequency reached twice
    resultFreq = Day01.INITIAL_FREQUENCY; // Reset the frequency for repeated application
    while (!duplicateFound) {
      for (const change of changes) {
        const number = parseInt(change, 10);
        resultFreq += number;

        if (frequencies.has(resultFreq)) {
          dupFreq = resultFreq;
          duplicateFound = true;
          break;
        }
        frequencies.add(resultFreq);
      }
    }

    console.log(`The first frequency reached twice is: ${dupFreq}`);
  }

  /**
   * Reads the content of a file line by line into an array of strings.
   *
   * @param path The file path to read from.
   * @returns A list of strings, each representing a line from the file.
   */
  private static async getContent(path: string): Promise<string[]> {
    try {
      const rawData = await Deno.readTextFile(path);
      return rawData.split('\n').map(line => line.trim()).filter(line => line !== '');
    } catch (error) {
      console.error(`Error reading file: ${error}`);
      throw error;
    }
  }
}

// Run the solution
if (import.meta.main) {
  const inputPath = Day01.INPUT_TXT; // Access the INPUT_TXT constant
  await Day01.solve(inputPath);
}
