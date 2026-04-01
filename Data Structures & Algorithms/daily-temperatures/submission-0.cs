public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var temps = new Stack<int>();
        var results = new int[temperatures.Length];
        for (var i = 0; i < temperatures.Length; i++)
        {
            while (temps.Count > 0 && temperatures[temps.Peek()] < temperatures[i])
            {
                var index = temps.Pop();
                results[index] = i - index;
            }

            temps.Push(i);
        }

        return results;
    }
}
