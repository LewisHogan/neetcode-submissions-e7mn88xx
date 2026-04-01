class Solution:
    def maxArea(self, heights: List[int]) -> int:
        left = 0
        max_area = 0
        while left < (len(heights)-1):
            for right in range(left + 1, len(heights)):
                width = right - left
                area = self.calculate_area(heights[left], heights[right], width)
                max_area = max(max_area, area)
            left += 1
        return max_area
        
    def calculate_area(self, first_height, second_height, width) -> int:
        area = min(first_height, second_height) * width
        return area