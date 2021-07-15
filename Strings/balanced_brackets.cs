using System;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    Console.WriteLine(isBalanced("{}({})"));
  }

    public static bool isBalanced(string str){
        var n = -1;
        while(s.length != n){
            n = s.length;
            s = s.replace('()', '');
            s = s.replace('{}', '');
            s = s.replace('[]', '');
        }

        if(s.length == 0){
            return true;
        }
        else{
            return false;
        }
    }
}