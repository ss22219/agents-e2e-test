using System;
using System.Collections.Generic;

public static class StackHelper
{
    public class MinStack
    {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> minStack = new Stack<int>();

        public void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count == 0 || val <= minStack.Peek())
                minStack.Push(val);
        }

        public void Pop()
        {
            if (stack.Count == 0) throw new InvalidOperationException();
            int val = stack.Pop();
            if (val == minStack.Peek())
                minStack.Pop();
        }

        public int Top()
        {
            if (stack.Count == 0) throw new InvalidOperationException();
            return stack.Peek();
        }

        public int GetMin()
        {
            if (minStack.Count == 0) throw new InvalidOperationException();
            return minStack.Peek();
        }
    }
}
