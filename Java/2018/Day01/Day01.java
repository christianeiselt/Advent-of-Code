import java.io.File;
import java.io.IOException;
import java.io.BufferedReader;
import java.io.FileReader;
import java.net.URISyntaxException;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class Day01 {

	private static final String INPUT_TXT = "input.txt";

    public static ArrayList <String> getContent(final String path) {

        BufferedReader reader = null;
        final ArrayList<String> lines = new ArrayList<String>();

        try {
            String sCurrentLine;
            reader = new BufferedReader(new FileReader(path));
            while ((sCurrentLine = reader.readLine()) != null) {
                lines.add(sCurrentLine);
            }
        } catch (final IOException e) {
            e.printStackTrace();
            System.out.print(e.getMessage());
        } finally {
            try {
                if (reader != null)
                    reader.close();
            } catch (final IOException ex) {
                System.out.println(ex.getMessage());
                ex.printStackTrace();
            }
        }

        return lines;
	}

	public static void solve(final String path) {

        final ArrayList<String> changes = getContent(path);

        Integer resultingFrequency = 0;

        int duplicateFrequency = 0;

        boolean duplicate = false;

        final HashSet<Integer> frequencies = new HashSet<>();
        int sum = 0;

        while (!duplicate) {
            for (int i = 0; i < changes.size(); i++) {
                final int number = Integer.parseInt(changes.get(i));
                resultingFrequency += number;

                if (!(frequencies.contains(resultingFrequency))) {
                    frequencies.add(resultingFrequency);
                } else {
                    if (duplicate == false) {
                        duplicate = true;
                        duplicateFrequency = resultingFrequency.intValue();
                    }
                }
            }
            if (sum == 0) {
                sum = resultingFrequency;
            }
        }

        System.out.println("The resulting frequency is: " + sum);

        if (duplicate) {
            System.out.println("The first frequency reached twice is: " + duplicateFrequency);
        }
    }

    public static void main(final String[] args) throws IOException {
		solve(INPUT_TXT);
    }
}
