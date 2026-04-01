public class Solution {
    public string Multiply(string num1, string num2) {
        return (AsInteger(num1) * AsInteger(num2)).ToString();
    }

    private long AsInteger(string num)
    {
        var result = 0l;

        for (var i = 0; i < num.Length; i++)
        {
            var mul = i == 0 ? 1 : (long)Math.Pow(10, i);
            result += (num[num.Length - i - 1] - '0') * mul;
        }

        return result;
    }
}
