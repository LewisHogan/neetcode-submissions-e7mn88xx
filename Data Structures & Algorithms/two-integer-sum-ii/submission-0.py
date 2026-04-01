class Solution:
    def twoSum(self, numbers: List[int], target: int) -> List[int]:
        left = 0
        right = len(numbers) - 1

        while True:
            total = numbers[left] + numbers[right]
            if total < target:
                left += 1
                continue
            elif total > target:
                right -= 1
                continue
            return [left+1, right+1]