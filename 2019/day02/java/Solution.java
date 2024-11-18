import java.io.*;
import java.util.*;

public class Solution {

    private static final String INPUT_TXT = "input.txt";

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

    public static int runProgram(List<Integer> program) {
        int i = 0;
        while (program.get(i) != 99) {
            int opcode = program.get(i);
            int pos1 = program.get(i + 1);
            int pos2 = program.get(i + 2);
            int pos3 = program.get(i + 3);
            if (opcode == 1) {
                program.set(pos3, program.get(pos1) + program.get(pos2));
            } else if (opcode == 2) {
                program.set(pos3, program.get(pos1) * program.get(pos2));
            }
            i += 4;
        }
        return program.get(0);
    }

    public static int partOne(List<Integer> program) {
        List<Integer> programCopy = new ArrayList<>(program);
        programCopy.set(1, 12);
        programCopy.set(2, 2);
        return runProgram(programCopy);
    }

    public static int partTwo(List<Integer> program) {
        for (int noun = 0; noun <= 99; noun++) {
            for (int verb = 0; verb <= 99; verb++) {
                List<Integer> programCopy = new ArrayList<>(program);
                programCopy.set(1, noun);
                programCopy.set(2, verb);
                int result = runProgram(programCopy);
                if (result == 19690720) {
                    return 100 * noun + verb;
                }
            }
        }
        return -1;
    }

    public static void main(String[] args) {
        List<Integer> program = getContent(INPUT_TXT);

        int resultPartOne = partOne(program);
        System.out.println("Part 1: " + resultPartOne);

        int resultPartTwo = partTwo(program);
        System.out.println("Part 2: " + resultPartTwo);
    }
}
