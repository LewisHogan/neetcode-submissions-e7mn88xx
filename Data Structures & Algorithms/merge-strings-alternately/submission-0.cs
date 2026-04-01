public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var sb = new StringBuilder(word1.Length + word2.Length);
        
        var w1Remaining = word1.Length;
        var w2Remaining = word2.Length;

        bool takeFromWord1 = true;

        while (w1Remaining > 0 && w2Remaining > 0)
        {
            if (takeFromWord1)
            {
                sb.Append(word1[^w1Remaining]);
                w1Remaining--;
            }
            else
            {
                sb.Append(word2[^w2Remaining]);
                w2Remaining--;
            }

            takeFromWord1 = !takeFromWord1;
        }

        if (w1Remaining > 0)
        {
            sb.Append(word1.Substring(word1.Length - w1Remaining));
        }
        else
        {
            sb.Append(word2.Substring(word2.Length - w2Remaining));
        }

        return sb.ToString();
    }
}