public class ConstantTime
{
    /// <summary>
    /// O(1) - Constant Time
    /// Description: An operation that takes constant time means that its execution time is independent of the size of the input.
    /// No looping or iteration. Time complexity remains constant regardless of the array's size.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int GetFirstElement(int[] array)
    {
        // This operation takes constant time
        return array[0];
    }
}
