public class Solution {
    public int Compress(char[] chars) {
        var writePos = 0;
        var i = 0;
        while (i < chars.Length)
        {
            chars[writePos++] = chars[i];
            var j = i + 1;
            while (j < chars.Length && chars[i] == chars[j])
            {
                j++;
            }

            if (j - i > 1)
            {
                var digits = (j - i).ToString();

                foreach (var d in digits)
                {
                    chars[writePos++] = d;
                }
            }
            
            i = j;
        }

        return writePos;
    }
}