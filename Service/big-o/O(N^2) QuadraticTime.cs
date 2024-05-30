public class QuadraticTime
{

    /// <summary>
    /// Algorithm whose run time is proportional to square of the size of input.
    /// Typical in algorithms that have nested loops, which iterate over the input size n.
    /// 
    /// Outer Loop runs from first element to last element
    /// Inner Loop compares adjacent elements, and swaps them if they are in the
    /// wrong order.
    /// </summary>
    /// <param name="array"></param>
    public void BubbleSort(int[] array)
    {
        int n = array.Length;
        
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap array[j] and array[j + 1]
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
