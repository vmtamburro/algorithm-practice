/* 
    Find the first non-repeating char in a string

    string s = "loveleetcode";
    Output: v
*/

public char FirstNonRepeatingChar(string s){
    // create a dictionary to store the frequency of characters
    var dict = new Dictionary<char, int>();
    foreach(var c in s){
        if(dict.ContainsKey(c)){
            dict[c]++;
        }
        else{
            dict[c] = 1;
        }
    }
    
    // find the first non-repeating character
    foreach(var c in s){
        if(dict[c] == 1){
            return c;
        }
    }
}