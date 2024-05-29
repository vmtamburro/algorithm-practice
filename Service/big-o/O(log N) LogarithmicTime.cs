public class LogarithmicTime
{

    /// <summary>
    /// Repeatedly divides the search interval in half until the target interval is found or the interval becomes empty.
    /// At each step the size is halved and the number of steps required to find the target element in 
    /// relation to the size of the input array is logarithmic.
    /// 
    /// Independent from Input Size, and requires the input data to be sorted.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (array[mid] == target)
                return mid;
            else if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        
        return -1; // Element not found
    }
}
