public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        
        var indiciesFound = new HashSet<int>();
        foreach (var triplet in triplets)
        {
            if (triplet[0] > target[0] || triplet[1] > target[1] || triplet[2] > target[2]) continue;

            for (var i = 0; i < 3; i++)
            {
                if (triplet[i] == target[i])
                {
                    indiciesFound.Add(i);
                }
            }
        }

        return indiciesFound.Count == 3;
    }
}
