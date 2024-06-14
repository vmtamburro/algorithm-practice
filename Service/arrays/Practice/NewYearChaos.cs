public class NewYearChaos{
    public static void minimumBribes(List<int> q){
        // create a counter for the number of bribes
        // determine how many the int should be from it's original index (The value itself - 1)
        // if it's more than 2, print "Too Chaotic" and exit
        // place it in it's original spot


        var numberOfBribes = 0;

        for(var i = 0; i < q.Count; i++){
            var value = q[i];

            if(Math.Max(0, value - (i + 1)) > 2){
                Console.WriteLine("Too Chaotic");
                return;
            }

            // count the current number of bribes by checking how many people in front of this person had a higher number
            // and therefore must have bribed him/her
            // Only check from max(0, value - 2) to i - 1
            for(int j = Math.Max(0, value - 2); j < i; j++){
                var personInFront = q[j];

                if(personInFront > value){
                    numberOfBribes++;
                }
            }

        }

        Console.WriteLine(numberOfBribes);
    }
}