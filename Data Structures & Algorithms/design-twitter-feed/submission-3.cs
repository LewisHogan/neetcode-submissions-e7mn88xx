public class Twitter {

    Dictionary<int, HashSet<int>> followMap;
    // Store the 10 newest tweets in a max heap
    // tweetIds don't always increase though they are
    // unique, so we have to store a counter alongside them
    Dictionary<int, PriorityQueue<(int, int), int>> tweetMap;

    int count;

    public Twitter() {
        followMap = new();
        tweetMap = new();
        count = 0;
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!tweetMap.ContainsKey(userId)) tweetMap[userId] = new();
        var queue = tweetMap[userId];
        queue.Enqueue((count++, tweetId), count);
        if (queue.Count > 10)
        {
            queue.Dequeue();
        }
    }
    
    public List<int> GetNewsFeed(int userId) {
        if (!followMap.ContainsKey(userId)) followMap[userId] = new();
        followMap[userId].Add(userId);
        
        var newsFeed = new PriorityQueue<int, int>();
        foreach (var followee in followMap[userId])
        {
            var tweetsAvailable = Math.Min(10, tweetMap[followee].Count);
            var queue = new PriorityQueue<(int, int), int>(tweetMap[followee].UnorderedItems);
            for (var i = 0; i < tweetsAvailable; i++)
            {
                var (count, tweet) = queue.Dequeue();
                newsFeed.Enqueue(tweet, -count);
            }
        }

        var res = new List<int>();
        while (res.Count < 10 && newsFeed.Count > 0)
        {
            res.Add(newsFeed.Dequeue());
        }

        return res;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!followMap.ContainsKey(followerId)) followMap[followerId] = new();
        if (!tweetMap.ContainsKey(followerId)) tweetMap[followerId] = new();
        followMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (!followMap.ContainsKey(followerId)) followMap[followerId] = new();
        followMap[followerId].Remove(followeeId);
    }
}
