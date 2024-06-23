using System;
using System.IO;
using System.Linq;

public class Euler22
{
    public long CalculateTotalNameScores(string filePath)
    {


        /*
            Using a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
            Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

            For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
            So, COLIN would obtain a score of 938 × 53 = 49714.
        */
        string[] names = ReadNamesFromFile(filePath);

        Array.Sort(names);

        long totalScore = 0;
        for (int i = 0; i < names.Length; i++)
        {
            int alphabeticalValue = CalculateAlphabeticalValue(names[i]);
            int position = i + 1; // 1-based index
            int nameScore = alphabeticalValue * position;
            totalScore += nameScore;
        }

        return totalScore;
    }

    private string[] ReadNamesFromFile(string filePath)
    {
        string content = File.ReadAllText(filePath);
        string[] names = content.Replace("\"", "").Split(',');
        return names;
    }

    private int CalculateAlphabeticalValue(string name)
    {
        return name.Select(c => c - 'A' + 1).Sum();
    }

    public static void Main(string[] args)
    {
        Euler22 euler = new Euler22();
        string filePath = "path_to_your_file/names.txt"; // Provide the correct path to your names.txt file
        long totalNameScores = euler.CalculateTotalNameScores(filePath);
        Console.WriteLine($"Total of all the name scores in the file: {totalNameScores}");
    }
}
