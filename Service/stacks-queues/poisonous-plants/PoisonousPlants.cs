public class PoisonousPlants{
    /*
        - The problem is to find the number of days after which no plant dies.
        - Example: [6, 5, 8, 4, 7, 10, 9] -> 2
        - Day = 0
        - First Day: Loop through the stack ->
            - 6 - nothing before it so it's fine
            - 5 - less pesticides
            - 8 - more pesticides (dies)
            - 4 - less pesticides
            - 7 - more pesticides (dies)
            - 10 - more pesticides (dies)
            - 9 - less pesticides
        - Second Day -  Day ++
            - 6 - nothing before it so it's fine
            - 5 - less pesticides
            - 4 - less pesticides
            - 9 - more pesticides   (dies)
        - Third Day (done) - Day ++ 
            - 6 - nothing before it so it's fine
            - 5 - less pesticides
            - 4 - less pesticides
    */
    public int PoisonousPlants1(List<int> plants = null){

        plants = new List<int>(){6, 5, 8, 4, 7, 10, 9};
        var day = -1;
        var noDeadPlantsToday = false;
        while(!noDeadPlantsToday){
            day++;
            var deadPlants = new List<int>();
            // inefficient way to loop, since we have to repeat through the same numbers over again.
            for(int i = 1; i < plants.Count; i++){ // start at second plant
                if(plants[i] > plants[i - 1]){
                    deadPlants.Add(i);
                }
            }

            for(int i = deadPlants.Count - 1; i >= 0; i--){
                plants.RemoveAt(deadPlants[i]);
            }
            noDeadPlantsToday = deadPlants.Count == 0;
        }

        return day;
    }

    public int PoisonousPlants2(int[] p = null){
        p = [6, 5, 8, 4, 7, 10, 9];
        Stack<int> stack = new Stack<int>();
        int[] days = new int[p.Length];
        int min = p[0];
        int max = 0;
        int maxDays = 0;
        for(int i = 0; i < p.Length; i++){
            if(p[i] <= min){
                min = p[i];
                days[i] = 0;
            }else{
                while(stack.Count > 0 && p[i] <= p[stack.Peek()]){
                    max = Math.Max(max, days[stack.Pop()]);
                }
                if(stack.Count > 0){
                    days[i] = max + 1;
                    maxDays = Math.Max(maxDays, days[i]);
                }
            }
            stack.Push(i);
        }
        return maxDays;
    }
}