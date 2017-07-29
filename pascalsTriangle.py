class Solution:
    
    def getMiddle(self, l):
        if len(l) > 1:
            return [sum(l[:2])] + self.getMiddle(l[1:])
        else:
            return []
    
    # @return a list of lists of integers
    def generate(self, numRows):
        result = []
        if numRows >= 1:
            result = [[1]]
        for i in range(numRows - 1):
            result.append([1] + self.getMiddle(result[-1]) + [1])
        return result

if __name__ == "__main__":
    
    s = Solution()
    print s.generate(2)
