public class RandoPractice_SortingAlgorithms_RadixSort
{
    public static void CountingSort(int[] arr)
    {
        if (arr.Length == 0)
            return;

        int max = arr[0];
        int min = arr[0];
        foreach (var num in arr)
        {
            if (num > max)
                max = num;
            if (num < min)
                min = num;
        }

        int range = max - min + 1;
        int[] count = new int[range];
        int[] output = new int[arr.Length];

        for (int i = 0; i < arr.Length; i++)
            count[arr[i] - min]++;

        for (int i = 1; i < count.Length; i++)
            count[i] += count[i - 1];

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            output[count[arr[i] - min] - 1] = arr[i];
            count[arr[i] - min]--;
        }

        Array.Copy(output, arr, arr.Length);
    }
    public static void RadixSort(int[] arr)
    {
        int max = arr[0];
        foreach (var num in arr)
            if (num > max)
                max = num;

        for (int exp = 1; max / exp > 0; exp *= 10)
            CountingSortByDigit(arr, exp);
    }

    private static void CountingSortByDigit(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        for (int i = 0; i < n; i++)
            count[(arr[i] / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        Array.Copy(output, arr, n);
    }

}