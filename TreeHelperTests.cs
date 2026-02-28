using System;
using System.Collections.Generic;
using Xunit;

public class TreeHelperTests
{
    [Fact]
    public void BFS_SingleNode_ReturnsNodeValue()
    {
        var root = new TreeHelper.TreeNode<int>(1);
        var result = TreeHelper.BFS(root);
        Assert.Equal(new[] { 1 }, result);
    }

    [Fact]
    public void BFS_MultipleNodes_ReturnsLevelOrder()
    {
        var root = new TreeHelper.TreeNode<int>(1);
        root.Children.Add(new TreeHelper.TreeNode<int>(2));
        root.Children.Add(new TreeHelper.TreeNode<int>(3));
        root.Children[0].Children.Add(new TreeHelper.TreeNode<int>(4));
        root.Children[0].Children.Add(new TreeHelper.TreeNode<int>(5));

        var result = TreeHelper.BFS(root);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void BFS_NullRoot_ReturnsEmptyList()
    {
        var result = TreeHelper.BFS<int>(null);
        Assert.Empty(result);
    }

    [Fact]
    public void DFS_SingleNode_ReturnsNodeValue()
    {
        var root = new TreeHelper.TreeNode<int>(1);
        var result = TreeHelper.DFS(root);
        Assert.Equal(new[] { 1 }, result);
    }

    [Fact]
    public void DFS_MultipleNodes_ReturnsPreOrder()
    {
        var root = new TreeHelper.TreeNode<int>(1);
        root.Children.Add(new TreeHelper.TreeNode<int>(2));
        root.Children.Add(new TreeHelper.TreeNode<int>(3));
        root.Children[0].Children.Add(new TreeHelper.TreeNode<int>(4));
        root.Children[0].Children.Add(new TreeHelper.TreeNode<int>(5));

        var result = TreeHelper.DFS(root);
        Assert.Equal(new[] { 1, 2, 4, 5, 3 }, result);
    }

    [Fact]
    public void DFS_NullRoot_ReturnsEmptyList()
    {
        var result = TreeHelper.DFS<int>(null);
        Assert.Empty(result);
    }
}
