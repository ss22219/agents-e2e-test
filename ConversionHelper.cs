using System;

public static class ConversionHelper
{
    public static double ToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public static double ToFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}
