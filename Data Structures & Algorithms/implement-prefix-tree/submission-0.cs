public class PrefixTree {

    class Node
    {
        Dictionary<char, Node> children;
        internal bool IsTerminal { get; set; }
        internal Node()
        {
            children = new Dictionary<char, Node>();
        }

        internal Node Add(char c)
        {
            if (children.ContainsKey(c)) return children[c];
            children[c] = new Node();
            return children[c];
        }

        internal bool Has(char c) => children.ContainsKey(c);

        internal Node this[char c]
        {
            get => children[c];
        }
    }

    private Node root;

    public PrefixTree() {
        root = new Node();
    }
    
    public void Insert(string word) {
        var current = root;
        foreach (var c in word) {
            current = current.Add(c);
        }
        current.IsTerminal = true;
    }
    
    public bool Search(string word) {
        var current = root;
        foreach (var c in word)
        {
            if (!current.Has(c)) return false;
            current = current[c];
        }
        return current.IsTerminal;
    }
    
    public bool StartsWith(string prefix) {
        var current = root;
        foreach (var c in prefix)
        {
            if (!current.Has(c)) return false;
            current = current[c];
        }

        return true;
    }
}
