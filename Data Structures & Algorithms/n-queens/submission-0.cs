public class Solution {
    private List<List<string>> results;
    public List<List<string>> SolveNQueens(int n) {
        results = new List<List<string>>();
        DFS(n, n, new List<(int X, int Y)>());
        return results;
    }

    private void DFS(int n, int size, List<(int X, int Y)> queens)
    {
        int last = queens.Count - 1;
        for (var i = 0; i < last; i++)
        {
            var xDiff = queens[i].X - queens[last].X;
            var yDiff = queens[i].Y - queens[last].Y;

            if (xDiff == 0 || yDiff == 0 || Math.Abs(xDiff) == Math.Abs(yDiff))
            {
                return;
            }
        }

        if (n == 0)
        {
            var board = new List<string>();
            for (int r = 0; r < size; r++) {
                char[] rowArr = new char[size];
                Array.Fill(rowArr, '.');
                rowArr[queens[r].Y] = 'Q';
                board.Add(new string(rowArr));
            }
            results.Add(board);
            return;
        }

        int currentRow = size - n;
        for (var col = 0; col < size; col++)
        {
            queens.Add((currentRow, col));
            DFS(n - 1, size, queens);
            queens.RemoveAt(queens.Count - 1);
        }
    }
}