# Definition for a pair.
# class Pair:
#     def __init__(self, key: int, value: str):
#         self.key = key
#         self.value = value
class Solution:
    def mergeSort(self, pairs: List[Pair]) -> List[Pair]:
        # Base case
        if len(pairs) <= 1:
            return pairs
        
        midpoint = len(pairs) // 2

        left = self.mergeSort(pairs[:midpoint])
        right = self.mergeSort(pairs[midpoint:])

        return self.merge(left, right)

    def merge(self, left, right):
        result = []
        elements_remaining = len(left) + len(right)
        while elements_remaining:
            if left and right:
                result.append(left.pop(0) if left[0].key <= right[0].key else right.pop(0))
            elif left:
                result.append(left.pop(0))
            else:
                result.append(right.pop(0))
            elements_remaining -= 1
        return result
    
