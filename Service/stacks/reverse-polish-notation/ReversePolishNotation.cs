using System;
using System.Collections.Generic;

public class ReversePolishNotation{
    public static int EvalRPN(string[] tokens){
        // Stack to store operands
        Stack<int> stack = new Stack<int>();   

        // Iterate through each token in the input array
        foreach(var token in tokens){
            if(token == "+" || token == "-" || token == "*" || token == "/"){
                // Pop the top two elements from the stack
                int operand2 = stack.Pop();
                int operand1 = stack.Pop();
                int result;
                
                // Perform the operation based on
                switch (token)
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        result = operand1 / operand2;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator");
                }
                stack.Push(result);
            }
            else{
                // If the token is an operand, push it onto the stack
                stack.Push(int.Parse(token));
            }
        }
        return stack.Pop();
    }

    public static void Main(string[] args)
    {
        // Test cases
        string[][] testCases = new string[][]
        {
            new string[] { "2", "1", "+", "3", "*" },
            new string[] { "4", "13", "5", "/", "+" },
            new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }
        };

        // Test the function with each test case
        foreach (var testCase in testCases)
        {
            int result = EvalRPN(testCase);
            Console.WriteLine($"EvalRPN({string.Join(" ", testCase)}) = {result}");
        }
    }
}