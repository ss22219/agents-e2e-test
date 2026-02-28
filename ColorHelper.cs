using System;

public static class ColorHelper
{
    public static (int R, int G, int B) HexToRgb(string hex)
    {
        if (string.IsNullOrEmpty(hex))
            throw new ArgumentException("Hex string cannot be null or empty", nameof(hex));

        hex = hex.TrimStart('#');

        if (hex.Length != 6)
            throw new ArgumentException("Hex string must be 6 characters long", nameof(hex));

        int r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        int g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        int b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        return (r, g, b);
    }

    public static string RgbToHex(int r, int g, int b)
    {
        if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
            throw new ArgumentException("RGB values must be between 0 and 255");

        return $"#{r:X2}{g:X2}{b:X2}";
    }
}
