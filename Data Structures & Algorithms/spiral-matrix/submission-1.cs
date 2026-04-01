public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        int top = 0, bottom = matrix.Length - 1;
        int left = 0, right = matrix[0].Length - 1;

        var results = new List<int>();

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++) {
                results.Add(matrix[top][i]);
            }
            top++;

            for (int i = top; i <= bottom; i++) {
                results.Add(matrix[i][right]);
            }
            right--;

            if (top > bottom || left > right) break;

            for (int i = right; i >= left; i--) {
                results.Add(matrix[bottom][i]);
            }
            bottom--;

            for (int i = bottom; i >= top; i--) {
                results.Add(matrix[i][left]);
            }
            left++;
        }

        return results;
    }
}
