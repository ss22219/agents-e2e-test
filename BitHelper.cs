using System;

public static class BitHelper
{
    public static int SetBit(int value, int position)
    {
        return value | (1 << position);
    }

    public static bool GetBit(int value, int position)
    {
        return (value & (1 << position)) != 0;
    }

    public static int CountBits(int value)
    {
        int count = 0;
        while (value != 0)
        {
            count += value & 1;
            value >>= 1;
        }
        return count;
    }
}
