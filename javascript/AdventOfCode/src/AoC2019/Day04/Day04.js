const input = { min: 156218, max: 652527 }

function splitInDigits (number) {
  const digits = number.toString().split('')
  return digits.map(Number)
}

function rising (number) {
  const numArr = splitInDigits(number)

  for (let i = 1; i < numArr.length; i++) {
    if (numArr[i] < numArr[i - 1]) {
      return false
    }
  }

  return true
}

function containsMultiDigit (number) {
  const numArr = splitInDigits(number)

  for (let i = 1; i < numArr.length; i++) {
    if (numArr[i] === numArr[i - 1]) {
      return true
    }
  }

  return false
}

function containsDoubleDigit (number) {
  const numArr = splitInDigits(number)
  let currentNum = 0
  let countCurrentNum = 0
  let foundDouble = false

  for (let i = 0; i < numArr.length; i++) {
    if (numArr[i] !== currentNum) {
      if (countCurrentNum === 2) {
        foundDouble = true
      }
      currentNum = numArr[i]
      countCurrentNum = 1
    } else {
      countCurrentNum++
    }
  }

  // Last check for a pair of exactly two digits
  if (countCurrentNum === 2) {
    foundDouble = true
  }

  return foundDouble
}

function countCandidates (input, part) {
  const candidates = []

  for (let i = input.min; i <= input.max; i++) {
    if (rising(i)) {
      if (part === 1 && containsMultiDigit(i)) {
        candidates.push(i)
      }
      if (part === 2 && containsDoubleDigit(i)) {
        candidates.push(i)
      }
    }
  }

  console.log(candidates.length)
}

// Tests
// console.log(containsDoubleDigit(111111) === true)
// console.log(containsDoubleDigit(122234) === false)
// console.log(containsDoubleDigit(112223) === true)
// console.log(containsDoubleDigit(111222) === false)

// Solve Part 1 and Part 2
countCandidates(input, 1) // Solve part 1
countCandidates(input, 2) // Solve part 2
