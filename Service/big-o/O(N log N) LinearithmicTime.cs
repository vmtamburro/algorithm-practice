using System;

public class LinearithmicTime
{

    /// <summary>
    /// Linearithmic time, involves a combo of linear and logarithmic operations.
    /// Merge sort recursively splits the array in half and then merges the sorted hales. 
    /// Each split operation takes O(log N), and merging takes O(N) time. 
    /// </summary>
    /// <param name="array"></param>
    public void MergeSort(int[] array)
    {
        if (array.Length <= 1) // array already sorted
            return;
        

        // Split the array into two even halves
        int mid = array.Length / 2; 
        int[] left = new int[mid]; 
        int[] right = new int[array.Length - mid];
        
        Array.Copy(array, 0, left, 0, mid);
        Array.Copy(array, mid, right, 0, array.Length - mid);
        
        MergeSort(left);
        MergeSort(right);
        
        Merge(array, left, right);
    }
    
    private void Merge(int[] array, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;
        
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
                array[k++] = left[i++];
            else
                array[k++] = right[j++];
        }
        
        while (i < left.Length)
            array[k++] = left[i++];
        
        while (j < right.Length)
            array[k++] = right[j++];
    }
}
