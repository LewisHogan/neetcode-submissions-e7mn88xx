public class Solution {
    public void Rotate(int[][] matrix) {
        var left = 0;
        var right = matrix.Length - 1;
        var top = 0;
        var bottom = matrix[0].Length - 1;


        while (top < (matrix.Length / 2) && left < (matrix[0].Length / 2))
        {
            for (var i = 0; i < (right - left); i++)
            {
                var tmp = matrix[top][left + i];
                matrix[top][left + i] = matrix[bottom - i][left];
                matrix[bottom - i][left] = matrix[bottom][right - i];
                matrix[bottom][right - i] = matrix[top + i][right];
                matrix[top + i][right] = tmp;
            }

            left++;
            right--;
            top++;
            bottom--;
        }
    }
}
