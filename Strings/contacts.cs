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

class Solution{
    class MainClass {
        public static void Main (string[] args) {
            int queriesRows = Convert.ToInt32(Console.ReadLine().Trim());
            List<List<string>> queries = new List<List<string>>();

            for(int i = 0; i < queriesRows; i++){
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
            }

            List<int> resut = Result.contacts(queries);
            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}


/*
    Declare containers for contacts and counts.
    Loops through the query enumerable. 
        - Examine the first element of the query for the command
        - If "add"
            - Add the second element of the query to the contacts container
        - If "find"
            - Add the number of contacts where the contact name contains the second element of the query

    Return the counts enumerable container.

    NOTE: This solution failed in terms of time complexity. 
*/
class Result{
    public List<int> contacts(List<List<string>> queries){
        var contacts = new List<string>();
        var counts = new List<int>();

        foreach(var query in queries){
            if(query[0].ToLower() == "add"){
                contacts.Add(query[1]);
            }

            if(query[0].ToLower() == "find"){
                counts.Add(contacts.Where(x => x.IndexOf(query[1] > -1).Count()))
            }
        }
        return counts;
    }
}