    public class Trie
    {
        public Trie[] Children;
        public string Word { get; set; } = default;
        public bool IsWord => Word is not null;

        public Trie()
        {
            Children = new Trie[26];
        }

        public void AddWord(string word)
        {
            var current = this;
            foreach (var c in word)
            {
                if (current.Children[c - 'a'] is null)
                { 
                    current.Children[c - 'a'] = new Trie();
                }

                current = current.Children[c - 'a'];
            }
            current.Word = word;
        }

        public bool StartsWith(char c, out Trie node)
        {
            node = null;
            if (Children[c - 'a'] is not null) node = Children[c - 'a'];
            return Children[c - 'a'] is not null;
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
                    DFS(board, row, col, node, foundWords);
                }
            }
        }

        return foundWords.ToList();
    }

    void DFS(char[][] board, int row, int col, Trie node, HashSet<string> foundWords)
    {
        if (node.IsWord)
        {
            foundWords.Add(node.Word);
            node.Word = null;
        }

        var value = board[row][col];
        board[row][col] = '#';

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
            var isRowOutOfRange = nr < 0 || nr >= rows;
            var isColOutOfRange = nc < 0 || nc >= cols;
            if (isRowOutOfRange || isColOutOfRange || board[nr][nc] < 'a' || board[nr][nc] > 'z') continue;

            if (node.StartsWith(board[nr][nc], out var nextNode))
            {
                DFS(board, nr, nc, nextNode, foundWords);
                for (var i = 0; i < 26; i++)
                {
                    if (nextNode.Children[i] is not null) break;
                    if (i == 25 && nextNode.Children[i] is null)
                    {
                        node.Children[board[nr][nc] - 'a'] = null;
                    }
                }
            }
        }

        board[row][col] = value;
    }
}