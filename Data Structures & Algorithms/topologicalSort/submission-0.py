from collections import deque
class Solution:
    def topologicalSort(self, n: int, edges: List[List[int]]) -> List[int]:
        adj = { i: [] for i in range(n) }
        in_degree = { i: 0 for i in range(n) }

        for u, v in edges:
            adj[u].append(v)
            in_degree[v] += 1
        
        res = []
        def bfs(queue):
            while queue:
                current = queue.popleft()
                for next in adj[current]:
                    in_degree[next] -= 1

                    if in_degree[next] == 0:
                        queue.append(next)
                res.append(current)
        
        bfs(deque([key for key, value in in_degree.items() if value == 0]))
        return res if len(res) == n else []