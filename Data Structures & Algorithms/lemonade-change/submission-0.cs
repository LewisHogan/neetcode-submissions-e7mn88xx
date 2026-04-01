public class Solution {
    public bool LemonadeChange(int[] bills) {
        var fiveBills = 0;
        var tenBills = 0;

        foreach (var bill in bills)
        {
            if (bill == 5) {
                fiveBills++;
            } else if (bill == 10)
            {
                fiveBills--;
                tenBills++;
            }
            else if (bill == 20)
            {
                if (tenBills > 0)
                {
                    tenBills--;
                    fiveBills--;
                }
                else
                {
                    fiveBills -= 3;
                }
            }

            if (fiveBills < 0) return false;
        }

        return true;
    }
}