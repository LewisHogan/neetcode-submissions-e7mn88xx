public class Solution {

    public string Encode(IList<string> strs) {
        var builder = new StringBuilder();
        
        foreach (var str in strs) {
            builder.AppendFormat("{0}#{1}", str.Length, str);
        }
        
        return builder.ToString();
    }

    public List<string> Decode(string s) {
        var res = new List<string>();
        var i = 0;
        while (i < s.Length) {
            var j = i;
            while (s[j] != '#') {
                j++;
            }

            // At this point our {0} is i..j
            var strLength = int.Parse(s.Substring(i, j - i));
            // When reading str we need to skip # so + 1
            var decodedStr = s.Substring(j + 1, strLength);
            res.Add(decodedStr);
            // Keep reading past the point we've already read
            i = j + 1 + strLength;
        }

        return res;
    }
}
