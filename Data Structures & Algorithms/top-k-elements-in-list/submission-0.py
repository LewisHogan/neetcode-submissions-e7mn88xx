class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        frequency_map = {}
        for num in nums:
            frequency_map[num] = frequency_map[num] + 1 if num in frequency_map else 1
        
        nums_by_freq = sorted(frequency_map.items(), key=lambda t: t[1], reverse=True)
        return [num for (num, _) in nums_by_freq][:k]