public class Solution {
    public void Solve(char[][] board) {
        // Check left and right columns for 0s
        var rows = board.Length;
        var cols = board[0].Length;
        
        for (var row = 0; row < board.Length; row++) {
            if (board[row][0] == 'O') {
                board[row][0] = '#';
                DFS(board, (row, 0));
            }

            if (board[row][board[row].Length - 1] == 'O') {
                board[row][board[row].Length - 1] = '#';
                DFS(board, (row, board[0].Length - 1));
            }
        }

        // Check top and bottom rows for 0s
        for (var col = 0; col < board[0].Length; col++) {
            if (board[0][col] == 'O') {
                board[0][col] = '#';
                DFS(board, (0, col));
            }
            
            if (board[board.Length - 1][col] == 'O') {
                board[board.Length - 1][col] = '#';
                DFS(board, (board.Length - 1, col));
            }
        }

        for (var row = 0; row < board.Length; row++) {
            for (var col = 0; col < board[row].Length; col++) {
                if (board[row][col] == 'O') {
                    board[row][col] = 'X';
                } else if (board[row][col] == '#') {
                    board[row][col] = 'O';
                }
            }
        }
    }

    private void DFS(char[][] board, (int Row, int Col) tile)
    {
            var neighbours = new (int, int)[] {
                (tile.Row - 1, tile.Col),
                (tile.Row + 1, tile.Col - 0),
                (tile.Row, tile.Col - 1),
                (tile.Row, tile.Col + 1)
            };

            foreach (var neighbour in neighbours)
            {
                (int row, int col) = neighbour;
                if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length) continue;

                if (board[row][col] == 'O') {
                    board[row][col] = '#';
                    DFS(board, neighbour);
                }
            }
    }
}
