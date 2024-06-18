public class Euler2{
    /* 
        Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1, and 2 the first 10 will be
        1, 2, 3 5, 8, 13, 21, 34, 55 89, ...

        By considering the terms in the fibonacci sequence who do not exceed four million, find the sum of the even-valued terms.
    */

    public void EvenFibonacciSum(){
        var max = 4000000;
        var list = new List<int>();
        fib(1, 2, max, list);

        Console.WriteLine(list.Sum());
    }


    private void fib(int prev, int next, int max, List<int> list){
        var n = prev + next;
        if(n%2 == 0){
            list.Add(n);
        }
        prev = next;
        next = n;

        
        fib(prev, next, max, list);
    }
}