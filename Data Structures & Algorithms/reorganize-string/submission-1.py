import heapq

class Solution:
    def reorganizeString(self, s: str) -> str:
        # We need to count the frequency of each
        # char, then insert the most frequent char
        # every other char
        # fill between with the next most frequent
        # then the next etc
        freq = Counter(s)

        maxHeap = [[-cnt, char] for char, cnt in freq.items()]
        heapq.heapify(maxHeap)
        print(maxHeap)

        prev = None
        res = ""

        while maxHeap or prev:
            if prev and not maxHeap:
                return ""
        
            cnt, char = heapq.heappop(maxHeap)
            res += char
            cnt += 1

            if prev:
                heapq.heappush(maxHeap, prev)
                prev = None
            
            if cnt != 0:
                prev = [cnt, char]

        return res