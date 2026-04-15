class Solution:
    def calcEquation(self, equations: List[List[str]], values: List[float], queries: List[List[str]]) -> List[float]:
        graph = { }

        for i, [var_1, var_2] in enumerate(equations):
            value = values[i]
            if var_1 not in graph:
                graph[var_1] = {}
            if var_2 not in graph:
                graph[var_2] = {}
            
            graph[var_1][var_2] = value
            graph[var_2][var_1] = 1 / value

        
        def bfs(source, target, graph):
            if target not in graph or source not in graph:
                return -1
            
            queue = [(source, 1)]
            visited = set()

            while queue:
                current, scale = queue.pop(0)
                visited.add(current)
                for next, value in graph[current].items():
                    if next == target:
                        return scale * value
                    if next in visited:
                        continue
                    
                    queue.append((next, scale * value))
            return -1

        return [bfs(q_1, q_2, graph) for q_1, q_2 in queries]
