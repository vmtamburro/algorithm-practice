public class LinearTime
{
    public int Sum(int[] array)
    {
        int sum = 0;
        
        foreach (int num in array)
        {
            sum += num; // This operation is linear
        }
        
        return sum;
    }
}
