import java.io.File;
import java.io.IOException;
import java.io.BufferedReader;
import java.io.FileReader;
import java.nio.charset.Charset;
import java.sql.Array;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class Solution {

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

        final ArrayList<String> programsInput = getContent(path);
        //System.out.println(programsInput.get(0).getClass().getName());
        String programs = programsInput.get(0);
        String[] programCodes = programs.split(",");

        for (int i = 0; i<programCodes.length; i++) {
            //System.out.println(programCodes[i]);
        }
        //System.out.println("The resulting frequency is: " + sum);

    }

    public static void main(final String[] args) throws IOException {
		solve(INPUT_TXT);
    }
}
