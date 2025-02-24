/*
- Leader is a value that appears more than half of the time
- EquiLeader is a leader that is the leader of the whole array, and a leader in both left and right parts when split at s

- Example

int[] A = {4, 3, 4, 4, 4, 2};
- 4 is the leader of the whole array
- Two potential splits
- Index S = 0, left part = {4}, right part = {3, 4, 4, 4, 2}, leader is 4
- Index S = 1, left part = {4, 3}, right part = {4, 4, 4, 2}, no leader
- Index S = 2, left part = {4, 3, 4}, right part = {4, 4, 2}, leader is 4
- Index S = 3, left part = {4, 3, 4, 4}, right part = {4, 2}, no leader on right
- Index S = 4, left part = {4, 3, 4, 4, 4}, right part = {2}, no leader on right
*/


public int CountEquiLeaders(int[] A){
    // Find the leader of the whole array
    int leader = FindLeader(A);
    if(leader == -1){
        return 0; // No Leader Found
    }

    // Find all potential splits of the array with n as the leader
    var equiLeaders = 0;
    for(var i = 0; i < A.Length; i++){
        var rightSplit = A.Take(i + 1).ToArray(); 
        var leftSplit =  A.Skip(i + 1).ToArray();
        var leftLeader = FindLeader(leftSplit);
        var rightLeader = FindLeader(rightSplit);

        if(leftLeader == -1 || rightLeader == -1){ // check if either or don't contain a leader
            continue;
        }

        if(leftLeader == leader && rightLeader == leader){ // check if the leader of the left and right parts is the same as the leader of the whole array
            equiLeaders++;
        }
    }
}

public int FindLeader(int[] A){
    var countValues = new Dictionary<int, int>();
    var maxCount = 0;
    var candidate = -1;
    var halfLength = A.Length / 2;
    for(var i = 0; i < A.Length; i++){
        if(countValues.ContainsKey(A[i])){
            countValues[A[i]]++;
        }
        else{
            countValues[A[i]] = 1;
        }
        if(countValues[A[i]] > maxCount ){
            maxCount = countValues[A[i]];
            candidate = A[i];
        }   
    }

    if(maxCount > halfLength){
        return candidate;
    }

    return -1; // no leader found

}