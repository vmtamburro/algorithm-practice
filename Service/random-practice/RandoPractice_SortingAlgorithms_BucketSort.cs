public class RandoPractice_SortingAlgorithms_BucketSort
{
    public static void BucketSort(float[] arr)
    {
        if (arr.Length == 0)
            return;

        int n = arr.Length;
        int bucketCount = 10;
        List<float>[] buckets = new List<float>[bucketCount];
        for (int i = 0; i < bucketCount; i++)
            buckets[i] = new List<float>();

        foreach (var num in arr)
        {
            int bucketIndex = (int)(num * bucketCount);
            buckets[bucketIndex].Add(num);
        }

        int index = 0;
        foreach (var bucket in buckets)
        {
            bucket.Sort();
            foreach (var num in bucket)
            {
                arr[index++] = num;
            }
        }
    }

}