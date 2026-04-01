public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var freq = new int[26];
        foreach (var task in tasks)
        {
            freq[task - 'A']++;
        }

        var maxFreq = freq.Max();
        var maxCount = freq.Count(n => n == maxFreq);

        //  e.g. X X X and a n of 2 would mean X _ _ X _ _ X _ _
        //                                     1 2 3 4 5 6 7 8 9
        //
        // Number of times we will need to wait n spaces
        var blocksNeeded = freq.Max() - 1;
        // The task itself and then the cooldown period for that task
        var blockSize = n + 1;
        
        // We can interleve all the tasks which belong to a block so we
        // can just add maxCount instead of needing to multiply by it.
        var cycles = blocksNeeded * blockSize + maxCount;

        // If length is bigger it means we have more tasks and since they all take
        // 1 cycle then just use that
        return Math.Max(cycles, tasks.Length);
    }
}
