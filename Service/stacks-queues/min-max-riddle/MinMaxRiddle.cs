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

    
}