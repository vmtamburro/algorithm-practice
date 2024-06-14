public class HourGlassSumPractice{


    public static List<List<int>> HourGlassIndices = new List<List<int>>{
        new List<int>{0, 0},
        new List<int>{0, 1},
        new List<int>{0, 2},
        new List<int>{1, 1},
        new List<int>{2, 0},
        new List<int>{2, 1},
        new List<int>{2, 2}
    };

    public static int hourGlassSum(List<List<int>> arr)
    {

        int max = 0;
        for(var i = 0; i < arr.Count - 3; i++)
        {
            for(var j = 0; j < arr[i].Count - 3; j++)
            {
                var sum = 0;
                foreach(var index in HourGlassIndices){
                    sum += arr[i + index[0]][j+index[1]];
                }
                max = Math.Max(sum, max);
            }
        }

        return max;
    }
}