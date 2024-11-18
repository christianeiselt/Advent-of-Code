import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Solution {

    private static final int HALT_OPCODE = 99;
    private static final int ADD_OPCODE = 1;
    private static final int MULTIPLY_OPCODE = 2;
    private static final int INITIAL_NOUN = 12;
    private static final int INITIAL_VERB = 2;
    private static final int TARGET_OUTPUT = 19690720;
    private static final int MAX_NOUN_VERB = 99;

    private Solution() {
        throw new UnsupportedOperationException("Utility class should not be instantiated.");
    }

    public static List<Integer> getContent(final String path) {
        List<Integer> program = new ArrayList<>();
        try (BufferedReader reader = new BufferedReader(new FileReader(path))) {
            String line = reader.readLine();
            if (line != null) {
                String[] parts = line.split(",");
                for (String part : parts) {
                    program.add(Integer.parseInt(part));
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return program;
    }

    public static int runProgram(final List<Integer> program) {
        int i = 0;
        while (program.get(i) != HALT_OPCODE) {
            int opcode = program.get(i);
            int pos1 = program.get(i + 1);
            int pos2 = program.get(i + 2);
            int pos3 = program.get(i + 3);
            if (opcode == ADD_OPCODE) {
                program.set(pos3, program.get(pos1) + program.get(pos2));
            } else if (opcode == MULTIPLY_OPCODE) {
                program.set(pos3, program.get(pos1) * program.get(pos2));
            }
            i += 4;
        }
        return program.get(0);
    }

    public static int partOne(final List<Integer> program) {
        List<Integer> programCopy = new ArrayList<>(program);
        programCopy.set(1, INITIAL_NOUN);
        programCopy.set(2, INITIAL_VERB);
        return runProgram(programCopy);
    }

    public static int partTwo(final List<Integer> program) {
        for (int noun = 0; noun <= MAX_NOUN_VERB; noun++) {
            for (int verb = 0; verb <= MAX_NOUN_VERB; verb++) {
                List<Integer> programCopy = new ArrayList<>(program);
                programCopy.set(1, noun);
                programCopy.set(2, verb);
                int result = runProgram(programCopy);
                if (result == TARGET_OUTPUT) {
                    return 100 * noun + verb;
                }
            }
        }
        return -1;
    }

    public static void main(final String[] args) {
        List<Integer> program = getContent("input.txt");

        int resultPartOne = partOne(program);
        System.out.println("Part 1: " + resultPartOne);

        int resultPartTwo = partTwo(program);
        System.out.println("Part 2: " + resultPartTwo);
    }
}
