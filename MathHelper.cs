using System;

public static class MathHelper
{
    public static long Factorial(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        if (n == 0 || n == 1) return 1;
        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    public static long Fibonacci(int n)
    {
        if (n < 0) throw new ArgumentException("n must be non-negative");
        if (n == 0) return 0;
        if (n == 1) return 1;
        long a = 0, b = 1;
        for (int i = 2; i <= n; i++)
        {
            long temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }
}
