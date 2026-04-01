public class Solution {
    public List<int> PartitionLabels(string s) {
        var charPos = new Dictionary<char, (int StartIdx, int LastIdx)>();
        var orderToEvaluate = new List<char>();
        for (var i = 0; i < s.Length; i++)
        {
            if (!charPos.ContainsKey(s[i]))
            {
                charPos[s[i]] = (i, i);
                orderToEvaluate.Add(s[i]);
            }
            else
            {
                var pos = charPos[s[i]];
                charPos[s[i]] = (pos.StartIdx, i);
            }
        }

        var results = new List<int>();

        // We now have a bunch of intervals which we may need to merge
        var currentEnd = -1;

        foreach (var c in orderToEvaluate)
        {
            var (start, end) = charPos[c];

            if (start > currentEnd)
            {
                // We get to add a new substring/interval
                results.Add(end - start + 1);
                currentEnd = end;
            }
            else if (end > currentEnd)
            {
                // Overlap, we only need to modify if the new end is bigger
                results[^1] += end - currentEnd;
                currentEnd = end;
            }
        }

        return results;
    }
}
