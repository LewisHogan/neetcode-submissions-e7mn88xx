public class Solution {
    public bool IsHappy(int n) {
        var seen = new HashSet<int>();

        var slow = n;
        var fast = CalculateNext(n);

        while (slow != fast)
        {
            slow = CalculateNext(slow);
            fast = CalculateNext(CalculateNext(fast));
            if (slow == 1 || fast == 1) return true;
        }

        return fast == 1;
    }

    private int CalculateNext(int n) => GetDigits(n).Select(x => x * x).Sum();

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
