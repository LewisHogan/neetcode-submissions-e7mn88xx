class Solution:
    # Our encoded string is going to be like the following
    # #5 to indicate the next 5 charactes are part of
    # a word

    def encode(self, strs: List[str]) -> str:
        output = ""
        for word in strs:
            output += f"{len(word)}#{word}"
        return output


    def decode(self, s: str) -> List[str]:
        # Example decoding
        # 4#neet4#code5#horse -> [neet, code, horse]
        print(s)
        l = 0
        i = 0
        output = []
        while i < len(s):
            j = i # scan forward
            while s[j] != '#':
                j += 1
            
            word_length = int(s[i:j])
            i = j + 1
            j = i + word_length
            word = s[i:j]
            
            output.append(word)
            i = j
        return output

