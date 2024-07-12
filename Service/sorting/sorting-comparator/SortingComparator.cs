using System;
using System.Collections.Generic;

public class Player {
    public string Name { get; }
    public int Score { get; }

    public Player(string name, int score) {
        Name = name;
        Score = score;
    }
}

public class Checker : IComparer<Player> {
    public int Compare(Player a, Player b) {
        // Implement comparator logic here
        // Sort by decreasing score
        if (a.Score != b.Score) {
            // Fill in code here
            if(a.Score > b.Score){
                return -1;
            }else{
                return 1;
            }
        } else {
            // Fill in code here
            return string.Compare(a.Name, b.Name);
        }
    }
}

public class SortingComparator {
    public static void Main(string[] args) {
        // Example usage:
        int n = Convert.ToInt32(Console.ReadLine());
        List<Player> players = new List<Player>();

        for (int i = 0; i < n; i++) {
            string[] input = Console.ReadLine().Split(' ');
            string name = input[0];
            int score = Convert.ToInt32(input[1]);
            players.Add(new Player(name, score));
        }

        // Use Checker to sort players
        players.Sort(new Checker());

        // Print sorted players
        foreach (Player player in players) {
            Console.WriteLine($"{player.Name} {player.Score}");
        }
    }
}
