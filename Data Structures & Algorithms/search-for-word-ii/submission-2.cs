class TrieNode
{
    public TrieNode[] Children = new TrieNode[26];
    public int idx = -1;
    public int count = 0;
    public bool IsWord => idx != -1;

    public void AddWord(string s, int i)
    {
        var current = this;
        current.count++;
        foreach (var c in s)
        {
            if (current.Children[c - 'a'] is null)
            {
                current.Children[c - 'a'] = new TrieNode();
            }

            current = current.Children[c - 'a'];
            current.count++;
        }
        current.idx = i;
    }

    public bool HasNext(char c)
        => Children[c - 'a'] is not null;
}

public class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        var foundWords = new List<string>();
        
        var trie = new TrieNode();
        for (var i = 0; i < words.Length; i++)
        {
            trie.AddWord(words[i], i);
        }

        var rows = board.Length;
        var cols = board[0].Length;

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (trie.HasNext(board[row][col]))
                {
                    DFS(board, trie, (row, col), words, foundWords);
                }
            }
        }

        return foundWords;
    }

    void DFS(char[][] board, TrieNode trie, (int, int) pos, string[] words, List<string> foundWords)
    {
        var (row, col) = pos;
        var rows = board.Length;
        var cols = board[0].Length;

        var isOutOfRange = row < 0 || row >= rows || col < 0 || col >= cols;

        if (isOutOfRange || board[row][col] == '#')
        {
            return;
        }

        var value = board[row][col];
        if (!trie.HasNext(value)) return;
        var node = trie.Children[value - 'a'];

        if (node.IsWord)
        {
            foundWords.Add(words[node.idx]);
            node.idx = -1;
            node.count--;
            // If we have no remaining words in the children, prune the entire
            // branch
            if (node.count == 0)
            {
                trie.Children[value - 'a'] = null;
            }
        }


        board[row][col] = '#';

        DFS(board, node, (row + 1, col), words, foundWords);
        DFS(board, node, (row - 1, col), words, foundWords);
        DFS(board, node, (row, col + 1), words, foundWords);
        DFS(board, node, (row, col - 1), words, foundWords);

        board[row][col] = value;
    }
}
