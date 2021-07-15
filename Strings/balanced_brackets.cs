using System;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    Console.WriteLine(isBalanced("{}{}"));
  }

    /*
        A bracket can be any of the following characters (), {}, []
        Two brackets ar considered to be a matched pair if the opening bracket (, [, or { 
        occurs to the left of a closing bracket ), ], or }

        A sequence of brackets is balanced if the following conditions are met:
        - It contains no unmatched brackets
        - The subset of brackets enclosed within the confines of a matched pair of brackets is also a matched pair of brackets.


        Given n strings of brackets, determine wheter the sequence of brackets is balanced. If a string is balanced return YES.
        Otherwise return NO.

    */
    public static bool isBalanced(string str){

      var openPartenthCount = 0;
      var openCurlyCount = 0;
      var openSquareCount = 0;

      var closedParenthCount = 0;
      var closedCurlyCount = 0;
      var closedSquareCount = 0;

      

      foreach(var s in str){
          switch(s){
                case '(':
                    openPartenthCount++;
                    break;
                case '{':
                    openCurlyCount++;
                    break;
                case '[':
                    openSquareCount++;
                    break;
                case ')':
                    closedParenthCount++;
                    break;
                case '}':
                    closedCurlyCount++;
                    break;
                case ']':
                    closedSquareCount++;
                    break;
              default:
                break;
          }
      }
      

      return (openPartenthCount == closedParenthCount && openCurlyCount == closedCurlyCount && openSquareCount == closedSquareCount)
            || (openPartenthCount == 0 && closedParenthCount == 0 &&  openCurlyCount == 0 &&  closedCurlyCount == 0 &&  openSquareCount == 0 &&  closedSquareCount == 0);

  }
}