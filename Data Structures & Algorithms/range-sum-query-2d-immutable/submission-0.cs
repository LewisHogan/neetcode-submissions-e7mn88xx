public class NumMatrix {

    private int[,] cumSum;

    public NumMatrix(int[][] matrix) {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        cumSum = new int[rows + 1, cols + 1];

        for (var row = 0; row < rows; row++)
        {
            var prefix = 0;
            for (var col = 0; col < cols; col++)
            {
                prefix += matrix[row][col];
                cumSum[row+1,col+1] = prefix + cumSum[row, col + 1];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        var bottomLeft = cumSum[row2 + 1, col1];
        var bottomRight = cumSum[row2 + 1, col2 + 1];
        var topLeft = cumSum[row1, col1];
        var topRight = cumSum[row1, col2 + 1];

        return bottomRight - bottomLeft - topRight + topLeft;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */