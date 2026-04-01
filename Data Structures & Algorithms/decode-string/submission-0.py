class Solution:
    def decodeString(self, s: str) -> str:
        stack: List[Tuple[int, str]] = []
        first_digit_index: int = None
        part: str = ""
        for i, c in enumerate(s):
            if c in "01234567890":
                if first_digit_index is None:
                    first_digit_index = i
                continue
            if c == "[":
                stack.append((int(s[first_digit_index:i]), part))
                first_digit_index = None
                part = ""
            elif c == "]":
                mul, prev_part = stack.pop()
                part = prev_part + (part * mul)
            else:
                part += c
        return part