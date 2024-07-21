public class MinMaxRiddle{
    /*
        - Split values into buckets of specific sizes
        - 6, 3, 5, 1, 12
        - {6}, {3}, {5}, {1}, {12}
        - {6, 3}, {3, 5}, {5, 1}, {1, 12}
        - {6, 3, 5}, {3, 5, 1}, {5, 1, 12}
        - {6, 3, 5, 1}, {3, 5, 1, 12}
        - {6, 3, 5, 1, 12}
    */

    public List<int> MinMaxRiddle1(){
        int[] arr = {6, 3, 5, 1, 12};
        List<int> result = new List<int>();
        var buckets = new Dictionary<int, List<List<int>>>();

        var windowSize = 1;
        
       while(windowSize <= arr.Length){
            List<List<int>> windows = new List<List<int>>();
        
            for(var i = 0; i < arr.Length ; i++){
                var window = new List<int>();
                if(windowSize + i <= arr.Length)
                {
                    for(var j = 0; j < windowSize; j++){
                        window.Add(arr[i + j]);
                    }
                    if(window.Count == windowSize){
                        windows.Add(window);
                    }
                }
            }

           buckets.Add(windowSize, windows);
           windowSize++;
       }

       foreach(var bucket in buckets){
            var windows = bucket.Value;
            List<int> mins = new List<int>();
            foreach(var window in windows){
                mins.Add(window.Min()); 
            }

            result.Add(mins.Max());
       }

        return result;
    }

    public int[] MinMaxRiddle2(int[] arr)
    {
        int n = arr.Length;
        int[] result = new int[n];

        // Arrays to store previous and next smaller elements
        int[] left = new int[n];
        int[] right = new int[n];

        // Stack to find previous smaller elements
        Stack<int> s = new Stack<int>();

        // Fill left[] using a stack
        for (int i = 0; i < n; i++)
        {
            while (s.Count > 0 && arr[s.Peek()] >= arr[i])
                s.Pop();
            left[i] = s.Count == 0 ? -1 : s.Peek();
            s.Push(i);
        }

        // Clear stack to be reused for finding next smaller elements
        s.Clear();

        // Fill right[] using a stack
        for (int i = n - 1; i >= 0; i--)
        {
            while (s.Count > 0 && arr[s.Peek()] >= arr[i])
                s.Pop();
            right[i] = s.Count == 0 ? n : s.Peek();
            s.Push(i);
        }

        // Initialize result array with the minimum values
        for (int i = 0; i < n; i++)
        {
            int length = right[i] - left[i] - 1;
            result[length - 1] = Math.Max(result[length - 1], arr[i]);
        }

        // Fill the result array with the maximum of minimum values for every window size
        for (int i = n - 2; i >= 0; i--)
        {
            result[i] = Math.Max(result[i], result[i + 1]);
        }

        return result;
    }

}