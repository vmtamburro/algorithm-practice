public class Solution {

    /* 
    Brute Force Approach

    1. Loop through nums1 and nums2 at the same time
    2. Each iteration, check to see if the value at nums2 is greater than or equal to the value in nums 1
      - If yes, shift the values of num1 over, and insert the value of num2 (shift function)

    ... loop or pointer? might be cleaner as a pointer because the indexing can be adjusted.
    
    Run through an example

    [1, 2, 3, 0, 0, 0]
    [2, 5, 6]

    Iter1
        ptr1 = 0, val1 = 1
        ptr2 = 0, val2 = 2
        val2 >= val1? no - move on
        ptr1++
        ptr2++
    
    Iter2
        ptr1 = 1, val1 = 2
        ptr2 = 1, val2 = 2
        val2 >= val1? yes - insert
        [1, 2, 3, 0, 0, 0]
            SHIFT AND INSERT
            n = ptr1 (1)
            start from the right side 
            - num1[(num1.length - 1)] = num1[num1.length - 2]
            - num1[(numlength - 2)] = num1[num1.length - 3]
            ...
            - num1[num1.length - n + 1] = num1[n] => n = ptr1
            num1[n] = val2
        ptr1++
        ptr2++

    Iter3
        ptr1 = 2, val1 = 2
        ptr2 = 2, val2 = 5
        val2 >= val1? no - move on
        ptr1 ++
        ptr2 ++

    ...
    Iter5
    ptr1 = 4, val1 = 0
    ptr2 = 4, val2 = 5
    val2 >= val1? yes - insert
        Does val1 = 0?
            Replace
            [1, 2, 2, 3, 0, 0]
            [1, 2, 2, 3, 5, 0]
        ELSE
            SHIFT AND INSERT
        num1[n] = val2
        ptr1++
        ptr2++
    Iter6
    ptr1 = 5, val1 = 0
    ptr2 = 5, val2 = 6
    val2 >= val1? yes - insert
        Does val1 = 0?
            Replace
            [1, 2, 2, 3, 5, 0]
            [1, 2, 2, 3, 5, 6]
        ELSE
            SHIFT AND INSERT
        num1[n] = val2
        ptr1++
        ptr2++
    BREAK WHILE LOOP


    ... thoughts about the approach...

    Looping once through all of the arrays
    Shifting stinks... Would be nicer to create another array to avoid the shift all together.
        Could we just replace the values in nums1? What is the cost of shifting each value...
        Shifting increases the time complexity, but extra storage increases the space complexity
    O(length(nums1) * n (size nums2))


    Handle Edge Cases

    - If it's a duplicate in nums1 - just skip it and increase the ptr1 index rather than shifting again.
    - Don't need to start the shifting if both values are zero



    */
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var ptr1 = 0;
        var ptr2 = 0;
        //Console.WriteLine($"m:{m} n:{n}");

        while(ptr2 < n){
            var val1 = nums1[ptr1];
            var val2 = nums2[ptr2];
            //Console.WriteLine($"ptr1: {ptr1}, ptr2: {ptr2}");
            //Console.WriteLine($"val1: {nums1[ptr1]}, val2: {nums2[ptr2]}");

             if(val1 == 0){
                //Console.WriteLine("replace");
                //replace
                nums1[ptr1] = val2;
                ptr2++;
            }

            if(val1 >= val2 ){
                //shift and insert
                //Console.WriteLine("shift and insert");
                var lastIndex = nums1.Length - 1;
                //Console.WriteLine("length of nums1" + nums1.Length);
                
                var insertingIndex = ptr1 + 1;
                while(lastIndex > insertingIndex){ // need to be careful not to wipe something necessary
                    //Console.WriteLine($">> Shifting index {lastIndex - 1} value {nums1[lastIndex - 1]} to index {lastIndex} value {nums1[lastIndex]}");
                    nums1[lastIndex] = nums1[lastIndex - 1];
                    lastIndex --;
                }
                //Console.WriteLine($"new value at index {insertingIndex}: {val2}");
                nums1[insertingIndex] = val2;
            
                ptr2++;
            }
            ptr1++;
            
            //Console.WriteLine(String.Join(",", nums1));
        }

    }
}