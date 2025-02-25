/* 

Longest Balanced Substring

given a string s and only contains '(' and ')', find the length of the longest balanced substring.


Input: S = "(()())" 6
Input: S = ")()())" 4
Input: S = "))))" 0

*/


public int LongestBalancedSubstring(string s){
    var stack = new Stack<char>();

    var substringCounter = 0;
    var maxLength = 0;

    for(var i = 0; i < s.Length; i++){
        if(s[i] == '('){
            stack.Push(s[i]);
        }
        else{ // s[i] == ')'
            var top = stack.Peek();
            if(top != -1 && s[top] == '('){ // previous character is '(' and current character is ')'
                stack.Pop(); // remove the previous character '(' and don't add the new ')'
                substringCounter += 2; // add 2 to the counter
                maxLength = Math.Max(maxLength, substringCounter); // update the maxLength
            }
            else{
                substringCounter = 0; // reset the counter
                stack.Clear();
            }
        }
    }

    return substringCounter;

}