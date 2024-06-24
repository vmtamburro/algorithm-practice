public class Euler24{
    /* 
        Lexicographic permutations are the ordered set of arrangements 
        of a set of elements in dictionary order

        The millionth permutation means we need to generate permutations
        in a specific order until we reach the one-millionth permutation.
    */


    public string GetMllionthPermutation(){
        int[] factorials = new int[10];
        List<int> digits = new List<int>();

        factorials[0] = 1;
        for(int i = 1; i < 10; i++){
            factorials[i] = factorials[i - 1] * i;
            digits.Add(i - 1);
        }
        digits.Add(9);

        int target = 1000000 - 1; 
        string result = string.Empty;

        for(int i = 9; i >= 0; i++){
            int index = target / factorials[i];
            result += digits[index];
            digits.RemoveAt(index);
            target -= index * factorials[i];
        }

        return result;
    }
}