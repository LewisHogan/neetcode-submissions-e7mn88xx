class Solution:
    def isPalindrome(self, s: str) -> bool:
        left = 0
        right = len(s)-1

        t = s.lower()

        while left < right:
            while left < right and (t[left] not in '0123456789abcdefghijklmnopqrstuvwxyz'):
                left += 1
            while right > left and (t[right] not in '0123456789abcdefghijklmnopqrstuvwxyz'):
                right -= 1
            
            print(t[left], t[right], t[left] != t[right])
            if t[left] != t[right]:
                return False
            
            left, right = left + 1, right - 1
        return True