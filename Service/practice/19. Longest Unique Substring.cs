public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var maxLength = 0;
        var ptr1 = 0;
        var ptr2 = 1;
        var substr = "";

        while (ptr1 < s.Length && ptr2 < s.Length){
            
            substr = s.Substring(ptr1, ptr2 - ptr1);

            var hasRepeat = false;
            var dict = new Dictionary<char, int>();
            for(var i = 0; i < substr.Length; i++){
                if(dict.ContainsKey(substr[i])){
                    dict[substr[i]] = dict[substr[i]] + 1;
                    if(dict[substr[i]] > 1){
                        hasRepeat = true;
                        break;
                    }
                }else{
                    dict.Add(substr[i], 1);
                }
                
            }

            
            if(hasRepeat){
                ptr1++;
            }
            else{
                maxLength = Math.Max(substr.Length, maxLength);
                ptr2++;
            }
        }
        return maxLength;
    }
}