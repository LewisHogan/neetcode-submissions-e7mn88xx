class Solution:
    def minPathSum(self, grid: List[List[int]]) -> int:
        rows, cols = len(grid), len(grid[0])
        dp = [[float('inf')] * cols for row in range(rows)]
        def dfs(x, y):
            # outside bounds of the grid, can't move there
            if x == cols or y == rows:
                return float('inf')

            if dp[y][x] != float('inf'):
                return dp[y][x]
            
            if (x, y) == (cols-1, rows-1):
                return grid[y][x]
            
            right_path_sum = dfs(x+1, y)
            bottom_path_sum = dfs(x, y+1)
            path_sum = grid[y][x] + min(right_path_sum, bottom_path_sum)
            dp[y][x] = path_sum
            return path_sum
        return dfs(0, 0)