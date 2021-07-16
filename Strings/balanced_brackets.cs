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

    public static bool isBalanced_UsingStacks(string str) {
        
        var s = new Stack();
        char x;
        
        for(int i = 0; i < str.Length; i++){
            // Check for all opening brackets, ad push them onto the stack.
            if(str[i] == '(' || str[i] == '[' || str[i] == '{'){
                s.Push(str[i]);
                continue;
            }
            
            // If current char is not opening, then it must be closing. 
            if(s.Count == 0) return false;
            
            switch(str[i]){
                case ')':
                    x = (char)s.Peek();
                    s.Pop();
                    if(x == '{' || x == '['){
                        return false;
                    }
                    break;
                case '}':
                    x = (char)s.Peek();
                    s.Pop();
                    if(x == '(' || x == '['){
                        return false;
                    }
                    break;
                case ']':
                    x = (char)s.Peek();
                    s.Pop();
                    if(x == '(' || x == '{'){
                        return false;
                    }
                    break;
                    
            }
            
        }
        return s.Count == 0;
        
    }
}
