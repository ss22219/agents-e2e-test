using System;

Console.WriteLine("Hello from Agents E2E Test!");

string test = "hello";
Console.WriteLine($"Reverse of '{test}': {StringHelper.Reverse(test)}");

string palindrome = "racecar";
Console.WriteLine($"Is '{palindrome}' a palindrome? {StringHelper.IsPalindrome(palindrome)}");

Console.WriteLine($"Factorial of 5: {MathHelper.Factorial(5)}");
Console.WriteLine($"Fibonacci of 10: {MathHelper.Fibonacci(10)}");
