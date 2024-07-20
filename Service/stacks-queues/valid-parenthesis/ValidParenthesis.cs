using System;
using System.Collections.Generic;

public class ValidParenthesis{

    public static void Main(string[] args){
        //test cases
        string[] testCases = {"()", "()[]{}", "(]", "([)]", "{[]}"};
        foreach(var testCase in testCases){
            Console.WriteLine(isValid(testCase));
        }
    }
    public static bool isValid(string s){
        Stack<char> stack = new Stack<char>();

        Dictionary<char, char> mappings = new Dictionary<char, char>(){
            {')', '('},
            {']', '['},
            {'}', '{'}
        };

        foreach(char c in s){
            if(mappings.ContainsKey(c)){
                char topElement = stack.Count == 0 ? '#' : stack.Pop();
                if(topElement != mappings[c]){
                    return false;
                }
            }
            else{
                // if it's an opening bracket, push it onto the stack
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }
}