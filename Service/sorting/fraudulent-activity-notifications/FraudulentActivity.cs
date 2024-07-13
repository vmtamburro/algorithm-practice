using System;

public class FraudulentActivity {
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
    
    // Function to calculate number of notifications
    /*
        - If the amount spent by a client on a particular day is greater than or equal to 2 times the median spending for the last d days, a notification is sent

    */
    public static int ActivityNotifications(int[] expenditure, int d) {     
        var subArr = expenditure.Take(d).ToList();
        subArr.Sort();

        var notificationCount = 0;
        for(int i = d; i < expenditure.Length; i++){

            var median = GetMedian(subArr);

            if(expenditure[i] >= 2 * median){
                notificationCount++;
            }

            subArr.RemoveAt(subArr.IndexOf(expenditure[i - d]));
            subArr.Add(expenditure[i]);
            subArr.Sort();
        }
        
        return notificationCount;
    }

    public static int GetMedian(List<int> arr){
        var n = arr.Count;
        if(n % 2 == 0){
            return (arr[n/2] + arr[n/2 - 1]) / 2;
        }else{
            return arr[n/2];
        }
    }
}
