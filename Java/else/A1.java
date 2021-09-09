public class A1 {

    public static int[] arraySum(int[] arr1, int[] arr2) {
        int arrLength = arr1.length;
        if(arr2.length > arr1.length) {
            arrLength += (arr2.length - arr1.length);
        }

        int[] arrSum = new int[arrLength];

        for (int i=0; i<arr1.length; i++) {
            arrSum[i] = arr1[i];
        }

        for (int i=0; i<arr2.length; i++) {
            arrSum[i] += arr2[i];
        }

        return arrSum;
    }

    public static void main(final String[] args) {
        int[] arr1 = {10, 20, 30};
        int[] arr2 = {100, 200, 300, 400, 500};
        int[] arr3 = arraySum(arr1, arr2);

        for (int i=0; i<arr3.length; i++) {
            System.out.println(arr3[i]);
        }
    }
}
