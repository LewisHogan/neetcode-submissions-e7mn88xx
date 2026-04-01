public class TimeMap {

    private Dictionary<string, List<(int timestamp, string value)>> map;

    public TimeMap() {
        map = new Dictionary<string, List<(int timestamp, string value)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!map.ContainsKey(key)) {
            map[key] = new List<(int timestamp, string value)>();
        }

        map[key].Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        if (map.ContainsKey(key)) {
            var left = 0;
            var right = map[key].Count - 1;
            var result = string.Empty;
            while (left <= right) {
                var mid = left + (right - left) / 2;
                var (entryTimestamp, value) = map[key][mid];
                if (entryTimestamp <= timestamp) {
                    left = mid + 1;
                    result = value;
                } else {
                    right = mid - 1;
                }
            }

            return result;
        } else {
            return string.Empty;
        }
    }
}
