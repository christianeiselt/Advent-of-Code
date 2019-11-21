package aoc2018;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;


public class FileImporter {
	
	public static ArrayList <String> getContent(String path) {
		
		BufferedReader reader = null;
        ArrayList <String> lines = new ArrayList <String>();
        
        try {
            String sCurrentLine;
            reader = new BufferedReader(new FileReader(path));
            while ((sCurrentLine = reader.readLine()) != null) {
            	lines.add(sCurrentLine);
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

        return lines;
	}
}