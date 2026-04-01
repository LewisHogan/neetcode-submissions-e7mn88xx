public class Solution {
    public int[] GetOrder(int[][] tasks) {
        var taskQueue = new PriorityQueue<int, int>();
        var availableQueue = new PriorityQueue<int, int>();

        for (var task = 0; task < tasks.Length; task++)
        {
            taskQueue.Enqueue(task, tasks[task][0]);
        }

        var order = new int[tasks.Length];

        var time = 0;
        var count = 0;
        while (taskQueue.Count > 0 || availableQueue.Count > 0)
        {
            // Add any available tasks to the scheduler
            while (taskQueue.Count > 0 && tasks[taskQueue.Peek()][0] <= time)
            {
                var availableTask = taskQueue.Dequeue();
                availableQueue.Enqueue(availableTask, tasks[availableTask][1]);
            }

            // We should only process one task here because
            // by the time we processed this task we might be able to schedule more
            // more efficiently
            if (availableQueue.Count != 0)
            {
                var task = availableQueue.Dequeue();
                order[count++] = task;
                time += tasks[task][1];
            }
            else
            {
                time++;
            }
        }

        return order;
    }
}