

class Solution:

    def findLongestPalindrome(self, s, i, j):
        strlen = len(s) - 1
        while i > 0 and j < strlen:
            if s[i] != s[j]:
                i += 1
                j -= 1
                break
            i -= 1
            j += 1
        return s[i:j+1] if s[i] == s[j] else ""
    
    # @return a string
    def longestPalindrome(self, s):
        longest = ""
        strlen = len(s) - 1
        for i, c in enumerate(s):
            a = i
            b = i
            while a > 0 and b < strlen:
                a -= 1
                b += 1
                if s[a] != s[b]:
                    a += 1
                    b -= 1
                    break
            longest = longest if len(longest) > len(s[a:b+1]) else s[a:b+1]
        for i, c in enumerate(s[1:]):
            a = i
            b = i + 1
            while a > 0 and b < strlen:
                if s[a] != s[b]:
                    a += 1
                    b -= 1
                    break
                a -= 1
                b += 1
            if s[a] != s[b]:
                a += 1
                b -= 1
            longest = longest if len(longest) > len(s[a:b+1]) else s[a:b+1]            
        return longest

class Solution1:
    
    def findLongestPalindrome(self, s, i, j):
        strlen = len(s) - 1
        while i > 0 and j < strlen:
            if s[i] != s[j]:
                i += 1
                j -= 1
                break
            i -= 1
            j += 1
        if s[i] != s[j]:
            i += 1
            j -= 1
        return s[i:j+1]
    
    # @return a string
    def longestPalindrome(self, s):
        longest = ""        
        for i, c in enumerate(s):
            temp = self.findLongestPalindrome(s, i, i)
            longest = longest if len(longest) > len(temp) else temp
        for i, c in enumerate(s[1:]):
            temp = self.findLongestPalindrome(s, i, i+1)
            longest = longest if len(longest) > len(temp) else temp
        return longest
            
if __name__ == "__main__":
    
    s = Solution1()
    print s.longestPalindrome("aaabaaaa")
