from collections import deque

class Solution:
    def shortestPath(self, grid: List[List[int]]) -> int:
        rows, cols = len(grid), len(grid[0])

        if grid[0][0] == 1 or grid[rows-1][cols-1] == 1:
            return -1
        
        visited = set([(0, 0)])
        queue = deque()
        queue.append(((0, 0), 0))

        while queue:
            pos, length = queue.popleft()

            if pos == (rows-1, cols-1):
                return length
            
            row, col = pos
            
            offsets = [(-1, 0), (1, 0), (0, -1), (0, 1)]

            for (o_r, o_c) in offsets:
                new_row = row + o_r
                new_col = col + o_c

                if new_row < 0 or new_row >= rows:
                    continue
                if new_col < 0 or new_col >= cols:
                    continue
                
                if (new_row, new_col) in visited:
                    continue
                
                if grid[new_row][new_col] == 0:
                    queue.append(((new_row, new_col), length + 1))
                visited.add((new_row, new_col))

        return -1
