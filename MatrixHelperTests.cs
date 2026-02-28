using System;
using Xunit;

public class MatrixHelperTests
{
    [Fact]
    public void Multiply_WithValidMatrices_ReturnsProduct()
    {
        var a = new int[,] { { 1, 2 }, { 3, 4 } };
        var b = new int[,] { { 5, 6 }, { 7, 8 } };
        var result = MatrixHelper.Multiply(a, b);
        Assert.Equal(19, result[0, 0]);
        Assert.Equal(22, result[0, 1]);
        Assert.Equal(43, result[1, 0]);
        Assert.Equal(50, result[1, 1]);
    }

    [Fact]
    public void Multiply_WithNonSquareMatrices_ReturnsProduct()
    {
        var a = new int[,] { { 1, 2, 3 } };
        var b = new int[,] { { 4 }, { 5 }, { 6 } };
        var result = MatrixHelper.Multiply(a, b);
        Assert.Equal(32, result[0, 0]);
    }

    [Fact]
    public void Multiply_WithNullMatrix_ThrowsException()
    {
        var a = new int[,] { { 1 } };
        Assert.Throws<ArgumentNullException>(() => MatrixHelper.Multiply(null, a));
        Assert.Throws<ArgumentNullException>(() => MatrixHelper.Multiply(a, null));
    }

    [Fact]
    public void Multiply_WithInvalidDimensions_ThrowsException()
    {
        var a = new int[,] { { 1, 2 } };
        var b = new int[,] { { 3, 4 } };
        Assert.Throws<ArgumentException>(() => MatrixHelper.Multiply(a, b));
    }

    [Fact]
    public void Transpose_WithSquareMatrix_ReturnsTransposed()
    {
        var matrix = new int[,] { { 1, 2 }, { 3, 4 } };
        var result = MatrixHelper.Transpose(matrix);
        Assert.Equal(1, result[0, 0]);
        Assert.Equal(3, result[0, 1]);
        Assert.Equal(2, result[1, 0]);
        Assert.Equal(4, result[1, 1]);
    }

    [Fact]
    public void Transpose_WithRectangularMatrix_ReturnsTransposed()
    {
        var matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
        var result = MatrixHelper.Transpose(matrix);
        Assert.Equal(3, result.GetLength(0));
        Assert.Equal(2, result.GetLength(1));
        Assert.Equal(1, result[0, 0]);
        Assert.Equal(4, result[0, 1]);
        Assert.Equal(2, result[1, 0]);
        Assert.Equal(5, result[1, 1]);
        Assert.Equal(3, result[2, 0]);
        Assert.Equal(6, result[2, 1]);
    }

    [Fact]
    public void Transpose_WithNull_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => MatrixHelper.Transpose(null));
    }
}
