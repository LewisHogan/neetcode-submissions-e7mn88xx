class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        rows, cols = len(grid), len(grid[0])
        number_of_islands = 0

        # find other cells in the same island
        def dfs(row, col):
            
            if -1 < row < rows and -1 < col < cols:
                if grid[row][col] == '1':
                    grid[row][col] = '0'
                    dfs(row-1, col)
                    dfs(row, col-1)
                    dfs(row, col+1)
                    dfs(row+1, col)
        
        for row in range(rows):
            for col in range(cols):
                if grid[row][col] == '1':
                    dfs(row, col)
                    number_of_islands += 1
        return number_of_islands