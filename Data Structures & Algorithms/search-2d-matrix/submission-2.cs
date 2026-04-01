public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var left = 0;
        var right = (matrix.Length * matrix[0].Length) - 1;

        while (left <= right) {
            var mid = left + (right - left) / 2;
            var (row, column) = GetRowAndColumn(mid, matrix[0].Length);

            if (matrix[row][column] == target) {
                return true;
            }

            if (matrix[row][column] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        return false;
    }

    private (int Row, int Column) GetRowAndColumn(int index, int rowSize) {
        var column = index % rowSize;
        var row = index / rowSize;
        return (row, column);
    }
}
