using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'contacts' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts 2D_STRING_ARRAY queries as parameter.
     */


    public static List<int> contacts(List<List<string>> queries)
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        var contacts = new List<string>();
        var counts = new List<int>();
        foreach(var query in queries){
            if(query[0] == "add"){
                for(var i = 0; i <= query[1].Length - 1; i++)
                {
                    
                    var substr = query[1].Substring(0, i + 1);
                    
                    var count = 0;
                    if(map.TryGetValue(substr, out count))
                    {
                        map[substr] = count + 1;
                    }else{
                        map.Add(substr, 1);
                    }

                }
            }    
            else if(query[0] == "find"){
                var count = 0;
                map.TryGetValue(query[1], out count);
                counts.Add(count);
            }            
        }
        return counts;

    }
    
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int queriesRows = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> queries = new List<List<string>>();

        for (int i = 0; i < queriesRows; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        List<int> result = Result.contacts(queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
