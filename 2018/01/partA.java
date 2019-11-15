import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class partA {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = null;
        ArrayList <String> myFileLines = new ArrayList <String>();
        try {
            String sCurrentLine;
            reader = new BufferedReader(new FileReader("input.txt"));
            while ((sCurrentLine = reader.readLine()) != null) {
                myFileLines.add(sCurrentLine);
            }
        } catch (IOException e) {
            e.printStackTrace();
            System.out.print(e.getMessage());
        } finally {
            try {
                if (reader != null)reader.close();
            } catch (IOException ex) {
                System.out.println(ex.getMessage());
                ex.printStackTrace();
            }
        }

        int result = 0;

        for (String s : myFileLines) {
            result += Integer.parseInt(s);
        }

        System.out.println(result);
    }
}