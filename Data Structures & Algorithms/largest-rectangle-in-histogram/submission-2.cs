public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var leftSmaller = new int[heights.Length];
        var rightSmaller = new int[heights.Length];
        var maxArea = 0;

        var stack = new Stack<int>();
        for (var i = 0; i < heights.Length; i++)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i]) stack.Pop();

            leftSmaller[i] = stack.Count > 0 ? stack.Peek() + 1 : 0;

            stack.Push(i);
        }
        stack.Clear();

        for (var i = heights.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i]) stack.Pop();

            rightSmaller[i] = stack.Count > 0 ? stack.Peek() - 1 : heights.Length - 1;
            stack.Push(i);
        }

        for (var i = 0; i < heights.Length; i++)
        {
            var width = rightSmaller[i] - leftSmaller[i] + 1;
            maxArea = Math.Max(maxArea, heights[i] * width);
        }

        return maxArea;
    }
}
