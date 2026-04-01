public class WordDictionary {

    public Dictionary<int, WordDictionary> Children = new();
    public bool IsWord = false;

    public WordDictionary() {
        
    }
    
    public void AddWord(string word) {
        var current = this;
        foreach (var c in word)
        {
            if (!current.Children.ContainsKey(c)) current.Children[c] = new();
            current = current.Children[c];
        }
        current.IsWord = true;
    }
    
    public bool Search(string word) {
        var current = this;
        for (var i = 0; i < word.Length; i++)
        {
            var c = word[i];
            if (c == '.')
            {
                foreach (var (_, node) in current.Children)
                {
                    if (node.Search(word.Substring(i + 1))) return true;
                }
                
                return false;
            }
            else
            {
                if (!current.Children.ContainsKey(c)) return false;
                current = current.Children[c];
            }
        }
        return current.IsWord;
    }
}
