class Solution:
    def maxArea(self, heights: List[int]) -> int:
        l, r = 0, len(heights) - 1
        max_area = 0
        while l < r:
            max_area = max(max_area, self.calculate_area(heights[l], heights[r], r - l))
            if heights[l] <= heights[r]:
                l += 1
            elif heights[l] > heights[r]:
                r -= 1
        return max_area
        
    def calculate_area(self, first_height, second_height, width) -> int:
        area = min(first_height, second_height) * width
        return area