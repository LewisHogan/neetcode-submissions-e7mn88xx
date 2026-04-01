public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        var res = new List<string>();

        Backtrack(n, 0, res, "");
        return res;
    }

    void Backtrack(int n, int balance, List<string> res, string s)
    {
        if (balance < 0 || balance > n) return;

        if (s.Length == 2 * n)
        {
            if (balance == 0) res.Add(s);
            return;
        }

        if (balance > 0)
        {
            Backtrack(n, balance - 1, res, s + ')');
        }

        Backtrack(n, balance + 1, res, s + '(');
        
    }
}
