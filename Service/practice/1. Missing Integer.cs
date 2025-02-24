/*
Task: Find the smallest positive integer that does not occur in a given sequence.
*/
public int FindMissingInteger(int[] A){
    // Sort the array
    Array.Sort(A);

    // Find the smallest positive integer that does not occur in the array
    int smallestPositiveInteger = 1;
    for(int i = 0; i < A.Length; i++){
        if(A[i] == smallestPositiveInteger){
            smallestPositiveInteger++;
        }
        else{
            if(A[i] > smallestPositiveInteger){
                break;
            }
        }
    }

    return smallestPositiveInteger;
}