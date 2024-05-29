public class ExponentialTime
{
    /// <summary>
    /// Algorithms are exponential if they grow with each addition to the input size.
    /// Complexity often arises in algorithms that solve problems with a large number of combinations.
    /// Recursive calculation of fibonacci numbers. Each call to the function generates two additional calls, leading to exponential growth over time.
    /// f(n) = f(n-1) + f(n-2)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        
        return Fibonacci(n - 1) + Fibonacci(n - 2); // Exponential time complexity
    }
}
