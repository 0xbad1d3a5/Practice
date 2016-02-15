class Solution:
    # @param s, a string
    # @return a list of strings
    def findRepeatedDnaSequences(self, s):
        d = {}
        for i, c in enumerate(s[9:]):
            if s[i:i+10] in d:
                d[s[i:i+10]] += 1
            else:
                d[s[i:i+10]] = 1
        return [v for v in list(d) if d[v] > 1]

if __name__ == "__main__":
    
    s = Solution()
    print s.findRepeatedDnaSequences("AAAAAAAAAAA")
