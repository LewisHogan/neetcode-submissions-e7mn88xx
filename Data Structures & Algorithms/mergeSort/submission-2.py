# Definition for a pair.
# class Pair:
#     def __init__(self, key: int, value: str):
#         self.key = key
#         self.value = value
class Solution:
    def mergeSort(self, pairs: List[Pair]) -> List[Pair]:

        if len(pairs) <= 1:
            return pairs

        pivot = len(pairs) // 2
        left_partition = self.mergeSort(pairs[:pivot])
        right_partition = self.mergeSort(pairs[pivot:])

        return self.merge(left_partition, right_partition)

    def merge(self, left: List[Pair], right: List[Pair]) -> List[Pair]:
        res = []
        while left and right:
            if left[0].key <= right[0].key:
                res.append(left.pop(0))
            else:
                res.append(right.pop(0))
        
        while left:
            res.append(left.pop(0))
        
        while right:
            res.append(right.pop(0))
        return res
