public class RandoPractice_SearchingAlgorithms_BinarySearch
{
    public static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;  // Return the index of the target element
            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;  // Target element not found
    }

    public static int BinarySearchRecursive(int[] arr, int target, int left, int right)
    {
        if (left > right)
            return -1;  // Target element not found

        int mid = left + (right - left) / 2;

        if (arr[mid] == target)
            return mid;  // Return the index of the target element
        if (arr[mid] < target)
            return BinarySearchRecursive(arr, target, mid + 1, right);
        else
            return BinarySearchRecursive(arr, target, left, mid - 1);
    }


}