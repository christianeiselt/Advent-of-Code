import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;

/**
 * Solution for Advent of Code 2018, Day 1.
 * <p>
 * This utility class processes a list of frequency changes and calculates:
 * 1. The resulting frequency after applying all changes.
 * 2. The first frequency reached twice during a repeated application of changes.
 * </p>
 */
public class Day01 {

    /**
     * Path to the input file containing frequency changes.
     */
    private static final String INPUT_TXT = "input.txt";

    /**
     * Private constructor to prevent instantiation of the utility class.
     */
    private Day01() {
        throw new UnsupportedOperationException("Utility class should not be instantiated.");
    }

    /**
     * Reads the content of a file line by line into an ArrayList.
     *
     * @param path the file path to read from.
     * @return a list of strings, each representing a line from the file.
     */
    public static ArrayList<String> getContent(final String path) {
        BufferedReader reader = null;
        final ArrayList<String> lines = new ArrayList<>();

        try {
            String sCurrentLine;
            reader = new BufferedReader(new FileReader(path));
            while ((sCurrentLine = reader.readLine()) != null) {
                lines.add(sCurrentLine);
            }
        } catch (final IOException e) {
            e.printStackTrace();
            System.out.println(e.getMessage());
        } finally {
            try {
                if (reader != null) {
                    reader.close();
                }
            } catch (final IOException ex) {
                System.out.println(ex.getMessage());
                ex.printStackTrace();
            }
        }

        return lines;
    }

    /**
     * Processes frequency changes from a file and calculates:
     * <ul>
     * <li>The resulting frequency after applying all changes once.</li>
     * <li>The first frequency that is reached twice during repeated application of changes.</li>
     * </ul>
     *
     * @param path the file path containing frequency changes as lines of integers.
     */
    public static void solve(final String path) {
        final ArrayList<String> changes = getContent(path);

        int resultingFrequency = 0;
        int duplicateFrequency = 0;
        boolean duplicate = false;

        final HashSet<Integer> frequencies = new HashSet<>();
        frequencies.add(resultingFrequency);

        for (String change : changes) {
            int number = Integer.parseInt(change);
            resultingFrequency += number;
            frequencies.add(resultingFrequency);
        }

        System.out.println("The resulting frequency is: " + resultingFrequency);

        while (!duplicate) {
            for (String change : changes) {
                int number = Integer.parseInt(change);
                resultingFrequency += number;

                if (!frequencies.add(resultingFrequency)) {
                    duplicateFrequency = resultingFrequency;
                    duplicate = true;
                    break;
                }
            }
        }

        System.out.println("The first frequency reached twice is: " + duplicateFrequency);
    }

    /**
     * The main method to run the solution. It reads frequency changes from {@link #INPUT_TXT}.
     *
     * @param args command-line arguments (not used).
     * @throws IOException if an I/O error occurs while reading the file.
     */
    public static void main(final String[] args) throws IOException {
        solve(INPUT_TXT);
    }
}
