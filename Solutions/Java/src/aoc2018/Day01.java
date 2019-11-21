package aoc2018;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;

public class Day01 {

	public static void solveDay01(String path) {

		ArrayList <String> changes = FileImporter.getContent(path);
		
        Integer resultingFrequency = 0;

        int duplicateFrequency = 0;
        
        boolean duplicate = false;
        
        HashSet<Integer> frequencies = new HashSet<>();
    	int sum = 0;
        
        while (!duplicate) {
        	for (int i = 0; i < changes.size(); i++) {
        	
        		int number = Integer.parseInt(changes.get(i));

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
        
        if (duplicate == true) {
            System.out.println("The first frequency reached twice is: " + duplicateFrequency);        	
        }
	}
	
	public static void main(String[] args)  throws IOException {
		solveDay01("../../Input/2018/Day01/input.txt");
	}
}