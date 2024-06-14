public class LeftRotationPractice{
    public static List<int> rotLeft(List<int>a, int d){
        var subArray = a.Slice(0, d);
        a.RemoveRange(0, d);
        a.AddRange(subArray);
        return a;
    }
}