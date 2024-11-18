// https://adventofcode.com/2018/day/1

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;

public class Day01 {

    private static final String INPUT_TXT = "input.txt";

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
                if (reader != null) reader.close();
            } catch (final IOException ex) {
                System.out.println(ex.getMessage());
                ex.printStackTrace();
            }
        }

        return lines;
    }

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

    public static void main(final String[] args) throws IOException {
        solve(INPUT_TXT);
    }
}
