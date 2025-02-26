/* 

Find the smallest window of s that contains all the characters of t including duplicates


Input: s = "ADOBECODEBANC", t = "ABC"  
Output: "BANC"
Explanation: The substring "BANC" is the smallest substring that contains 'A', 'B', and 'C'.


*/

public string SmallestWindow(string s, string t){
    // Create a dictionary to store the frequency of characters in t
    var tDict = new Dictionary<char, int>();
    foreach(var c in t){
        if(tDict.ContainsKey(c)){
            tDict[c]++;
        }
        else{
            tDict[c] = 1;
        }
    }
    
    int left = 0, right = 0, minStart = 0, minLen = int.MaxValue;
    int required = tDict.Count(), formed = 0;

    while(right < s.Length){
        char c = s[right];
        if(tDict.ContainsKey(c)){
            tDict[c]--;
            if(tDict[c] == 0){
                formed++;
            }
        }

        while(formed == required){
            if(right - left + 1 < minLen){
                minLen = right - left + 1;
                minStart = left;
            }

            char leftChar = s[left];
            if(tDict.ContainsKey(leftChar)){
                tDict[leftChar]++;
                if(tDict[leftChar] > 0){
                    formed--;
                }
            }
            left++;
        }
        right++;
    }
}

/*

    ADOBECODEBANC
    Dictionary tDict = {A: 1, B: 1, C: 1}
    left = 0, right = 0, minStart = 0, minLen = int.MaxValue
    required = 3, formed = 0


    right = 0, c = A
    tDict = {A: 0, B: 1, C: 1}
    formed = 1

    while formed == required (skip)
    right++ = 1, c = D


    right = 1, c = D
    tDict = {A: 0, B: 1, C: 1}
    formed = 1

    while formed == required (skip)
    right++ = 2, c = O

    right = 2, c = O
    tDict = {A: 0, B: 1, C: 1}
    formed = 1

    while formed == required (skip)
    right++ = 3, c = B

    right = 3, c = B
    tDict = {A: 0, B: 0, C: 1}
    formed = 2

    while formed == required (skip)
    right++ = 4, c = E

    right = 4, c = E
    tDict = {A: 0, B: 0, C: 1}
    formed = 2

    while formed == required (skip)
    right++ = 5, c = C
    tDict = {A: 0, B: 0, C: 0}
    formed = 3

    while formed == required
    right = 5, left = 0, minLen = 6, minStart = 0
    leftChar = A
    tDict = {A: 1, B: 0, C: 0}
    formed = 2
    left++ = 1
    right++ = 6, c = O

    right = 6, c = O
    tDict = {A: 1, B: 0, C: 0}
    formed = 2

    while formed == required (skip)
    right++ = 7, c = D

    ...


*/