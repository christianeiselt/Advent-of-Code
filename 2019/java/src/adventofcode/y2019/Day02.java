package adventofcode.y2019;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.List;
import java.util.ArrayList;

/**
 * Utility class for solving Advent of Code 2019, Day 02.
 */
public final class Day02 {

    /** The opcode for halting the program. */
    private static final int HALT_OPCODE = 99;
    /** The opcode for addition. */
    private static final int ADD_OPCODE = 1;
    /** The initial noun for Part 1. */
    private static final int INITIAL_NOUN = 12;
    /** The initial verb for Part 1. */
    private static final int INITIAL_VERB = 2;
    /** The target output for Part 2. */
    private static final int TARGET_OUTPUT = 19_690_720;
    /** The maximum noun and verb value. */
    private static final int MAX_NOUN_VERB = 99;
    /** Multiplier for Part 2 result. */
    private static final int RESULT_MULTIPLIER = 100;
    /** The number of values to process per opcode (in this case, 4). */
    private static final int OPCODE_LENGTH = 4;
    /** The index of the third position to be used in the program operation. */
    private static final int THIRD_POSITION = 3;

    // Private constructor to prevent instantiation
    private Day02() {
        throw new UnsupportedOperationException(
            "Utility class should not be instantiated."
        );
    }

    /**
     * Reads the content of a file and returns it as a list of integers.
     *
     * @param path the file path.
     * @return a list of integers read from the file.
     */
    public static List<Integer> getContent(final String path) {
        List<Integer> program = new ArrayList<>();
        try (BufferedReader reader = new BufferedReader(new FileReader(path))) {
            String line = reader.readLine();
            if (line != null) {
                for (String part : line.split(",")) {
                    program.add(Integer.parseInt(part));
                }
            }
        } catch (IOException e) {
            System.err.println("Error reading file: " + e.getMessage());
        }
        return program;
    }

    /**
     * Executes the given program and returns the result at position 0.
     *
     * @param program the program to execute.
     * @return the value at position 0 after execution.
     */
    public static int runProgram(final List<Integer> program) {
        // Iterate through the program in steps of 4
        for (int index = 0; program.get(index) != HALT_OPCODE;
                index += OPCODE_LENGTH) {
            int opcode = program.get(index);
            int pos1 = program.get(index + 1);
            int pos2 = program.get(index + 2);
            int pos3 = program.get(index + THIRD_POSITION);

            // Apply the operation (either addition or multiplication)
            program.set(pos3,
                (opcode == ADD_OPCODE)
                    ? program.get(pos1) + program.get(pos2)
                    : program.get(pos1) * program.get(pos2));
        }
        return program.get(0);  // Return the value at position 0
    }

    /**
     * Solves Part 1 of the puzzle by setting the initial noun and verb.
     *
     * @param program the input program.
     * @return the result of the program with the initial noun and verb.
     */
    public static int partOne(final List<Integer> program) {
        program.set(1, INITIAL_NOUN);
        program.set(2, INITIAL_VERB);
        return runProgram(program);
    }

    /**
     * Solves Part 2 of the puzzle by finding the noun and verb that produces
     * the target output.
     *
     * @param program the input program.
     * @return the noun and verb combination that produces the target output.
     */
    public static int partTwo(final List<Integer> program) {
        // Loop through possible noun and verb values
        for (int noun = 0; noun <= MAX_NOUN_VERB; noun++) {
            for (int verb = 0; verb <= MAX_NOUN_VERB; verb++) {
                List<Integer> programCopy = new ArrayList<>(program);
                programCopy.set(1, noun);
                programCopy.set(2, verb);
                if (runProgram(programCopy) == TARGET_OUTPUT) {
                    return RESULT_MULTIPLIER * noun + verb;
                }
            }
        }
        return -1;  // Return -1 if no solution is found
    }

    /**
     * Main method to execute the program.
     *
     * @param args the command-line arguments.
     */
    public static void main(final String[] args) {
        List<Integer> program = getContent("2019/aoc_input/day02.txt");

        System.out.println("Part 1: " + partOne(new ArrayList<>(program)));
        System.out.println("Part 2: " + partTwo(program));
    }
}
