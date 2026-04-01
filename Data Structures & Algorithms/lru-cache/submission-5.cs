public class LRUCache {

    private LinkedList<int> usageOrder;
    private Dictionary<int, int> cache;
    private int capacity;

    public LRUCache(int capacity) {
        usageOrder = new LinkedList<int>();
        cache = new Dictionary<int, int>();
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) return -1;

        usageOrder.Remove(key);
        usageOrder.AddLast(key);

        return cache[key];
    }
    
    public void Put(int key, int value) {
        if (cache.ContainsKey(key)) {
            usageOrder.Remove(key);
        } else if (cache.Count == capacity) {
                var lastUsedKey = usageOrder.First.Value;
                usageOrder.RemoveFirst();
                cache.Remove(lastUsedKey);
        }

        
        usageOrder.AddLast(key);
        cache[key] = value;
    }
}
