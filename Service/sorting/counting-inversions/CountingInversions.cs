using System;

public class CountingInversions {
    public static void Test() {
        int[] arr = { 38, 27, 43, 3, 9, 82, 10 };
        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(", ", arr));

        int inversions = CountInversions(arr);

        Console.WriteLine($"Sorted array (Inversions: {inversions}):");
        Console.WriteLine(string.Join(", ", arr));
    }
    
    // Function to count inversions
    public static int CountInversions(int[] arr) {
        // Implement your solution here
        var n = arr.Length;
        return MergeSortAndCount(arr, 0, n - 1);
    }

    // Merge sort and count inversions
    public static int MergeSortAndCount(int[] arr, int left, int right) {
        int count = 0;
        if (left < right) {
            int mid = (left + right) / 2;

            count += MergeSortAndCount(arr, left, mid);
            count += MergeSortAndCount(arr, mid + 1, right);
            count += MergeAndCount(arr, left, mid, right);
        }
        return count;
    }

    // Merge two sorted arrays and count inversions
    public static int MergeAndCount(int[] arr, int left, int middle, int right) {
        // size of the left subarray
        int n1 = middle - left + 1;
        // size of the right subarray
        int n2 = right - middle;
        // create two arrays for left and right subarrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, middle + 1, R, 0, n2);

        // initialize indices for left, right, and merged subarrays
        int i = 0, j = 0, k = left;
        // initialize inversion count
        int count = 0;

        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) { // check if the first left index is less than or equal to the first right index
                arr[k] = L[i]; // assign the left index to the merged array
                i++;
                k++;
            } else { // this is an inversion
                arr[k] = R[j]; // the right index is less than the left index, assign the right index to the merged array
                j++;
                k++;
                count += n1 - i; // Count inversions. Also account for the remaining elements in the left array
            }
        }

        while (i < n1) { // fill in the rest of the left array
            arr[k] = L[i];
            k++;
            i++;
        }
        while (j < n2) { // fill in the rest of the right array
            arr[k] = R[j];
            k++;
            j++;
        }

        return count;
    }
}
