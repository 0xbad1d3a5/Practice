class Solution:
    
    def getMiddle(self, l):
        if len(l) > 1:
            return [sum(l[:2])] + self.getMiddle(l[1:])
        else:
            return []
    
    # @return a list of lists of integers
    def getRow(self, numRows):
        row = []
        if numRows >= 0:
            row = [1]
        for i in range(numRows):
            row = [1] + self.getMiddle(row) + [1]
        return row

if __name__ == "__main__":
    
    s = Solution()
    print s.generate(3)
