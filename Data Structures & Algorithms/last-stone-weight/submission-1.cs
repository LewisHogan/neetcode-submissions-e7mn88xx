public class Solution {
    public int LastStoneWeight(int[] stones) {
        var maxHeap = new PriorityQueue<int, int>();
        foreach (var stone in stones)
        {
            maxHeap.Enqueue(stone, -stone);
        }

        while (maxHeap.Count > 1)
        {
            var firstStone = maxHeap.Dequeue();
            var secondStone = maxHeap.Dequeue();

            if (firstStone == secondStone) continue;

            var newStone = firstStone - secondStone;
            maxHeap.Enqueue(newStone, -newStone);
        }

        return maxHeap.Count == 1 ? maxHeap.Peek() : 0;
    }
}
