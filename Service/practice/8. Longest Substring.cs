/* 
    Given a string s, find the longest substring without repeating characters

    Input: "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.


    Input: "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.


    Input: "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.


    -- Loop
    p -> add to local substring <p>
    w -> add to local substring <p, w>
    w -> repeated char. Check if max substring and replace. Clear local substring, and add this char
    k -> add to local substring <k, w>
    e -> add to local substring <e, k, w>
    w -> repeated char. Check if max substring and replace. Clear local substring, and add this char

*/

public int FindLongestSubstring(string str) {
    if (string.IsNullOrEmpty(str)) return 0;

    var localSubstring = new List<char>();
    int maxLength = 0;
    int start = 0;

    for (int i = 0; i < str.Length; i++) {
        if (localSubstring.Contains(str[i])) {
            // Move the start pointer to the right of the first occurrence of the repeating character
            while (localSubstring.Contains(str[i])) {
                localSubstring.RemoveAt(0);
                start++;
            }
        }
        localSubstring.Add(str[i]);
        maxLength = Math.Max(maxLength, i - start + 1);
    }

    return maxLength;
}