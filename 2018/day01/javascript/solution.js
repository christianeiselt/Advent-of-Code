// @ts-ignore
const fs = require("fs");
const text = fs.readFileSync("input.txt", "utf8");
const splitLines = (/** @type {string} */ str) => str.split(/\r?\n/);
const changes = splitLines(text);

let resultingFrequency = 0;
const frequencies = {};
let duplicateFrequency = 0;
let duplicate = false;
let sum = 0;
let loop = 0;

while (!duplicate) {
  for (let i = 0; i < changes.length; i++) {
    // @ts-ignore: typescript
    const change = parseInt(changes[i], 10);

    if (!isNaN(change)) {
      resultingFrequency += change;

      if (!Object.prototype.hasOwnProperty.call(frequencies, resultingFrequency)) {
        // @ts-ignore: typescript
        frequencies[resultingFrequency] = resultingFrequency;
      } else {
        if (duplicate === false) {
          duplicate = true;
          duplicateFrequency = resultingFrequency;
        }
      }
    }
  }

  if (sum === 0) {
    sum = resultingFrequency;
  }
  loop++;
}

// eslint-disable-next-line no-console
console.log("The resulting frequency after 1 loop is: " + sum);
if (duplicate === true) {
  // eslint-disable-next-line no-console
  console.log(
    "The first frequency was reached twice during the loop " +
      loop +
      " and is: " +
      duplicateFrequency
  );
}
