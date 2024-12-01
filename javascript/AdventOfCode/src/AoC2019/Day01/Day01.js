// Solution to https://adventofcode.com/2019/day/1

// Convert input.txt to an array of masses
const fs = require('fs')
const text = fs.readFileSync('_puzzle_inputs_answers/2019/day01_input.txt', 'utf8')
const splitLines = (str) => str.split(/\r?\n/)
const massPerModule = splitLines(text)

/**
 * Calculate the fuel required for a given mass.
 * @param {number} mass - The mass to calculate fuel for.
 * @param {boolean} includeFuelMass - Whether to include the additional fuel required for the fuel itself.
 * @returns {number} - The total fuel required.
 */
function calcFuel (mass, includeFuelMass = false) {
  // Calculate the initial fuel required for the mass
  const totalFuel = Math.floor(mass / 3) - 2

  // If the fuel is less than or equal to 0, return 0 (no fuel needed)
  if (totalFuel <= 0) return 0

  // If we're including the fuel mass, recursively calculate the additional fuel required
  if (includeFuelMass) {
    // Calculate additional fuel, and stop recursion if no more fuel is needed
    const additionalFuel = calcFuel(totalFuel, true)
    return totalFuel + additionalFuel // Return total fuel and include the additional fuel
  }

  return totalFuel // Return the total fuel needed for the module
}

/**
 * Calculate the total fuel for all modules based on the provided fuel calculation method.
 * @param {boolean} includeFuelMass - Whether to include the additional fuel required for the fuel itself.
 * @returns {number} - The total fuel for all modules.
 */
function calculateTotalFuel (includeFuelMass = false) {
  let totalFuel = 0
  for (let i = 0; i < massPerModule.length; i++) {
    const mass = parseInt(massPerModule[i], 10)
    if (!isNaN(mass)) {
      totalFuel += calcFuel(mass, includeFuelMass)
    }
  }
  return totalFuel
}

// Function to run test cases and log results
function runTestCases () {
  const testCasesA = [
    { mass: 12, expected: 2 },
    { mass: 14, expected: 2 },
    { mass: 1969, expected: 654 },
    { mass: 100756, expected: 33583 }
  ]

  const testCasesB = [
    { mass: 12, expected: 2 },
    { mass: 14, expected: 2 },
    { mass: 1969, expected: 966 },
    { mass: 100756, expected: 50346 }
  ]

  testCasesA.forEach(({ mass, expected }) => {
    console.log(`Test A: ${calcFuel(mass) === expected} (${calcFuel(mass)})`)
  })

  testCasesB.forEach(({ mass, expected }) => {
    console.log(`Test B: ${calcFuel(mass, true) === expected} (${calcFuel(mass, true)})`)
  })
}

// Run the test cases
runTestCases()

// Output the solutions
console.log('Solution A: ' + calculateTotalFuel() + ' units of fuel needed for all modules')
console.log('Solution B: ' + calculateTotalFuel(true) + ' units of fuel needed for launch')
