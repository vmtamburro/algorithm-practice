using System;

public class MarkAndToys {
    public static int MaximumToys(int[] prices, int k) {
        // Implement your solution here
        

        /*
            - Sort the prices array
            - Initialize a variable to keep track of the total cost
            - Initialize a variable to keep track of the number of toys
            - Iterate through the prices array
                - If the total cost plus the current price is less than or equal to k
                    - Increment the total cost by the current price
                    - Increment the number of toys
                - Otherwise, break out of the loop
        */

        var n = prices.Length;
        var totalCost = 0;
        var numToys = 0;
        for(var i = 0; i < n; i++){
            if(totalCost + prices[i] <= k){
                totalCost += prices[i];
                numToys++;
            }else{
                break;
            }
        }
        

        return numToys;
    }

    public static void Main(string[] args) {
        // Reading input
        string[] nk = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(nk[0]);
        int k = Convert.ToInt32(nk[1]);
        
        int[] prices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp));
        
        // Calling the function and printing the result
        int result = MaximumToys(prices, k);
        Console.WriteLine(result);
    }
}
