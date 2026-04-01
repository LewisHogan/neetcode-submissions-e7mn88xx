public class Solution {
    public bool IsValidSudoku(char[][] board) {
        return HasValidRows(board) && HasValidColumns(board)
            && HasValidBoxes(board);
    }

    private bool HasValidRows(char[][] board) {
        foreach (var row in board) {
            var rowNumbers = new HashSet<char>();
            foreach (var c in row) {
                if (c == '.') continue;
                if (rowNumbers.Contains(c)) return false;
                rowNumbers.Add(c);
            }
        }

        return true;
    }

    private bool HasValidColumns(char[][] board) {
        for (var rowIndex = 0; rowIndex < board[0].Length; rowIndex++) {
            var colNumbers = new HashSet<char>();
            for (var colIndex = 0; colIndex < board.Length; colIndex++) {
                var c = board[colIndex][rowIndex];
                if (c == '.') continue;
                if (colNumbers.Contains(c)) return false;
                colNumbers.Add(c);
            }
        }

        return true;
    }

    private bool HasValidBoxes(char[][] board) {
        for (var boxIndex = 0; boxIndex < 9; boxIndex++) {
            var boxNumbers = new HashSet<char>();
            for (var rowIndex = 0; rowIndex < 3; rowIndex++) {
                for (var colIndex = 0; colIndex < 3; colIndex++) {
                    var boxRowOffset = (boxIndex % 3) * 3;
                    // Even though theoretically / 3 then * 3 cancels out,
                    // we need to keep doing it for the flooring behaviour
                    // e.g. (8 / 3) * 3 should give us 6, not 8 because we're using int
                    var boxColOffset = (boxIndex / 3) * 3;
                    var c = board[rowIndex + boxRowOffset][colIndex + boxColOffset];
                    if (c == '.') continue;
                    if (boxNumbers.Contains(c)) return false;
                    boxNumbers.Add(c);
                }
            }
        }
        return true;
    }
}
