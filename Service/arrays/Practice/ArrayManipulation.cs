public class ArrayManipulationPractice{
    public static long arrayManipul(int n, List<List<int>> queries){
        // use the prefix sum technique
        // allocate an array
        int[] arr = new int[n + 1];

        // mark the beginning and end of each range with increments and decrements of the values
        for(var i = 0; i < queries.Count; i++){
            var firstIndex = queries[i][0];
            var secondIndex = queries[i][1];
            var value = queries[i][2];

            arr[firstIndex - 1] += value;
            if(secondIndex < n){ // check for end of array
                arr[secondIndex ] -= value;
            }
        }


        int max = 0;
        int sum = 0;
        for(int i = 0; i < n; i++){
            // prefix sum calculation
            sum += arr[i];
            if(sum > max){
                max = sum;
            }
        }

        return max;

    }
}