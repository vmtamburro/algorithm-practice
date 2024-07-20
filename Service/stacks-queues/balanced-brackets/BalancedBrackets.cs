public class BalancedBrackets{
    /*
        - Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        - Need a way to keep track of the order of the brackets, probably a stack LIFO.
        - Loop through the string (half of the string) and push the opening brackets to the stack.
        - Loop through the second half oth e string, pop the opening brackets off the stack, and compare with the closing brackets we're looping through.
        - If the closing bracket is not the same as the opening bracket, return false.
        - Need some sort of match for the characters to lookup the opening bracket for the closing bracket.
    */


    public Dictionary<char, char> bracketPairs = new Dictionary<char, char>(){
        {'(', ')'},
        {'{', '}'},
        {'[', ']'}
    };
    public bool IsValid(string s){

        if(s.Length % 2 != 0) return false;
        var openingBrackets = new Stack<char>();
        
        for(var i = 0; i < s.Length; i++){
            
            if(bracketPairs.ContainsKey(s[i])){ // it's an opening bracket
                openingBrackets.Push(s[i]);// push the opening bracket to the stack
            }
            else{ // it's a closing bracket
                if(openingBrackets.Count() == 0) return false; // we couldn't find a corresponding opening bracket
                var openingBracket = openingBrackets.Pop();
                if(bracketPairs[openingBracket] != s[i]){ // the closing bracket doesn't match the opening bracket
                    return false;
                }
            }
        }


        return openingBrackets.Count() == 0;
    }
}