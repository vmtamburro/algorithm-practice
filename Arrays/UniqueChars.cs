using System;
using System.Linq;


class UniqueChars{
    static void Main(string[] args){
        if(args.Length != 1){
            Console.WriteLine("Please provide a valid string argument");
            return;
        }

        Console.WriteLine(isUniqueChars3(args[0]) ? "Yes" : "No");

    }
    
    /**
    *   Using Linq
    */
    private static bool isUniqueChars(string inputString)
    {
        foreach (char letter in inputString)
        {
            var isUnique = inputString.ToCharArray().Count(x => Char.ToUpper(x) == Char.ToUpper(letter) ) > 1;
             if(isUnique) return false;
        }
        
        return true;
    }
    
    /**
    *   Nested Fors
    */
    private static bool isUniqueChars2(string inputString)
    {
        foreach(char character in inputString){
            var dupeCount = 0;
            foreach(char characterCheck in inputString){
                if(Char.ToUpper(character) == Char.ToUpper(characterCheck)) dupeCount++;
            }   
            return !(dupeCount > 1);

        }
        return true;
    }

    /**
    *   Shifting Approach
    */
    //// private static bool isUniqueChars3(string inputString){
    ////     int checker = 0; 
  
    ////     for (int i = 0; i < inputString.Length; ++i) { 
    ////         int val = (inputString[i] - 'a'); 
    ////         if ((checker & (1 << val)) > 0) 
    ////             return false; 
    ////         checker |= (1 << val); 
    ////     } 
  
    ////     return true; 
    //// }



}
