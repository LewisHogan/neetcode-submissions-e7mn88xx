class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        res = ''
        open_stack = []
        skip_index = []
        for i, c in enumerate(s):
            if c == '(':
                open_stack.append(i)
            elif c == ')':
                if open_stack:
                    open_stack.pop()
                else:
                    # This means that we have a mismatched character, remove it or don't add it
                    skip_index.append(i)
        
        skip_index.extend(open_stack)
        for i, c in enumerate(s):
            if i in skip_index:
                continue
            res += c
        return res