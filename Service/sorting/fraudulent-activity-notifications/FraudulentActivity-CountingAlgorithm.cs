using System;

public class FraudulentActivityCountingAlgorithm {
    public static void Main(string[] args) {
        // Reading input
        string[] nd = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(nd[0]); // number of days of transaction data
        int d = Convert.ToInt32(nd[1]); // number of trailing days used to calculate median spending
        
        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
        
        // Call the function to calculate notifications
        int result = ActivityNotifications(expenditure, d);
        
        // Output the result
        Console.WriteLine(result);
    }
    
    public static int ActivityNotifications(int[] expenditure, int d) {
        int[] count = new int[201]; // Given constraint: 0 <= expenditure[i] <= 200
        int notifications = 0;

        // Initialize the count array for the first d days
        for (int i = 0; i < d; i++) {
            count[expenditure[i]]++;
        }

        for (int i = d; i < expenditure.Length; i++) {
            // Find the median
            double median = GetMedian(count, d);
     
            // Check if current expenditure is >= 2 * median
            if (expenditure[i] >= 2 * median) {
                notifications++;
            }

            // Update the count array by removing the oldest expenditure and adding the new one
            count[expenditure[i - d]]--;
            count[expenditure[i]]++;
        }

        return notifications;
    }

    private static double GetMedian(int[] count, int d) {
        int sum = 0;
        int median1 = -1, median2 = -1;

        if (d % 2 == 1) {
            // Find the middle element
            for (int i = 0; i < count.Length; i++) {
                sum += count[i];
                if (sum >= d / 2 + 1) {
                    return i;
                }
            }
        } else {
            // Find the two middle elements
            for (int i = 0; i < count.Length; i++) {
                sum += count[i];
                if (median1 == -1 && sum >= d / 2) {
                    median1 = i;
                }
                if (sum >= d / 2 + 1) {
                    median2 = i;
                    break;
                }
            }
            return (median1 + median2) / 2.0;
        }

        return 0; // This return should never be reached
    }
}
