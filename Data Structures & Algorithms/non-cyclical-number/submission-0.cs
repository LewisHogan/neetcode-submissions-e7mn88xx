public class Solution {
    public bool IsHappy(int n) {
        var seen = new HashSet<int>();

        while (n != 1)
        {
            if (seen.Contains(n)) return false;

            seen.Add(n);
            n = GetDigits(n).Select(x => x * x).Sum();
        }

        return true;
    }

    private IEnumerable<int> GetDigits(int n)
    {
        while (n > 9)
        {
            yield return n % 10;
            n /= 10; 
        }

        yield return n % 10;
    }
}
