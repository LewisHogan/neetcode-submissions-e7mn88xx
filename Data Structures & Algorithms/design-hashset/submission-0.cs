public class HashNode
{
    public List<int> Values { get; set; } = new();
}


public class MyHashSet {

    HashNode[] nodes = new HashNode[32];

    public MyHashSet() {
        Array.Fill(nodes, new());
    }
    
    public void Add(int key) {
        var bucket = key % nodes.Length;
        foreach (var value in nodes[bucket].Values)
        {
            if (value == key) return;
        }
        nodes[bucket].Values.Add(key);
    }
    
    public void Remove(int key) {
        var bucket = key % nodes.Length;
        for (var i = 0; i < nodes[bucket].Values.Count; i++)
        {
            if (nodes[bucket].Values[i] == key)
            {
                nodes[bucket].Values.RemoveAt(i);
                return;
            }
        }
    }
    
    public bool Contains(int key) {
        var bucket = key % nodes.Length;
        foreach (var value in nodes[bucket].Values)
        {
            if (value == key) return true;
        }
        return false;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */