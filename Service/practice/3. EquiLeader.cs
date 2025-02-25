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

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int CountEquiLeaders(int[] A) {
        int leader = FindLeader(A);
        if (leader == -1) return 0; // No leader found

        int equiLeaders = 0;
        int leftCount = 0;
        int totalLeaderCount = A.Count(x => x == leader);
        int N = A.Length;

        for (int i = 0; i < N - 1; i++) { 
            if (A[i] == leader) leftCount++; 
            int leftSize = i + 1;
            int rightSize = N - leftSize;
            int rightCount = totalLeaderCount - leftCount;

            if (leftCount > leftSize / 2 && rightCount > rightSize / 2) {
                equiLeaders++;
            }
        }
        return equiLeaders;
    }

    private int FindLeader(int[] A) {
        var countValues = new Dictionary<int, int>();
        int maxCount = 0;
        int candidate = -1;
        int halfLength = A.Length / 2;

        foreach (int num in A) {
            if (countValues.ContainsKey(num)) {
                countValues[num]++;
            } else {
                countValues[num] = 1;
            }

            if (countValues[num] > maxCount) {
                maxCount = countValues[num];
                candidate = num;
            }
        }

        return maxCount > halfLength ? candidate : -1;
    }
}
