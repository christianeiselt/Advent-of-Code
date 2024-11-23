package adventofcode.y2019;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 * Utility class for solving Advent of Code 2019, Day 02.
 */
public final class Day02 {

    /** Opcode to halt the program execution. */
    private static final int HALT_OPCODE = 99;

    /** Opcode for addition operation. */
    private static final int ADD_OPCODE = 1;

    /** Opcode for multiplication operation. */
    private static final int MULTIPLY_OPCODE = 2;

    /** Initial noun value for Part 1. */
    private static final int INITIAL_NOUN = 12;

    /** Initial verb value for Part 1. */
    private static final int INITIAL_VERB = 2;

    /** Target output for Part 2. */
    private static final int TARGET_OUTPUT = 19_690_720;

    /** Maximum value for noun and verb in Part 2. */
    private static final int MAX_NOUN_VERB = 99;

    /** Offset for processing opcodes. */
    private static final int OPCODE_STEP = 4;

    /** Multiplier for computing the result in Part 2. */
    private static final int RESULT_MULTIPLIER = 100;

    /**
     * Prevent instantiation of utility class.
     */
    private Day02() {
        throw new UnsupportedOperationException(
            "Utility class should not be instantiated."
        );
    }

    /**
     * Reads the input program from the given file path.
     *
     * @param path the file path to read from
     * @return a list of integers representing the program
     */
    public static List<Integer> getContent(final String path) {
        final List<Integer> program = new ArrayList<>();
        try (BufferedReader reader = new BufferedReader(new FileReader(path))) {
            final String line = reader.readLine();
            if (line != null) {
                final String[] parts = line.split(",");
                for (final String part : parts) {
                    program.add(Integer.parseInt(part));
                }
            }
        } catch (final IOException e) {
            e.printStackTrace();
        }
        return program;
    }

    /**
     * Executes the given program and returns the result at position 0.
     *
     * @param program the program to execute
     * @return the value at position 0 after execution
     */
    public static int runProgram(final List<Integer> program) {
        int index = 0;
        while (program.get(index) != HALT_OPCODE) {
            final int opcode = program.get(index);
            final int pos1 = program.get(index + 1);
            final int pos2 = program.get(index + 2);
            final int pos3 = program.get(index + 3);
            if (opcode == ADD_OPCODE) {
                program.set(pos3, program.get(pos1) + program.get(pos2));
            } else if (opcode == MULTIPLY_OPCODE) {
                program.set(pos3, program.get(pos1) * program.get(pos2));
            }
            index += OPCODE_STEP;
        }
        return program.get(0);
    }

    /**
     * Solves Part 1 of the puzzle.
     *
     * @param program the input program
     * @return the result of the program with the initial noun and verb
     */
    public static int partOne(final List<Integer> program) {
        final List<Integer> programCopy = new ArrayList<>(program);
        programCopy.set(1, INITIAL_NOUN);
        programCopy.set(2, INITIAL_VERB);
        return runProgram(programCopy);
    }

    /**
     * Solves Part 2 of the puzzle.
     *
     * @param program the input program
     * @return the noun and verb combination that produces the target output
     */
    public static int partTwo(final List<Integer> program) {
        int result = -1;
        for (int noun = 0; noun <= MAX_NOUN_VERB; noun++) {
            for (int verb = 0; verb <= MAX_NOUN_VERB; verb++) {
                final List<Integer> programCopy = new ArrayList<>(program);
                programCopy.set(1, noun);
                programCopy.set(2, verb);
                final int output = runProgram(programCopy);
                if (output == TARGET_OUTPUT) {
                    result = RESULT_MULTIPLIER * noun + verb;
                    break;
                }
            }
            if (result != -1) {
                break;
            }
        }
        return result;
    }

    /**
     * Main method to execute the program.
     *
     * @param args the command-line arguments
     */
    public static void main(final String[] args) {
        final List<Integer> program = getContent(
            "aoc_input/day02.txt"
        );

        final int resultPartOne = partOne(program);
        System.out.println("Part 1: " + resultPartOne);

        final int resultPartTwo = partTwo(program);
        System.out.println("Part 2: " + resultPartTwo);
    }
}
