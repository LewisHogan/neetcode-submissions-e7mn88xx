class Solution:
    def countPaths(self, grid: List[List[int]]) -> int:
        rows = len(grid)
        cols = len(grid[0])

        if grid[0][0] == 1 or grid[rows-1][cols-1] == 1:
            return 0

        def dfs(x, y, path=set()):
            if x == cols - 1 and y == rows - 1:
                return 1

            offsets = [(-1, 0), (1, 0), (0, -1), (0, 1)]
            res = 0

            for offset in offsets:
                nX, nY = x + offset[0], y + offset[1]
                if nX < 0 or nX >= cols or nY < 0 or nY >= rows:
                    continue
                if grid[nY][nX] == 1 or (nX, nY) in path:
                    continue

                path.add((nX, nY))
                res += dfs(nX, nY, path)
                path.remove((nX, nY))
            
            return res
        
        return dfs(0, 0, set([(0, 0)]))