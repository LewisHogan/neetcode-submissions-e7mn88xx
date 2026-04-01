    public class Trie
    {
        public Dictionary<char, Trie> Chars { get; set; }
        public string Word { get; set; } = default;
        public bool IsWord => Word is not null;

        public Trie()
        {
            Chars = new();
        }

        public void AddWord(string word)
        {
            var current = this;
            foreach (var c in word)
            {
                if (current.Chars.ContainsKey(c))
                { 
                    current = current.Chars[c];
                    continue;
                }

                current.Chars[c] = new Trie();
                current = current.Chars[c];
            }
            current.Word = word;
        }

        public bool StartsWith(char c, out Trie node)
        {
            node = null;
            if (!Chars.ContainsKey(c)) return false;
            node = Chars[c];
            return true;
        }
    }

public class Solution {

    public List<string> FindWords(char[][] board, string[] words) {
        var trie = new Trie();
        var foundWords = new HashSet<string>();
        foreach (var word in words)
        {
            trie.AddWord(word);
        }

        var rows = board.Length;
        var cols = board[0].Length;

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (trie.StartsWith(board[row][col], out var node))
                {
                    DFS(board, row, col, node, new HashSet<(int, int)> { (row, col) }, foundWords);
                }
            }
        }

        return foundWords.ToList();
    }

    void DFS(char[][] board, int row, int col, Trie node, HashSet<(int, int)> path, HashSet<string> foundWords)
    {
        if (node.IsWord)
        {
            foundWords.Add(node.Word);
        }

        var rows = board.Length;
        var cols = board[0].Length;

        (int, int)[] neighbours = [
            (row - 1, col),
            (row + 1, col),
            (row, col - 1),
            (row, col + 1)
        ];

        foreach (var neighbour in neighbours)
        {
            var (nr, nc) = neighbour;
            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || path.Contains(neighbour)) continue;

            if (node.StartsWith(board[nr][nc], out var nextNode))
            {
                path.Add(neighbour);
                DFS(board, nr, nc, nextNode, path, foundWords);
                path.Remove(neighbour);
            }
        }
    }
}