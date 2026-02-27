using System;

Console.WriteLine("Hello from Agents E2E Test!");

string test = "hello";
Console.WriteLine($"Reverse of '{test}': {StringHelper.Reverse(test)}");

string palindrome = "racecar";
Console.WriteLine($"Is '{palindrome}' a palindrome? {StringHelper.IsPalindrome(palindrome)}");
