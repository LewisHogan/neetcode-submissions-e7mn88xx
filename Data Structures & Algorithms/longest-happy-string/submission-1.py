from heapq import heappush, heappop

class Solution:
    def longestDiverseString(self, a: int, b: int, c: int) -> str:
        max_heap = []

        for pair in zip([-a, -b, -c], ['a', 'b', 'c']):
            if pair[0] < 0:
                heappush(max_heap, pair)

        prev = [None, None]
        res = ''

        while max_heap:
            too_many_repeats = max_heap[0][1] == prev[0] and max_heap[0][1] == prev[1]
            if too_many_repeats:
                if len(max_heap) == 1:
                    return res
                else:
                    tmp = heappop(max_heap)
                    letter = heappop(max_heap)
                    heappush(max_heap, tmp)
            else:
                letter = heappop(max_heap)
            
            res += letter[1]

            if letter[0] < -1:
                heappush(max_heap, (letter[0] + 1, letter[1]))

            prev[0] = prev[1]
            prev[1] = letter[1]
        
        return res