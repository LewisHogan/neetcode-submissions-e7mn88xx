public class Solution {
    public string PredictPartyVictory(string senate) {
        var queue = new Queue<char>();

        var radiantToRemove = 0;
        var direToRemove = 0;

        var totalRadiant = 0;
        var totalDire = 0;

        foreach (var c in senate)
        {
            queue.Enqueue(c);
            if (c == 'R') totalRadiant++;
            else totalDire++;
        }

        while (queue.Count > 0)
        {
            var senator = queue.Dequeue();

            if (senator == 'R')
            {
                if (radiantToRemove > 0)
                {
                    radiantToRemove--;
                    continue;
                }

                totalDire--;
                direToRemove++;
            }
            else
            {
                if (direToRemove > 0)
                {
                    direToRemove--;
                    continue;
                } 
                totalRadiant--;
                radiantToRemove++;
            }

            if (totalRadiant <= 0) return "Dire";
            else if (totalDire <= 0) return "Radiant";

            queue.Enqueue(senator);
        }

        return totalRadiant > totalDire ? "Radiant" : "Dire";
    }
}