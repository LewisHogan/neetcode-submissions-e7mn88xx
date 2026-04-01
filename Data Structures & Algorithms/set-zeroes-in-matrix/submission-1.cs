public class Solution {
    public void SetZeroes(int[][] matrix) {
        // In the top left corner, set the value to be the index
        // of the first 0
        // then for each 0 we go to, we set the index of where the next 0 should
        // be
        // then we can follow our embedded linked list and set everything to 0 as
        // we go

        var zeroInFirstRow = false;

        var rows = matrix.Length;
        var cols = matrix[0].Length;

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (matrix[row][col] == 0)
                {
                    if (row == 0) zeroInFirstRow = true;
                    if (row > 0) matrix[row][0] = 0;

                    matrix[0][col] = 0;
                }
            }
        }

        for (var row = 1; row < rows; row++)
        {
            for (var col = 1; col < cols; col++)
            {
                if (matrix[row][0] == 0 || matrix[0][col] == 0)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        if (matrix[0][0] == 0)
        {
            for (var row = 0; row < rows; row++)
            {
                matrix[row][0] = 0;
            }
        }

        if (zeroInFirstRow)
        {
            for (var col = 0; col < cols; col++)
            {
                matrix[0][col] = 0;
            }
        }
    }
}
