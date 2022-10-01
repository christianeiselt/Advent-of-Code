/* import { readFileSync } from 'fs';

const file = readFileSync('./input.txt', 'utf-8');
console.log(file); */


const text = await Deno.readTextFile('./input.txt');
console.log(text);