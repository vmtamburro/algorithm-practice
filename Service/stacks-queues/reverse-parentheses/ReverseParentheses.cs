using System;
using System.Collections.Generic;

public class ReverseParenthesesSolution{
    public static string ReverseParentheses(string s){
        Stack<string> stack = new Stack<string>();
        string current = "";

        foreach(var c in s){
            if(c == '('){
                stack.Push(current);
                current = "";
            }
            else if(c == ')'){
                string temp = "";
                while(stack.Count > 0){
                    temp = stack.Pop() + ReverseString(current);
                    current = temp;
                }
            }
            else{
                current += c;
            }
        }
        return current;

    }

    private static string ReverseString(string s){
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static void Main(string[] args)
    {
        // Test cases
        string[] testCases = 
        {
            "(ed(et(oc))el)",
            "a(bc(def)g)",
            "a(b(c)d)e",
            "a(bc)d",
            "(ab(cd))"
        };

        // Test the function with each test case
        foreach (var testCase in testCases)
        {
            string result = ReverseParentheses(testCase);
            Console.WriteLine($"ReverseParentheses(\"{testCase}\") = \"{result}\"");
        }
    }
}
