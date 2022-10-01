// https://adventofcode.com/2018/day/1

const rawInput = await Deno.readTextFile("./input.txt");
const input: number[] = rawInput.split("\n").map(Number);

class Day01 {
  private changes: number[];

  constructor(input: number[]) {
    this.changes = input;
  }

  PartOne() {
    let resultingFrequency = 0;

    for (let i = 0; i < this.changes.length; i += 1) {
      const change = this.changes[i];

      if (Number.isNaN(change) || change == undefined) {
        console.log("is not a number or is undefined");
      } else {
        resultingFrequency += change;
      }
    }

    console.log(
      `The resulting frequency after 1 loop is: ${resultingFrequency}.`,
    );
  }

  PartTwo() {
    let resultingFrequency = 0;
    const frequencies: { [change: number]: number } = {};
    let duplicateFrequency = 0;
    let duplicate = false;

    while (!duplicate) {
      for (let i = 0; i < this.changes.length; i++) {
        const change = this.changes[i];

        if (Number.isNaN(change) || change == undefined) {
          console.log("is not a number or is undefined");
        } else {
          resultingFrequency += change;
        }

        const isNotExistingFrequency = !Object.prototype.hasOwnProperty.call(
          frequencies,
          resultingFrequency,
        );

        if (isNotExistingFrequency) {
          frequencies[resultingFrequency] = resultingFrequency;
        } else if (!duplicate) {
          duplicate = true;
          duplicateFrequency = resultingFrequency;
          console.log(
            `The first frequency reached twice is: ${duplicateFrequency}.`,
          );
        } else {
          // already known duplicate
        }
      }
    }
  }
}

const solution = new Day01(input);
solution.PartOne();
solution.PartTwo();
