using System;

public static class MatrixHelper
{
    public static int[,] Multiply(int[,] a, int[,] b)
    {
        if (a == null || b == null) throw new ArgumentNullException();
        int aRows = a.GetLength(0), aCols = a.GetLength(1);
        int bRows = b.GetLength(0), bCols = b.GetLength(1);
        if (aCols != bRows) throw new ArgumentException("Invalid dimensions");
        var result = new int[aRows, bCols];
        for (int i = 0; i < aRows; i++)
            for (int j = 0; j < bCols; j++)
                for (int k = 0; k < aCols; k++)
                    result[i, j] += a[i, k] * b[k, j];
        return result;
    }

    public static int[,] Transpose(int[,] matrix)
    {
        if (matrix == null) throw new ArgumentNullException();
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        var result = new int[cols, rows];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[j, i] = matrix[i, j];
        return result;
    }
}
