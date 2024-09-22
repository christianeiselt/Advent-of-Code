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

  for (let i = 0; i < numArr.length; i++) {
    if (numArr[i] != currentNum) {
      if (countCurrentNum === 2) {
        return true
      }
      currentNum = numArr[i]
      countCurrentNum = 1
    } else {
      countCurrentNum++
    }
  }

  if (countCurrentNum % 2 === 0) {
    return true
  } else {
    return false
  }
}

function countCandidates (range, part) {
  const passwords = []
  const passwords2 = []

  for (i = start; i <= end; i++) {
    if (rising(i) === true) {
      if (part === 1 && containsMultiDigit(i) === true) {
        candidates.push(i)
      }
      if (part === 2 && containsDoubleDigit(i) === true) {
        candidates.push(i)
      }
    }
  }

  console.log(candidates.length)
}

console.log(containsDoubleDigit(111111) === true)

solveA()

countCandidates(input, 1)
countCandidates(input, 2)
// countCandidates([111111,111112]);
// console.log(containsMultiDigit(122234));
// console.log(false == containsDoubleDigit(122234));
// console.log(true == containsDoubleDigit(112223));
// console.log(false == containsDoubleDigit(111222));
