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
        
    }
}