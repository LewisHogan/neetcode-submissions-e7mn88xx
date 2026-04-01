public class Solution {
    public string ConvertToTitle(int columnNumber) {
        var sb = new StringBuilder();
        while (columnNumber != 0)
        {
            columnNumber--;
            sb.Append((char)((columnNumber % 26) + 'A'));
            columnNumber = columnNumber / 26;
        }

        return string.Join("", sb.ToString().Reverse());
    }
}