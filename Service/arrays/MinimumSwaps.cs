using System;
using System.Collections.Generic;
using System.Linq;

public class MinSwaps
{

    public static int minimumSwaps(int[] arr)
    {
        var swapCount = 0;
      
        for(var i = 0; i < arr.Length; i++){
            if(arr[i] != i + 1){
                while(arr[i] != i + 1){
                    int temp = arr[arr[i] - 1];
                    arr[arr[i] -  1] = arr[i];
                    arr[i] = temp;
                    swapCount++;
                }

            }
        }

        return swapCount;
    }

    


}
