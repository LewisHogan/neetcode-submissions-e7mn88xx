class Graph:
    
    def __init__(self):
        self.edges = {}

    def addEdge(self, src: int, dst: int) -> None:
        if src not in self.edges:
            self.edges[src] = set()
        
        if dst not in self.edges:
            self.edges[dst] = set()
        
        self.edges[src].add(dst)

    def removeEdge(self, src: int, dst: int) -> bool:
        if src not in self.edges:
            return False
        
        if dst not in self.edges[src]:
            return False
        
        self.edges[src].remove(dst)
        return True

    def hasPath(self, src: int, dst: int) -> bool:
        # TODO: BFS from src to dest
        queue = [src]
        visited = set()

        while any(queue):
            node = queue.pop(0)
            for next in self.edges[node]:
                if next == dst:
                    return True
                if next in visited:
                    continue
                visited.add(next)
                queue.append(next)
        
        return False
