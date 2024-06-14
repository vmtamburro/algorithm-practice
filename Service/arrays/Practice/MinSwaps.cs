public class MinSwapsPractice{
    public static int minimumSwaps(int[] arr){
        var swapCount = 0;
        
        for(var i = 0; i < arr.Length; i++){
            // check if the swap should exist at this position
            if(arr[i] != i + 1){
                // perform the swap until it's in it's real position, increment the swap count
                while(arr[i] != arr[i + 1]){
                    var tmp = arr[arr[i] - 1]; // get the value where the swap actually should be. swap with this index
                    arr[arr[i - 1]] = arr[i];
                    arr[i] = tmp;
                    swapCount++;
                }
            }
        }

        return swapCount;
    }


                    // [*7, 1, 3, 2, 4, 5, 6] 
                    // [*6, 1, 3, 2, 4, 5, 7] Swap Count = 1
                    // [1, *6, 3, 2, 4, 5, 7] Swap Count = 2
                    // [1, *6, 3, 2, 4, 5, 7] Swap Count = 2
                    // [1, *2, 3, 6, 4, 5, 7] Swap Count = 3
                    // [1, 2, *3, *4, *6, 5, 7] Swap Count = 4
                    // [1, 2, 3, 4, *5, 6, 7] Swap Count = 4
}