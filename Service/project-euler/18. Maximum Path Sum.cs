public class Euler18
{
    private int[][] triangle;

    public Euler18(int[][] triangle)
    {
        this.triangle = triangle;
    }

    public int MaximumPathSum()
    {
        int n = triangle.Length;

        // dp array to store maximum path sum
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[triangle[i].Length];
        }

        // Initialize dp with the values from the bottom row of the triangle
        for (int j = 0; j < triangle[n - 1].Length; j++)
        {
            dp[n - 1][j] = triangle[n - 1][j];
        }

        // Bottom-up calculation of dp array
        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j < triangle[i].Length; j++)
            {
                dp[i][j] = triangle[i][j] + Math.Max(dp[i + 1][j], dp[i + 1][j + 1]);
            }
        }

        // Maximum path sum is stored in dp[0][0]
        return dp[0][0];
    }
}
