public class Solution {
    public List<int> SpiralOrder(int[][] matrix) {
        var steps = new int[] { matrix[0].Length, matrix.Length - 1 };
        var results = new List<int>();

        var directions = new (int, int)[] {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0),
        };

        var direction = 0;

        var row = 0;
        var col = -1;
        while (steps[direction % 2] > 0) {
            for (var i = 0; i < steps[direction % 2]; i++) {
                var movement = directions[direction];
                row += movement.Item1;
                col += movement.Item2;

                results.Add(matrix[row][col]);
            }

            steps[direction % 2]--;
            direction = (direction + 1) % 4;
        }

        return results;
    }
}