public class LargestRectangle{
    /* 
        - Example:
            [2, 1, 5, 6, 2, 3]
        - Index 0: height of 2. Can only extend 1 to the right, so area from [0, 1] is 2.
        - Index 1: height of 1. Can extend to all indexes, 1, 2, 3, 4, 5 since they are greater than 1. so area frm [0, 5] is 6.
        - Index 2 is a height of 5. Can extend to index 3, so area from [5, 6] is 10.
        - Index 3 is a heigh of 6. Can only extend by one, since none other have a height greater than 6. So area from [3, 4] is 6.
        - Index 4 is 2. Can extend from 3 to 5. So area from [3, 5] is 6.
    */

    public int LargestRectangleAre(int[] heights){
        int maxArea = 0;

        // loop through the heights array
        for(int i = 0; i < heights.Length; i++){
            // consider this height to be the minimum
            int minHeight = heights[i];
            // loop to the right
            for(int j = i; j < heights.Length; j++){
                minHeight = Math.Min(minHeight, heights[j]); //gets the minimum height between this height and the next height
                // gets the greatest area between the current maxArea 
                  //and the minimum height multiplied by the difference between the current index and the previous index  
                maxArea = Math.Max(maxArea, minHeight * (j - i + 1));
            }
        }

        return maxArea;
    }
}