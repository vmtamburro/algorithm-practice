public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var maxLength = 0;
        var charSet = new HashSet<char>();
        var left = 0;
        for(var right = 0; right < s.Length; right++){
            while(charSet.Contains(s[right])){
                charSet.Remove(s[left]);
                left++;
            }
            charSet.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }
    }
}