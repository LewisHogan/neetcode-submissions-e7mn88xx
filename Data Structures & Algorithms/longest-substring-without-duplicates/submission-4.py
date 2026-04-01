class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        seen = set()
        l = 0
        max_length = 0
        for i, c in enumerate(s):
            while c in seen:
                seen.remove(s[l])
                l += 1
            
            seen.add(c)
            max_length = max(i - l + 1, max_length)
        
        return max_length