public class Solution {
    public bool Exist(char[][] board, string word) {
        for (var row = 0; row < board.Length; row++)
        {
            for (var col = 0; col < board[0].Length; col++)
            {
                if (DFS(board, (row, col), 0, word)) return true;
            }
        }

        return false;
    }

    bool DFS(char[][] board, (int, int) pos, int i, string word)
    {
        var (row, col) = pos;
        if (i == word.Length -1 && word[i] == board[row][col]) return true;
        
        if (board[row][col] != word[i]) return false;

        (int, int)[] nextTiles = [
            (row - 1, col),
            (row + 1, col),
            (row, col - 1),
            (row, col + 1)
        ];

        var value = board[row][col];
        board[row][col] = '#';

        foreach (var nextTile in nextTiles)
        {
            var (nr, nc) = nextTile;

            if (nr < 0 || nr >= board.Length || nc < 0 || nc >= board[0].Length) continue;
            if (board[nr][nc] == '#') continue;

            if (DFS(board, nextTile, i + 1, word)) return true;
        }

        board[row][col] = value;

        return false;
    }
}
