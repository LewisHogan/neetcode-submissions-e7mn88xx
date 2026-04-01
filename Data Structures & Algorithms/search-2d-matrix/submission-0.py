class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        top, bottom = 0, len(matrix) - 1

        while top <= bottom:
            mid = top + (bottom - top) // 2
            row_comparison = self.binarySearch(matrix[mid], target)
            if row_comparison == 0:
                return True
            elif row_comparison < 0:
                top = mid + 1
            else:
                bottom = mid - 1
        return False
    
    def binarySearch(self, row: List[int], target: int) -> int:
        left, right = 0, len(row) - 1
        mid = left + (right - left) // 2

        while left <= right:
            mid = left + (right - left) // 2
            if row[mid] == target:
                return 0
            elif row[mid] < target:
                left = mid + 1
            else:
                right = mid - 1
        
        return -1 if row[mid] < target else 1