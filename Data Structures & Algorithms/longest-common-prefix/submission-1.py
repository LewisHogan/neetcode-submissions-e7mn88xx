class TrieNode:
    def __init__(self):
        self.children = {}

    def __contains__(self, item):
        return item in self.children
    
    def __getitem__(self, key):
        return self.children[key]

    def __setitem__(self, key, value):
        self.children[key] = value

    def __len__(self):
        return len(self.children)

class Trie:
    def __init__(self, strs: List[str]):
        self.root = TrieNode()
        for s in strs:
            self._add(s)
    
    def _add(self, s: str):
        current = self.root
        for c in s:
            if c not in current:
                current[c] = TrieNode()
            current = current[c]
    
    def get_longest_common_prefix(self):
        current = self.root
        res = ""
        while len(current) == 1:
            for key in current.children:
                res += key
                current = current[key]
        return res

class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        max_potential_length = min([len(s) for s in strs])
        trie = Trie([s[:max_potential_length] for s in strs])
        return trie.get_longest_common_prefix()