using System;
using System.Collections.Generic;

public static class TreeHelper
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }
    }

    public static List<T> BFS<T>(TreeNode<T> root)
    {
        var result = new List<T>();
        if (root == null) return result;

        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            result.Add(node.Value);
            foreach (var child in node.Children)
                queue.Enqueue(child);
        }

        return result;
    }

    public static List<T> DFS<T>(TreeNode<T> root)
    {
        var result = new List<T>();
        if (root == null) return result;

        var stack = new Stack<TreeNode<T>>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            result.Add(node.Value);
            for (int i = node.Children.Count - 1; i >= 0; i--)
                stack.Push(node.Children[i]);
        }

        return result;
    }
}
